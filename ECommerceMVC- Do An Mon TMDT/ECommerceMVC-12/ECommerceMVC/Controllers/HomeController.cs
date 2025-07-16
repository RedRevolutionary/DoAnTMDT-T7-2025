/*using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ECommerceMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}


		[Route("/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        public IActionResult Contact()
        {
            return View(); // Sẽ tự động tìm Views/Home/Contact.cshtml
        }


        [HttpPost]
        public IActionResult SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Code xử lý gửi email/lưu database ở đây
                TempData["SuccessMessage"] = "Gửi thành công! Chúng tôi sẽ liên hệ lại sớm.";
                return RedirectToAction("Contact");
            }
            return View("Contact", model); // Giữ lại giá trị đã nhập nếu có lỗi
        }

        // RSS
        private readonly RssService _rssService;

        public HomeController(RssService rssService)
        {
            _rssService = rssService;
        }

        // Giữ nguyên action Index() gốc
        public IActionResult Index()
        {
            return View();
        }

        // Thêm action mới cho RSS
        public IActionResult RssWidget()
        {
            var feed = _rssService.GetFeed("https://example.com/feed.rss");
            return PartialView("_RssWidget", feed); // Trả về PartialView
        }
    }
}
*/

using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ECommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RssService _rssService;

        // Sửa constructor để inject cả logger và RssService
        public HomeController(ILogger<HomeController> logger, RssService rssService)
        {
            _logger = logger;
            _rssService = rssService;
        }

        // Giữ nguyên action Index gốc
        public IActionResult Index()
        {
            return View();
        }

        [Route("/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Gửi thành công! Chúng tôi sẽ liên hệ lại sớm.";
                return RedirectToAction("Contact");
            }
            return View("Contact", model);
        }

        // Thêm action mới cho RSS
        public IActionResult RssWidget()
        {
            try
            {
                var feed = _rssService.GetFeed("https://vnexpress.net/rss/khoa-hoc-cong-nghe.rss");
                return PartialView("_RssWidget", feed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tải RSS Feed");
                return PartialView("_RssWidgetError");
            }
        }
    }
}