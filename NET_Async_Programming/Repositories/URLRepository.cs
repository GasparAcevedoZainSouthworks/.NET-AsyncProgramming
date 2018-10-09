using System;
using System.Collections.Generic;

namespace NET_Async_Programming.Repositories
{
    public class URLRepository
    {
        private static readonly URLRepository repository = new URLRepository();

        private IEnumerable<string> urlList;

        private URLRepository()
        {
            this.urlList = new List<string>
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/library/hh290136.aspx",
                "http://msdn.microsoft.com/library/ee256749.aspx",
                "http://msdn.microsoft.com/library/hh290138.aspx",
                "http://msdn.microsoft.com/library/hh290140.aspx",
                "http://msdn.microsoft.com/library/dd470362.aspx",
                "http://msdn.microsoft.com/library/aa578028.aspx",
                "http://msdn.microsoft.com/library/ms404677.aspx",
                "http://msdn.microsoft.com/library/ff730837.aspx"
            };
        }

        public static URLRepository GetRepository()
        {
            return repository;
        }

        public IEnumerable<string> GetURLs()
        {
            return this.urlList;
        }
    }
}