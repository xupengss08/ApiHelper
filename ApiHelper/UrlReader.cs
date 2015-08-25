using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace ApiHelper
{
    public class UrlReader
    {
        private const string urlPath = "urls.txt";
        private List<string> urlList;

        public UrlReader()
        {
            urlList = new List<string>();
            using (StreamReader reader = new StreamReader(urlPath))
            {
                while (!reader.EndOfStream)
                {
                    urlList.Add(HttpUtility.UrlEncode(reader.ReadLine().Trim()));
                }
            }
        }

        public string FetchOneUrl()
        {
            Random random = new Random();
            int index = random.Next(urlList.Count);
            return urlList[index];
        }
    }
}
