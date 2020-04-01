using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApplicationClient.Providers
{
    public class BaseProvider
    {
        internal async Task<string> Get(string uriString)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(uriString);

                var response = await client.GetAsync(string.Empty);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        internal async Task<string> Post(string uriString, IEnumerable<KeyValuePair<string, string>> contentForm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString);

                var content = new FormUrlEncodedContent(contentForm);
                var response = await client.PostAsync(string.Empty, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        internal async Task<string> Put(string uriString, IEnumerable<KeyValuePair<string, string>> contentForm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString);

                var content = new FormUrlEncodedContent(contentForm);
                var response = await client.PutAsync(string.Empty, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        internal async Task<string> Delete(string uriString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString);

                var response = await client.DeleteAsync(string.Empty);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}