using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPadrao.CrossCutting.Commons.Util
{
    public class BaseHttpResponseMessage
    {
        public const string ContentType = "Content-Type";
        public const string ApplicationJson = "application/json";
        public static Dictionary<string, string> ContentTypeApplicationJson = new Dictionary<string, string> { { ContentType, ApplicationJson } };

        protected HttpResponseMessage PostlEncodedAsync(string pathUrl, string requestUri, IDictionary<string, string> data, IDictionary<string, string> header = null)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(pathUrl);
                using (var content = new FormUrlEncodedContent(data))
                {
                    if (header != null)
                    {
                        foreach (var item in header)
                            client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));
                    var response = client.PostAsync(requestUri, content).Result;
                    return response;
                }
            }
        }

        protected HttpResponseMessage PostAsync(string pathUrl, string requestUri, object data = null, IDictionary<string, string> header = null, string contentType = ApplicationJson, bool ignoreNullPropertiesOnJsonSerialization = false)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(pathUrl);
                if (header != null)
                {
                    foreach (var item in header)
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
                string json = null;

                if (ignoreNullPropertiesOnJsonSerialization)
                {
                    json = JsonConvert.SerializeObject((data == null) ? header : data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                }
                else
                {
                    json = JsonConvert.SerializeObject((data == null) ? header : data);
                }
                using (var content = new StringContent(json, UnicodeEncoding.UTF8, contentType))
                {
                    var result = client.PostAsync(requestUri, content).Result;
                    return result;
                }
            }
        }

        protected HttpResponseMessage PostParamAsync(string pathUrl, string requestUri, object data = null, IDictionary<string, string> header = null, string contentType = ApplicationJson, bool ignoreNullPropertiesOnJsonSerialization = false)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                if (header != null)
                {
                    foreach (var item in header)
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var result = client.PostAsync(new Uri(string.Format("{0}{1}{2}", pathUrl, requestUri, data)), null).Result;
                return result;

            }
        }

        protected HttpResponseMessage GetAsync(string pathUrl, string requestUri, object data = null, IDictionary<string, string> header = null)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            HttpResponseMessage response = new HttpResponseMessage();

            using (HttpClient client = new HttpClient(handler))
            {
                if (header != null)
                {
                    foreach (var item in header)
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
                var baseUrl = (data == null) ? string.Format("{0}{1}", pathUrl, requestUri) : string.Format("{0}{1}{2}", pathUrl, requestUri, data);
                response = client.GetAsync(baseUrl).Result;
                response.EnsureSuccessStatusCode();
            }

            return response;
        }

        protected T GetResponse<T>(HttpResponseMessage response) where T : class
        {
            var jsonResult = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public static T GetResponse<T>(dynamic response) where T : class
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
