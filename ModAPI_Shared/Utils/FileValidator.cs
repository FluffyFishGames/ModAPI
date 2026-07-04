/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 */

using System;
using System.IO;

namespace ModAPI.Utils
{
    /// <summary>
    /// PE 헤더 및 .NET 메타데이터 기반 파일 유효성 검증 유틸리티.
    /// 0바이트 더미 파일, 텍스트 파일, 임의 바이너리 파일을 차단합니다.
    /// </summary>
    public static class FileValidator
    {
        // ── 최소 파일 크기 ────────────────────────────────────────────────
        private const long MinSteamExeBytes = 1 * 1024 * 1024;  // 1 MB
        private const long MinGameExeBytes = 512 * 1024;        // 512 KB
        private const long MinAssemblyBytes = 8 * 1024;           // 8 KB — Unity 소형 DLL (예: Assembly-UnityScript-firstpass.dll ≈ 21 KB) 허용

        // ── 공개 API ──────────────────────────────────────────────────────

        /// <summary>
        /// Steam.exe 유효성 검증.
        /// PE 실행파일 시그니처 + 최소 크기를 확인합니다.
        /// </summary>
        public static bool IsValidSteamExe(string path)
        {
            if (!FileExists(path, MinSteamExeBytes)) return false;
            return HasPeSignature(path);
        }

        /// <summary>
        /// 게임 실행 파일(.exe) 유효성 검증.
        /// PE 실행파일 시그니처 + 최소 크기를 확인합니다.
        /// </summary>
        public static bool IsValidGameExe(string path)
        {
            if (!FileExists(path, MinGameExeBytes)) return false;
            return HasPeSignature(path);
        }

        /// <summary>
        /// 게임 어셈블리 DLL 유효성 검증.
        /// PE 시그니처 + .NET CLR 메타데이터 헤더 + 최소 크기를 확인합니다.
        /// </summary>
        public static bool IsValidAssemblyDll(string path)
        {
            if (!FileExists(path, MinAssemblyBytes)) return false;
            if (!HasPeSignature(path)) return false;
            return HasClrMetadata(path);
        }

        // ── 추가 공개 API ─────────────────────────────────────────────────

        /// <summary>
        /// 게임 어셈블리 DLL MD5 해시 계산.
        /// Versions.xml 체크섬과 비교하여 변조 여부를 확인합니다.
        /// firstpass.dll 이 존재하면 firstpass + Assembly-CSharp 순으로 연결합니다.
        /// </summary>
        public static string ComputeAssemblyChecksum(string gameFolder)
        {
            try
            {
                var managed = System.IO.Path.Combine(gameFolder);
                var primaryDll = System.IO.Path.Combine(managed, "Assembly-CSharp.dll");
                var firstpassDll = System.IO.Path.Combine(managed, "Assembly-CSharp-firstpass.dll");

                if (!File.Exists(primaryDll)) return null;

                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    if (File.Exists(firstpassDll))
                    {
                        // firstpass + Assembly-CSharp 연결 해시 (64자)
                        var h1 = BitConverter.ToString(
                            md5.ComputeHash(File.ReadAllBytes(firstpassDll)))
                            .Replace("-", "").ToLower();
                        md5.Initialize();
                        var h2 = BitConverter.ToString(
                            md5.ComputeHash(File.ReadAllBytes(primaryDll)))
                            .Replace("-", "").ToLower();
                        return h1 + h2;
                    }
                    else
                    {
                        // Assembly-CSharp 단독 해시 (32자)
                        return BitConverter.ToString(
                            md5.ComputeHash(File.ReadAllBytes(primaryDll)))
                            .Replace("-", "").ToLower();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 게임 실행파일 Authenticode 디지털 서명 확인.
        /// 서명이 존재하면 true, 없으면 false 를 반환합니다.
        /// </summary>
        public static bool HasDigitalSignature(string path)
        {
            try
            {
                var cert = System.Security.Cryptography.X509Certificates
                    .X509Certificate.CreateFromSignedFile(path);
                return cert != null;
            }
            catch
            {
                return false;
            }
        }

        // ── 내부 구현 ─────────────────────────────────────────────────────

        /// <summary>파일이 존재하고 최소 크기 이상인지 확인합니다.</summary>
        private static bool FileExists(string path, long minBytes)
        {
            if (string.IsNullOrEmpty(path)) return false;
            if (!File.Exists(path)) return false;
            var info = new FileInfo(path);
            return info.Length >= minBytes;
        }

        /// <summary>
        /// PE 헤더 검증.
        /// [0x00] = MZ (4D 5A)
        /// [0x3C] = PE 헤더 오프셋 (4바이트 리틀 엔디언)
        /// [offset] = PE\0\0 (50 45 00 00)
        /// </summary>
        private static bool HasPeSignature(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var br = new BinaryReader(fs))
                {
                    if (fs.Length < 0x40) return false;

                    // MZ 시그니처 확인
                    var mz = br.ReadUInt16();
                    if (mz != 0x5A4D) return false;  // 'MZ'

                    // PE 헤더 오프셋 읽기 (0x3C 위치)
                    fs.Seek(0x3C, SeekOrigin.Begin);
                    var peOffset = br.ReadInt32();

                    if (peOffset <= 0 || peOffset + 4 > fs.Length) return false;

                    // PE\0\0 시그니처 확인
                    fs.Seek(peOffset, SeekOrigin.Begin);
                    var peSig = br.ReadUInt32();
                    return peSig == 0x00004550;  // 'PE\0\0'
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// .NET CLR 메타데이터 헤더 검증.
        /// Optional Header의 데이터 디렉토리 14번(0x0E번) 항목 —
        /// CLR Runtime Header — 이 비어있지 않으면 .NET 어셈블리입니다.
        /// </summary>
        private static bool HasClrMetadata(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var br = new BinaryReader(fs))
                {
                    if (fs.Length < 0x40) return false;

                    // PE 헤더 오프셋
                    fs.Seek(0x3C, SeekOrigin.Begin);
                    var peOffset = br.ReadInt32();
                    if (peOffset <= 0 || peOffset + 4 > fs.Length) return false;

                    // COFF 파일 헤더 건너뜀 (4 = PE sig, 20 = COFF header)
                    fs.Seek(peOffset + 4 + 20, SeekOrigin.Begin);

                    // Optional Header Magic 확인 (PE32=0x10B, PE32+=0x20B)
                    var magic = br.ReadUInt16();
                    int clrOffset;
                    if (magic == 0x10B)       // PE32
                        clrOffset = peOffset + 4 + 20 + 2 + 206;  // 14번 데이터 디렉토리
                    else if (magic == 0x20B)  // PE32+
                        clrOffset = peOffset + 4 + 20 + 2 + 222;
                    else
                        return false;

                    if (clrOffset + 8 > fs.Length) return false;

                    fs.Seek(clrOffset, SeekOrigin.Begin);
                    var clrRva = br.ReadUInt32();  // CLR Header RVA
                    var clrSize = br.ReadUInt32();  // CLR Header Size

                    // RVA와 Size 모두 0이 아니면 .NET 어셈블리
                    return clrRva != 0 && clrSize != 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}