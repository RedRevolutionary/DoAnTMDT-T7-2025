using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        // [HttpPost]
        //public IActionResult SubmitContact(string fullName, string email, string message)
        //{
        // Xử lý lưu vào database/gửi email...
        //    TempData["SuccessMessage"] = "Cảm ơn bạn đã liên hệ!";
        //  return RedirectToAction("Contact");
        // }

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
    }
}
