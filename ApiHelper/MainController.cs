using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class MainController
    {
        private ApiRequest apiRequest;

        private UrlReader reader;

        private HttpUtil httpUtil;

        private bool sendRequest;

        public bool UseFixedUrl { get; set; }

        public string FixedUrl { get; set; }

        public MainController()
        {
            this.apiRequest = new ApiRequest();
            this.reader = new UrlReader();
            this.httpUtil = new HttpUtil();
            this.sendRequest = false;
        }

        public void SetHost(string host)
        {
            this.apiRequest.Host = host;
        }

        public void SetPath(string path)
        {
            this.apiRequest.Path = path;
        }

        public void SetFormat(string format)
        {
            this.apiRequest.Format = format;
        }

        public void SetParam(bool useTestHooks)
        {
            this.apiRequest.UseTestHooks = useTestHooks;
        }

        public void SetSendRequest(bool sendRequest)
        {
            this.sendRequest = sendRequest;
        }

        public string GenerateApiRequest()
        {
            if (this.UseFixedUrl)
            {
                this.apiRequest.HandleUrl = this.FixedUrl;
            }
            else
            {
                this.apiRequest.HandleUrl = this.reader.FetchOneUrl();
            }
            string requestUrl = this.apiRequest.ToString();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(requestUrl);
          
            if (this.sendRequest)
            {
                builder.AppendLine();
                builder.AppendLine("------------------------------------------------------------------------------------------");
                builder.AppendLine();
                string result = this.httpUtil.GetResponse(requestUrl);
                builder.AppendLine(result);
            }

            return builder.ToString();
        }
    }
}
