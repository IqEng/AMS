using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;

namespace AMS
{
    public class PostAPI
    {
        String ApiKey = ConfigurationManager.AppSettings["Kripton_Key"].ToString().Trim(); String ApiPoint = ConfigurationManager.AppSettings["Kripta_Link"].ToString().Trim();

        public static void InitializeSecurityProtocol()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable get_datatable(string method, string JsonOutput, string meth_)
        {
            InitializeSecurityProtocol();
            DataTable dt = new DataTable();
            try
            {
                Uri lnk = new Uri(ApiPoint + "api/AMS/" + method);
                var http = (HttpWebRequest)WebRequest.Create(lnk);
                http.KeepAlive = true;
                http.PreAuthenticate = true;
                http.AllowAutoRedirect = true;
                http.ContentType = "application/json";
                http.Accept = "application/json";
                http.Method = meth_.ToUpper();
                http.Headers["AMS_KEY"] = ApiKey;

                byte[] bytes = Encoding.ASCII.GetBytes(JsonOutput);
                http.ContentLength = bytes.Length;

                // Write the request stream
                using (Stream newStream = http.GetRequestStream())
                {
                    newStream.Write(bytes, 0, bytes.Length);
                }

                // Get the response
                using (HttpWebResponse response = (HttpWebResponse)http.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string result = sr.ReadToEnd().Trim();

                        // Deserialize the JSON response into a DataTable
                        dt = JsonConvert.DeserializeObject<DataTable>(result);

                        // Log the result for debugging
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for diagnostics
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string get_string(string method, string JsonOutput, string meth_)
        {
            InitializeSecurityProtocol(); // Ensure TLS 1.2 is used
            string result = "";
            try
            {
                Uri lnk = new Uri(ApiPoint + "api/AMS/" + method);
                var http = (HttpWebRequest)WebRequest.Create(lnk);
                http.KeepAlive = true;
                http.PreAuthenticate = true;
                http.AllowAutoRedirect = true;
                http.ContentType = "application/json";
                http.Method = meth_.ToUpper();

                // Check if the method requires a request body
                if (http.Method == "POST" || http.Method == "PUT")
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] bytes = encoding.GetBytes(JsonOutput);
                    http.ContentLength = bytes.Length;
                    http.Headers["AMS_KEY"] = ApiKey;
                    http.Accept = "application/json";
                    http.Headers["Cache-Control"] = "no-cache";

                    using (Stream newStream = http.GetRequestStream())
                    {
                        newStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse)http.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        result = sr.ReadToEnd().Trim();
                    }
                }
            }
            catch (WebException e)
            {
                // Log detailed error information
                string errorMessage = "WebException: " + e.Message;
                if (e.Response != null)
                {
                    using (var response = (HttpWebResponse)e.Response)
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        errorMessage += $" | Status Code: {response.StatusCode} | Error Response: {errorResponse}";
                    }
                }
                return errorMessage;
            }
            return result;
        }

        public string gAPIRequest(string result_)
        {
            try
            {
                Uri lnk = new Uri("https://www.google.com/recaptcha/api/siteverify?secret=" + "6LfnczUeAAAAAFem7LGtdKTfNoc6YIpDJt7VzZnB" + "&&response=" + result_);
                var http = (HttpWebRequest)WebRequest.Create(lnk);
                http.KeepAlive = true;
                http.PreAuthenticate = true;
                http.AllowAutoRedirect = true;
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.MediaType = "application/json";
                http.Method = "POST";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytes = encoding.GetBytes(lnk.AbsoluteUri);
                http.ContentLength = bytes.Length;
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);

                string result = "";
                using ((HttpWebResponse)http.GetResponse())
                {
                    StreamReader sr = new StreamReader(http.GetResponse().GetResponseStream());
                    result = sr.ReadToEnd().Trim();
                    string[] resultCollection = Regex.Split(result, ",");

                    if (result.ToString().ToUpper().Contains("true"))
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}