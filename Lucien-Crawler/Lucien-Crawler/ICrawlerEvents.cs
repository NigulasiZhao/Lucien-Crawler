using Lucien_Crawler.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucien_Crawler
{
    public interface ICrawlerEvents
    {
        event EventHandler<CralwerOnStart> OnStart;//爬虫启动事件

        event EventHandler<CrawlerOnComplete> OnCompleted;//爬虫完成事件

        event EventHandler<CrawlerOnError> OnError;//爬虫出错事件

        Task<string> Start(Uri uri, string proxy); //异步爬虫
    }
}
