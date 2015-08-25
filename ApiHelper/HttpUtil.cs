using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ApiHelper
{
    public class HttpUtil
    {
        private static string ERROR_MSG = "404 Not Found";

        private static int REQUEST_TIMEOUT = 2000;

        public string GetResponse(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = HttpUtil.REQUEST_TIMEOUT;
                var response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return HttpUtil.ERROR_MSG;
            }
        }

        public async Task<string> GetResponseAsync(string url)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Method = "GET";
            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
            var responseStream = responseObject.GetResponseStream();
            var sr = new StreamReader(responseStream);
            string received = await sr.ReadToEndAsync();
            return received;
        }
    }
}
