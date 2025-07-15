using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Message { get; set; }
    }
}
