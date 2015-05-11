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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Net;
using System.Threading;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

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

        protected static string CurrentSessionID = "";
        protected static int UserID = 0;
        protected static string Hash = "";

        /// <summary>
        /// Checks if there is an old long time session and verifies it based on the hardware and system configuration.
        /// </summary>
        protected static void CheckSession()
        {
            try
            {
                UserID = int.Parse(ModAPI.Configurations.Configuration.GetString("Login.User"));
                Hash = ModAPI.Configurations.Configuration.GetString("Login.Hash");
            } 
            catch (Exception e)
            {

            }
            if (UserID > 0 && Hash != null && Hash != "")
            {
                if (OnDoLogin != null)
                    OnDoLogin();
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
            CheckSession();
        }

        public static void Login(string username, string password)
        {
            if (OnDoLogin != null)
                OnDoLogin();
            new Request()
            {
                Path = "Login",
                Method = "POST",
                ResponseType = typeof(LoginResponse),
                Parameters = new string[] { "username=" + username, "password=" + password }
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
                            Hash = response.Body.Hash;
                            System.Console.WriteLine(UserID);
                            System.Console.WriteLine(Hash);

                            ModAPI.Configurations.Configuration.SetString("Login.User", response.Header.UserID, true);
                            ModAPI.Configurations.Configuration.SetString("Login.Hash", response.Body.Hash, true);
                            ModAPI.Configurations.Configuration.Save();
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
            if (UserID > 0)
            {
                System.Console.WriteLine(CurrentSessionID);
                        
                new Request()
                {
                    Path = "User/Info",
                    Method = "GET",
                    ResponseType = typeof(UserDataResponse),
                    Parameters = new string[] { "id=" + UserID }
                }.Send(delegate(Response _response)
                {
                    if (_response != null)
                    {
                        UserDataResponse response = (UserDataResponse)_response;

                        if (response.Header.Status == "OK")
                        {
                            CurrentUser = new User(response);
                            if (OnLogin != null)
                                OnLogin.Invoke(CurrentUser);
                        }
                        else
                        {
                            if (OnLogout != null)
                                OnLogout.Invoke();
                        }
                    }
                });
            }
        }

        public static void Logout()
        {
            new Request()
            {
                Path = "Logout",
                Method = "POST",
                ResponseType = typeof(LogoutResponse),
                Parameters = new string[] { }
            }.Send(delegate(Response response)
            {
            });
            Hash = "";
            UserID = 0;
            ModAPI.Configurations.Configuration.SetString("Login.User", "", true);
            ModAPI.Configurations.Configuration.SetString("Login.Hash", "", true);
            ModAPI.Configurations.Configuration.Save();
            if (OnLogout != null)
                OnLogout();
        }

        public class User
        {
            public string ID;
            public string Username;
            public string AvatarURL;
            public string Usergroup;

            public MemoryStream Avatar;

            public delegate void AvatarChange();
            public AvatarChange OnAvatarChange;

            public User(UserDataResponse responseData)
            {
                this.ID = responseData.Body.UserID;
                this.Username = responseData.Body.Username;
                this.AvatarURL = responseData.Body.AvatarURL;
                this.Usergroup = responseData.Body.Group;
            }

            public void LoadAvatar()
            {
                Thread t = new Thread(
                    delegate() {
                        if (AvatarURL.EndsWith(".jpg"))
                        {
                            byte[] buffer = new byte[1024];

                            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(AvatarURL);
                            httpRequest.Timeout = 30000;
                            httpRequest.Method = "GET";
                            httpRequest.UserAgent = "ModAPI";
                            httpRequest.Accept = "image/jpeg";
                            httpRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
                            System.Console.WriteLine(AvatarURL);
                            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                            {
                                using (Stream responseStream = httpResponse.GetResponseStream())
                                {
                                    MemoryStream memStream = new MemoryStream();
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
                        if (OnAvatarChange != null)
                            OnAvatarChange();
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
                public string UserID;
                [DataMember]
                public string Username;
                [DataMember]
                public string Group;
                [DataMember]
                public string AvatarURL;
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
            public string SessionID;
            [DataMember]
            public string UserID;
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
            protected const string BACKEND_URL = "https://www.modapi.de/external.php/";
            public string Path;
            public string Method;
            public Type ResponseType;
            public string[] Parameters;
            public delegate void OnResponse(Response response);
            protected static List<Request> RequestChain = new List<Request>();
            protected OnResponse ResponseHandler;
            protected static bool ServingRequest = false;

            public void Send(OnResponse responseHandler)
            {
                if (responseHandler == null) return;
                ResponseHandler = responseHandler;
                Request.RequestChain.Add(this);
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
                Thread requestThread = new Thread(delegate()
                {
                    try
                    {
                        string url = BACKEND_URL + Path + "?s=" + WebService.CurrentSessionID;
                        string data = "";
                        foreach (string i in Parameters)
                        {
                            string[] p = i.Split(new string[] { "=" }, StringSplitOptions.None);
                            if (p.Length == 2)
                                data += "&" + HttpUtility.UrlEncode(p[0]) + "=" + HttpUtility.UrlEncode(p[1]);
                        }
                        if (Method == "GET")
                        {
                            url += data;
                        }
                        HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
                        request.CookieContainer = new CookieContainer(3);
                        request.CookieContainer.Add(new Cookie("wcf_cookieHash", WebService.CurrentSessionID, "/", ".www.modapi.de"));
                        request.CookieContainer.Add(new Cookie("wcf_userID", WebService.UserID + "", "/", ".www.modapi.de"));
                        request.CookieContainer.Add(new Cookie("wcf_password", WebService.Hash, "/", ".www.modapi.de"));
                        request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
                        request.UserAgent = "ModAPI";
                        if (Method == "POST")
                        {
                            request.Method = "POST";
                            request.ContentType = "application/x-www-form-urlencoded";
                            if (data.Length > 1)
                            {
                                string postData = data.Substring(1);
                                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                                request.ContentLength = postBytes.Length;
                                Stream dataStream = request.GetRequestStream();
                                dataStream.Write(postBytes, 0, postBytes.Length);
                                dataStream.Close();
                            }
                        }

                        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(ResponseType);
                        Response obj = (Response) serializer.ReadObject(responseStream);
                        
                        if (obj.Header != null && obj.Header.SessionID != null)
                        {
                            WebService.CurrentSessionID = obj.Header.SessionID;
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
                        System.Console.WriteLine(e.ToString());
                    }
                    ResponseHandler.Invoke(null);
                    RequestCompleted();
                });
                requestThread.Start();
            }
        }
    }
}
