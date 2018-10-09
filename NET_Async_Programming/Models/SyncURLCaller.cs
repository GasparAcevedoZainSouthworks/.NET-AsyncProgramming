using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace NET_Async_Programming.Models
{
    public class SyncURLCaller
    {
        private IEnumerable<string> urlList;

        public SyncURLCaller(IEnumerable<string> urlList)
        {
            this.urlList = urlList;
        }

        public long CallMultipleURL()
        {
            return ProcessUrlList(urlList);
        }

        private long ProcessUrlList(IEnumerable<string> list)
        {
            return list.Select(x => ProcessUrl(x)).Sum(x => x);
        }

        private long ProcessUrl(string url)
        {
            var content = new System.IO.MemoryStream();

            var webRequest = (System.Net.HttpWebRequest)WebRequest.Create(url);

            using(WebResponse response = webRequest.GetResponse())
            {
                using(Stream responseStream = response.GetResponseStream())
                {
                    responseStream.CopyTo(content);
                }
            }

            return content.Length;
        }
    }
}