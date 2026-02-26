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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Web;
using ModAPI.Configurations;

namespace ModAPI.Utils
{
    public class WebService
    {
        public delegate void _OnDoLogin();

        public delegate void _OnLogin(User user);

        public delegate void _OnLogout();

        public delegate void _OnLoginError(int errorNum, string errorText);

        public static _OnLoginError OnLoginError;
        public static _OnDoLogin OnDoLogin;
        public static _OnLogin OnLogin;
        public static _OnLogout OnLogout;
        public static User CurrentUser;

        protected static string CurrentSessionId = "";
        protected static int UserId;
        protected static string Hash = "";

        /// <summary>
        /// Checks if there is an old long time session and verifies it based on the hardware and system configuration.
        /// </summary>
        protected static void CheckSession()
        {
            try
            {
                UserId = int.Parse(Configuration.GetString("Login.User"));
                Hash = Configuration.GetString("Login.Hash");
            }
            catch (Exception e)
            {
            }
            if (UserId > 0 && Hash != null && Hash != "")
            {
                OnDoLogin?.Invoke();
                GetUserInformation();
                /*new Request()
                {
                    Path = "Login",
                    Method = "POST",
                    ResponseType = typeof(LoginResponse),
                    Parameters = new string[] { "userid=" + User, "hash=" + Hash }
                }.Send(delegate(Response _response)
                {
                    if (_response != null)
                    {
                        LoginResponse response = (LoginResponse)_response;
                        if (response.Header.Status == "OK")
                        {
                            if (response.Header.UserID != null)
                            {
                                UserID = int.Parse(response.Header.UserID);
                                GetUserInformation();
                                return;
                            }
                        }
                    }
                    if (OnLogout != null)
                        OnLogout();

                });*/
            }
        }

        public static void Initialize()
        {
            // Legacy login system disabled - backend (modapi.cc) no longer exists
            // CheckSession() removed to prevent dead HTTP calls on startup
        }

        public static void Login(string username, string password)
        {
            OnDoLogin?.Invoke();
            new Request
            {
                Path = "Login",
                Method = "POST",
                ResponseType = typeof(LoginResponse),
                Parameters = new[] { "username=" + username, "password=" + password }
            }.Send(delegate (Response _response)
            {
                if (_response != null)
                {
                    var response = (LoginResponse)_response;
                    if (response.Header.Status == "OK")
                    {
                        if (response.Header.UserId != null)
                        {
                            UserId = int.Parse(response.Header.UserId);
                            Hash = response.Body.Hash;
                            Console.WriteLine(UserId);
                            Console.WriteLine(Hash);

                            Configuration.SetString("Login.User", response.Header.UserId, true);
                            Configuration.SetString("Login.Hash", response.Body.Hash, true);
                            Configuration.Save();
                            GetUserInformation();
                        }
                    }
                    else
                    {
                        OnLoginError(int.Parse(response.Header.Error.Num), response.Header.Error.Text);
                    }
                }
            });
        }

        protected static void GetUserInformation()
        {
            if (UserId > 0)
            {
                Console.WriteLine(CurrentSessionId);

                new Request
                {
                    Path = "User/Info",
                    Method = "GET",
                    ResponseType = typeof(UserDataResponse),
                    Parameters = new[] { "id=" + UserId }
                }.Send(delegate (Response _response)
                {
                    if (_response != null)
                    {
                        var response = (UserDataResponse)_response;

                        if (response.Header.Status == "OK")
                        {
                            CurrentUser = new User(response);
                            if (OnLogin != null)
                            {
                                OnLogin.Invoke(CurrentUser);
                            }
                        }
                        else
                        {
                            if (OnLogout != null)
                            {
                                OnLogout.Invoke();
                            }
                        }
                    }
                });
            }
        }

        public static void Logout()
        {
            new Request
            {
                Path = "Logout",
                Method = "POST",
                ResponseType = typeof(LogoutResponse),
                Parameters = new string[] { }
            }.Send(delegate { });
            Hash = "";
            UserId = 0;
            Configuration.SetString("Login.User", "", true);
            Configuration.SetString("Login.Hash", "", true);
            Configuration.Save();
            OnLogout?.Invoke();
        }

        public class User
        {
            public string Id;
            public string Username;
            public string AvatarUrl;
            public string Usergroup;

            public MemoryStream Avatar;

            public delegate void AvatarChange();

            public AvatarChange OnAvatarChange;

            public User(UserDataResponse responseData)
            {
                Id = responseData.Body.UserId;
                Username = responseData.Body.Username;
                AvatarUrl = responseData.Body.AvatarUrl;
                Usergroup = responseData.Body.Group;
            }

            public void LoadAvatar()
            {
                var t = new Thread(
                    delegate ()
                    {
                        if (AvatarUrl.EndsWith(".jpg"))
                        {
                            var buffer = new byte[1024];

                            var httpRequest = (HttpWebRequest)WebRequest.Create(AvatarUrl);
                            httpRequest.Timeout = 30000;
                            httpRequest.Method = "GET";
                            httpRequest.UserAgent = "ModAPI";
                            httpRequest.Accept = "image/jpeg";
                            httpRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
                            Console.WriteLine(AvatarUrl);
                            using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                            {
                                using (var responseStream = httpResponse.GetResponseStream())
                                {
                                    var memStream = new MemoryStream();
                                    int bytesRead;
                                    while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        memStream.Write(buffer, 0, bytesRead);
                                    }
                                    memStream.Seek(0, SeekOrigin.Begin);
                                    Avatar = memStream;
                                }
                            }
                        }
                        OnAvatarChange?.Invoke();
                    });
                t.Start();
            }
        }

        [DataContract]
        public class Response
        {
            [DataMember]
            public ResponseHeader Header;
        }

        [DataContract]
        public class LoginResponse : Response
        {
            [DataMember]
            public LoginResponseBody Body;

            [DataContract]
            public class LoginResponseBody
            {
                [DataMember]
                public string Hash;
            }
        }

        [DataContract]
        public class UserDataResponse : Response
        {
            [DataMember]
            public UserDataResponseBody Body;

            [DataContract]
            public class UserDataResponseBody
            {
                [DataMember]
                public string UserId;
                [DataMember]
                public string Username;
                [DataMember]
                public string Group;
                [DataMember]
                public string AvatarUrl;
            }
        }

        [DataContract]
        public class LogoutResponse : Response
        {
            [DataMember]
            public LogoutResponseBody Body;

            [DataContract]
            public class LogoutResponseBody
            {
            }
        }

        [DataContract]
        public class ResponseHeader
        {
            [DataMember]
            public string Status;
            [DataMember]
            public string SessionId;
            [DataMember]
            public string UserId;
            [DataMember]
            public ResponseError Error = new ResponseError();
        }

        [DataContract]
        public class ResponseError
        {
            [DataMember]
            public string Num;
            [DataMember]
            public string Text;
        }

        public class Request
        {
            // Legacy backend - no longer operational
            protected const string BackendUrl = "https://www.modapi.cc/external.php/";
            public string Path;
            public string Method;
            public Type ResponseType;
            public string[] Parameters;

            public delegate void OnResponse(Response response);

            protected static List<Request> RequestChain = new List<Request>();
            protected OnResponse ResponseHandler;
            protected static bool ServingRequest;

            public void Send(OnResponse responseHandler)
            {
                if (responseHandler == null)
                {
                    return;
                }
                ResponseHandler = responseHandler;
                RequestChain.Add(this);
                ExecuteChain();
            }

            protected static void ExecuteChain()
            {
                if (RequestChain.Count > 0)
                {
                    if (!ServingRequest)
                    {
                        RequestChain[0].Execute();
                        RequestChain.RemoveAt(0);
                        ServingRequest = true;
                    }
                }
            }

            protected static void RequestCompleted()
            {
                ServingRequest = false;
                ExecuteChain();
            }

            protected void Execute()
            {
                var requestThread = new Thread(delegate ()
                {
                    try
                    {
                        var url = BackendUrl + Path + "?s=" + CurrentSessionId;
                        var data = "";
                        foreach (var i in Parameters)
                        {
                            var p = i.Split(new[] { "=" }, StringSplitOptions.None);
                            if (p.Length == 2)
                            {
                                data += "&" + HttpUtility.UrlEncode(p[0]) + "=" + HttpUtility.UrlEncode(p[1]);
                            }
                        }
                        if (Method == "GET")
                        {
                            url += data;
                        }
                        var request = (HttpWebRequest)HttpWebRequest.Create(url);
                        request.CookieContainer = new CookieContainer(3);
                        request.CookieContainer.Add(new Cookie("wcf_cookieHash", CurrentSessionId, "/", ".www.modapi.cc"));
                        request.CookieContainer.Add(new Cookie("wcf_userID", UserId + "", "/", ".www.modapi.cc"));
                        request.CookieContainer.Add(new Cookie("wcf_password", Hash, "/", ".www.modapi.cc"));
                        request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
                        request.UserAgent = "ModAPI";
                        if (Method == "POST")
                        {
                            request.Method = "POST";
                            request.ContentType = "application/x-www-form-urlencoded";
                            if (data.Length > 1)
                            {
                                var postData = data.Substring(1);
                                var postBytes = Encoding.UTF8.GetBytes(postData);
                                request.ContentLength = postBytes.Length;
                                var dataStream = request.GetRequestStream();
                                dataStream.Write(postBytes, 0, postBytes.Length);
                                dataStream.Close();
                            }
                        }

                        var response = (HttpWebResponse)request.GetResponse();
                        var responseStream = response.GetResponseStream();

                        var serializer = new DataContractJsonSerializer(ResponseType);
                        var obj = (Response)serializer.ReadObject(responseStream);

                        if (obj.Header != null && obj.Header.SessionId != null)
                        {
                            CurrentSessionId = obj.Header.SessionId;
                            if (obj.Header.Status != null)
                            {
                                ResponseHandler.Invoke(obj);
                                RequestCompleted();
                                return;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    ResponseHandler.Invoke(null);
                    RequestCompleted();
                });
                requestThread.Start();
            }
        }
    }
}