using Lucien_Crawler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucien_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试代理IP是否生效：http://1212.ip138.com/ic.asp

            //测试当前爬虫的User-Agent：http://www.whatismyuseragent.net

            //1.抓取频道
            CityCrawler();

            Console.ReadKey();
        }
        /// <summary>
        /// 抓取频道列表
        /// </summary>
        public static void CityCrawler()
        {

            var VideoUrl = "http://www.acfun.cn/";//定义爬虫入口URL
            var VideoList = new List<VideoList>();//定义泛型列表存放频道名称及对应的URL
            var Crawler = new CrawlerEvents();//调用刚才写的爬虫程序
            Crawler.OnStart += (s, e) =>
            {
                Console.WriteLine("爬虫开始抓取地址：" + e.Url.ToString());
            };
            Crawler.OnError += (s, e) =>
            {
                Console.WriteLine("爬虫抓取出现错误：" + e.Url.ToString() + "，异常消息：" + e.Exception.Message);
            };
            Crawler.OnCompleted += (s, e) =>
            {
                //使用正则表达式清洗网页源代码中的数据
                var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>/v/[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);
                foreach (Match match in links)
                {
                    var VideoModel = new VideoList
                    {
                        RegionName = match.Groups["text"].Value,
                        Url = new Uri("http://www.acfun.cn" + match.Groups["href"].Value
                    )
                    };
                    if (!VideoList.Contains(VideoModel)) VideoList.Add(VideoModel);//将数据加入到泛型列表
                    Console.WriteLine(VideoModel.RegionName + "|" + VideoModel.Url);//将频道名称及URL显示到控制台
                }
                Console.WriteLine("===============================================");
                Console.WriteLine("爬虫抓取任务完成！合计 " + links.Count + " 个频道。");
                Console.WriteLine("耗时：" + e.Milliseconds + "毫秒");
                Console.WriteLine("线程：" + e.ThreadId);
                Console.WriteLine("地址：" + e.Url.ToString());

            };
            Crawler.Start(new Uri(VideoUrl)).Wait();//没被封锁就别使用代理：60.221.50.118:8090
        }

    }
}
