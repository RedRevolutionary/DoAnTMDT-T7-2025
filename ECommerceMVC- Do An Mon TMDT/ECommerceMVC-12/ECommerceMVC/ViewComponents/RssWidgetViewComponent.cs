using Microsoft.AspNetCore.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;

public class RssWidgetViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        try
        {
            using var reader = XmlReader.Create("https://vnexpress.net/rss/khoa-hoc-cong-nghe.rss");
            var feed = SyndicationFeed.Load(reader);
            return View(feed);
        }
        catch
        {
            return Content("<p>Không thể tải RSS</p>");
        }
    }
}