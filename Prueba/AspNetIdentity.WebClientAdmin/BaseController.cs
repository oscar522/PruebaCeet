using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin
{
    public class BaseController : Controller
    {
        private HttpClient _client;
        public string WebApiUri = String.Empty;
        public HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return _client;
            }

            set
            {
                _client = value;
            }
        }

        private string _bearerToken;
        internal string bearerToken
        {
            get
            {
                if (string.IsNullOrEmpty(_bearerToken))
                {
                    if (Request.Cookies["5XCUmffguLUnf5UD"] != null)
                    {
                        _bearerToken = Request.Cookies["5XCUmffguLUnf5UD"].Value;
                    }
                }

                return _bearerToken;
            }
            set
            {
                _bearerToken = value;
            }
        }

        public BaseController()
        {
            WebApiUri = System.Configuration.ConfigurationManager.AppSettings["WebApiUri"];
        }

        public BTObject GetTokenObject()
        {
            // decode payload
            return this.DecodePayload(bearerToken);
        }

        private BTObject DecodePayload(string token)
        {
            var parts = token.Split('.');
            var payload = parts[1];

            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
            JObject jObject = JObject.Parse(payloadJson);

            return jObject.ToObject<BTObject>();
        }

        private byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }
    }

    

    public class BTObject
    {
        public string nameid { get; set; }
        public string[] roles { get; set; }
    }
}