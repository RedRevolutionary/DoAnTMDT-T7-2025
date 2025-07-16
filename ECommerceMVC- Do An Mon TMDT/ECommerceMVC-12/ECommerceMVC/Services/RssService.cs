// Services/RssService.cs
using System.ServiceModel.Syndication;
using System.Xml;

public class RssService
{
    public SyndicationFeed? GetFeed(string url)
    {
        try
        {
            using var reader = XmlReader.Create(url);
            return SyndicationFeed.Load(reader);
        }
        catch
        {
            return null; // Xử lý lỗi gọn gàng
        }
    }
}