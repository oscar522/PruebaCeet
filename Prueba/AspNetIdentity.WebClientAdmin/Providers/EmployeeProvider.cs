using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplicationClient.Providers
{
    public class EmployeeProvider : BaseProvider
    {
        public EmployeeProvider()
        {
        }
        private string url = "https://localhost:44304/";
        public async Task<string> Get(string Id, string Controller, string Method)
        {
            string uriString = "";
            string _tokenUri = string.Format("{0}api/{1}/", url, Controller);
            if (Id.Equals("0")) {
                uriString = string.Format("{0}{1}", _tokenUri, Method);
            } else {
                uriString = string.Format("{0}{1}/{2}", _tokenUri, Method,Id);
            }
            var response = await Get(uriString);
            return response;
        }

        public async Task<string> Post(IEnumerable<KeyValuePair<string, string>> contentForm, string Controller, string Method)
        {
            string _tokenUri = string.Format("{0}api/{1}/", url, Controller);
            string uriString = string.Format("{0}{1}", _tokenUri, Method);
            var response = await Post(uriString,  contentForm);
            return response;
        }

        public async Task<string> Put(IEnumerable<KeyValuePair<string, string>> contentForm, string Controller, string Method)
        {
            string _tokenUri = string.Format("{0}api/{1}/", url, Controller);
            string uriString = string.Format("{0}{1}", _tokenUri, Method);
            var response = await Put(uriString,  contentForm);
            return response;
        }

        public async Task<string> Delete(string Controller, string Method, string Id)
        {
            string _tokenUri = string.Format("{0}api/{1}/{2}/", url, Controller, Method);
            string uriString = string.Format("{0}{1}", _tokenUri, Id);
            var response = await Delete(uriString);
            return response;
        }

    }
}