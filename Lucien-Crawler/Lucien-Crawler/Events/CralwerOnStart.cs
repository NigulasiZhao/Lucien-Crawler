using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucien_Crawler.Events
{
    public class CralwerOnStart
    {
        public Uri Url { get; set; }// 爬虫URL地址

        public CralwerOnStart(Uri url)
        {
            this.Url = url;
        }
    }
}
