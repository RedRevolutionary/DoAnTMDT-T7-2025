using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ServiceModel.Syndication;
using System.Xml;

public class RssController : Controller
{
    private readonly IMemoryCache _cache;
    private const string CacheKey = "RssFeed";

    public RssController(IMemoryCache cache)
    {
        _cache = cache;
    }

    [ResponseCache(Duration = 3600)]
    public IActionResult Index()
    {
        try
        {
            if (!_cache.TryGetValue(CacheKey, out SyndicationFeed feed))
            {
                string rssUrl = "https://example.com/feed.rss";
                using (var reader = XmlReader.Create(rssUrl))
                {
                    feed = SyndicationFeed.Load(reader);
                    _cache.Set(CacheKey, feed, TimeSpan.FromHours(1));
                }
            }
            return View(feed);
        }
        catch (Exception ex)
        {
            // Log lỗi ở đây
            return View("Error");
        }
    }
}