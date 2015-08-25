using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class ApiRequest
    {
        private const string ApiRequestTemplate = "http://{0}/{1}?appid=D41D8CD98F00B204E9800998ECF8427E1510C791&adlt=strict&format={2}{3}&q=url:{4}";

        public string Host { get; set; }

        public string Path { get; set; }

        public string Format { get; set; }

        public bool UseTestHooks { get; set; }

        public string HandleUrl { get; set; }

        public override string ToString()
        {
            return string.Format(ApiRequestTemplate, Host, Path, Format, UseTestHooks ? "&testhooks=1" : string.Empty, HandleUrl);
        }
    }
}