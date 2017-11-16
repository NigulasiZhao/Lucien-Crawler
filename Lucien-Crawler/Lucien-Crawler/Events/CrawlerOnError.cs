using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucien_Crawler.Events
{
    public class CrawlerOnError
    {
        public Uri Url { get; set; }

        public Exception Exception { get; set; }

        public CrawlerOnError(Uri url, Exception exception)
        {
            this.Url = url;
            this.Exception = exception;
        }
    }
}
