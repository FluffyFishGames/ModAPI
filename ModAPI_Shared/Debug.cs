/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.IO;
using System.Linq;
using ModAPI.Configurations;

namespace ModAPI
{
    /// <summary>
    /// ModAPI 로그 시스템 — 4단계 구조.
    ///
    /// 매번 두 파일에 동시에 기록될 수 있다:
    ///   - ModAPI.log           : 사용자용 핵심 로그 (기본값 — detailedOnly 가 아닌 모든 호출)
    ///   - ModAPI.detailed.log  : 모든 호출이 항상 기록됨 (Release/Debug 관계없이)
    ///
    /// ── 4단계 레벨 ──────────────────────────────────────────────────────
    ///   Verbose  : Debug.Log(..., detailedOnly: true) 로 호출
    ///              반복적이거나 기계적인 추적 로그. 타입/메서드/파일 단위로
    ///              수백~수만 건 찍힐 수 있는 내용. ModAPI.log 에는 절대 남기지 않는다.
    ///              예: Cecil 어셈블리 처리 중 타입 하나하나의 Validating/Processing 로그,
    ///                  mods 폴더 1초 폴링마다의 스캔 결과, TLS 프로토콜 설정값 등
    ///
    ///   Notice   : Debug.Type.Notice (기본값)
    ///              사람이 읽는 흐름. 게임/단계 진행 상황, 성공/완료 알림.
    ///              예: "Successfully parsed BaseModLib.dll", "[Validate] Steam OK"
    ///
    ///   Warning  : Debug.Type.Warning
    ///              잠재적 문제. 즉시 실패는 아니지만 사용자가 알아둘 만한 상황.
    ///              예: 파일명 패턴 검증 실패, 디지털 서명 없음, 게임 실행파일 누락
    ///
    ///   Error    : Debug.Type.Error
    ///              확실한 실패. 작업이 중단되었거나 예외가 발생한 경우.
    ///              예: DLL 파싱 실패, 다운로드 실패, 체크섬 불일치
    ///
    /// ── 새 로그를 추가할 때 판단 기준 ────────────────────────────────────
    ///   1) "이 메시지가 같은 작업 안에서 여러 번(수십~수만 번) 반복될 수 있는가?"
    ///      → 그렇다면 detailedOnly: true (Verbose)
    ///      → 1회성이거나 손에 꼽을 정도로만 반복된다면 detailedOnly 생략
    ///   2) 심각도는 Notice → Warning → Error 순서로 고른다.
    ///      애매하면 한 단계 낮은 쪽(덜 심각한 쪽)을 선택한다 — 과장된 경고/오류는
    ///      사용자를 불필요하게 불안하게 만든다.
    ///
    /// 사용 예:
    ///   Debug.Log("Game: " + gameId, "Download succeeded.", Debug.Type.Notice);
    ///   Debug.Log("ModsViewModel", "[FindMods] Scanning...", Debug.Type.Notice, detailedOnly: true);
    ///   Debug.Log("ModLib: " + gameId, "File not found: " + path, Debug.Type.Error);
    /// </summary>
    public class Debug
    {
        public static string Environment = "global";
        public static bool Verbose = false;

        protected static string LastEnvironment = "";
        protected static FileStream LogStream;
        protected static StreamWriter LogWriter;

        // ── 상세 로그 (detailed) ──────────────────────────────────────────
        // ModAPI.log 는 사용자가 보기 편하도록 핵심 로그만 유지하고,
        // 모든 Debug.Log() 호출 내용은 Release/Debug 관계없이 항상
        // ModAPI.detailed.log 에 기록한다. 사용자 문제 발생 시
        // 이 파일만 받으면 #if DEBUG 로 가려졌던 상세 로그까지 모두 확인 가능.
        protected static string LastDetailedEnvironment = "";
        protected static FileStream DetailedLogStream;
        protected static StreamWriter DetailedLogWriter;

        /// <summary>
        /// 심각도 3단계. Verbose(반복적 추적 로그) 단계는 별도 enum 값이 아니라
        /// 호출 시 detailedOnly: true 를 지정하는 방식으로 표현한다 — 어떤 Type 이든
        /// detailedOnly 와 함께 사용 가능하지만, 실무에서는 거의 항상 Notice 와 짝지어 쓴다.
        /// </summary>
        public enum Type
        {
            Notice,
            Warning,
            Error
        }

        /// <summary>
        /// detailedOnly: true 면 ModAPI.log 에는 쓰지 않고 ModAPI.detailed.log 에만 기록한다.
        /// 기존 #if DEBUG 로 감싸져 있던 호출들을 이 옵션으로 전환하면,
        /// Release 빌드에서도 호출 자체는 항상 실행되어 detailed.log 에는 빠짐없이 남고,
        /// 사용자용 ModAPI.log 는 기존처럼 핵심 로그만 유지된다.
        /// </summary>
        public static void Log(string type, string message, Type logType = Type.Notice, bool detailedOnly = false)
        {
            var logFileName = Configuration.GetPath("Logs") + Path.DirectorySeparatorChar + Environment + ".log";
            if (logFileName.StartsWith("" + Path.DirectorySeparatorChar))
            {
                logFileName = logFileName.Substring(1);
            }
            if (Environment != LastEnvironment || LogStream == null || !LogStream.CanWrite)
            {
                if (LogStream != null)
                {
                    try
                    {
                        LogStream.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (File.Exists(logFileName))
                {
                    var directory = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                    if (Path.GetFileName(logFileName) != logFileName)
                    {
                        directory = Path.GetDirectoryName(logFileName) + Path.DirectorySeparatorChar;
                    }
                    var oldLogs = (Directory.GetFiles(directory, Environment + ".*.log")).ToList();
                    oldLogs.Sort();
                    oldLogs.Reverse();
                    foreach (var oldLog in oldLogs)
                    {
                        try
                        {
                            var fileName = Path.GetFileNameWithoutExtension(oldLog);
                            var num = int.Parse(fileName.Substring(Environment.Length + 1));
                            if (num < 5)
                            {
                                File.Move(oldLog, Path.GetDirectoryName(oldLog) + Path.DirectorySeparatorChar + Environment + "." + (num + 1) + ".log");
                            }
                            else
                            {
                                File.Delete(oldLog);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    File.Move(logFileName, directory + Environment + ".0.log");
                }

                LogStream = new FileStream(logFileName, FileMode.Create, FileAccess.Write, FileShare.Read);
                LogWriter = new StreamWriter(LogStream);
                LastEnvironment = Environment;
            }

            // ── 상세 로그 파일 준비 (ModAPI.detailed.log) ───────────────────
            // ModAPI.log 와 동일한 회전 규칙을 따르되 파일명만 분리한다.
            // Release/Debug 관계없이 항상 기록되므로, #if DEBUG 로 막힌 호출도
            // 이 파일에는 전부 남는다.
            var detailedLogFileName = Configuration.GetPath("Logs") + Path.DirectorySeparatorChar + Environment + ".detailed.log";
            if (detailedLogFileName.StartsWith("" + Path.DirectorySeparatorChar))
            {
                detailedLogFileName = detailedLogFileName.Substring(1);
            }
            if (Environment != LastDetailedEnvironment || DetailedLogStream == null || !DetailedLogStream.CanWrite)
            {
                if (DetailedLogStream != null)
                {
                    try
                    {
                        DetailedLogStream.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (File.Exists(detailedLogFileName))
                {
                    var directory = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                    if (Path.GetFileName(detailedLogFileName) != detailedLogFileName)
                    {
                        directory = Path.GetDirectoryName(detailedLogFileName) + Path.DirectorySeparatorChar;
                    }
                    var oldDetailedLogs = (Directory.GetFiles(directory, Environment + ".detailed.*.log")).ToList();
                    oldDetailedLogs.Sort();
                    oldDetailedLogs.Reverse();
                    foreach (var oldLog in oldDetailedLogs)
                    {
                        try
                        {
                            var fileName = Path.GetFileNameWithoutExtension(oldLog);
                            var prefixLen = (Environment + ".detailed.").Length;
                            var num = int.Parse(fileName.Substring(prefixLen));
                            if (num < 5)
                            {
                                File.Move(oldLog, Path.GetDirectoryName(oldLog) + Path.DirectorySeparatorChar + Environment + ".detailed." + (num + 1) + ".log");
                            }
                            else
                            {
                                File.Delete(oldLog);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    File.Move(detailedLogFileName, directory + Environment + ".detailed.0.log");
                }

                DetailedLogStream = new FileStream(detailedLogFileName, FileMode.Create, FileAccess.Write, FileShare.Read);
                DetailedLogWriter = new StreamWriter(DetailedLogStream);
                LastDetailedEnvironment = Environment;
            }

            if (LogWriter != null || DetailedLogWriter != null)
            {
                var prefix = "";
                if (logType == Type.Warning)
                {
                    prefix = "WARNING: ";
                }
                if (logType == Type.Error)
                {
                    prefix = "ERROR: ";
                }
                var msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] (" + type + "): " + prefix + message;
                if (Verbose)
                {
                    Console.WriteLine(msg);
                }

                // ModAPI.log — 사용자용 핵심 로그
                // detailedOnly = true 인 호출(개발자 전용 상세 로그)은 여기에는 쓰지 않는다.
                if (LogWriter != null && !detailedOnly)
                {
                    LogWriter.WriteLine(msg);
                    LogWriter.Flush();
                    LogStream.Flush();
                }

                // ModAPI.detailed.log — detailedOnly 여부와 관계없이 모든 로그를 항상 기록
                // (Release/Debug 모두 동일하게 기록되므로, 평소엔 숨겨졌던 개발자 로그도
                //  사용자 문제 발생 시 이 파일 하나로 전부 확인 가능)
                if (DetailedLogWriter != null)
                {
                    try
                    {
                        DetailedLogWriter.WriteLine(msg);
                        DetailedLogWriter.Flush();
                        DetailedLogStream.Flush();
                    }
                    catch (Exception)
                    {
                        // 상세 로그 기록 실패는 앱 동작에 영향을 주면 안 되므로 조용히 무시
                    }
                }
            }
        }

        public static void Log(string type, object message, Type logType = Type.Notice, bool detailedOnly = false)
        {
            Log(type, message.ToString(), logType, detailedOnly);
        }
    }
}