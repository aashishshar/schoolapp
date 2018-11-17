using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace APP_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:50123";

            // string baseAddress = "http://localhost:4312";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "ankita"},
                   {"password", "Pass@123"},
               };
                var tokenResponse = client.PostAsync("/Token", new FormUrlEncodedContent(form)).Result;
                //var token = tokenResponse.Content.ReadAsStringAsync().Result;  
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                if (string.IsNullOrEmpty(token.Error))
                {
                    Console.WriteLine("Token issued is: {0}", token.AccessToken);
                }
                else
                {
                    Console.WriteLine("Error : {0}", token.Error);
                }
               // Console.Read();

               // 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
                HttpResponseMessage response = client.GetAsync("/api/Account/UserInfo").Result;
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Success");
                }
                string message = response.Content.ReadAsStringAsync().Result;
                System.Console.WriteLine("URL responese : " + message);
            }
        }


    }
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
