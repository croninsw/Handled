using Handled.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Http;

namespace Handled.Models.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterModel Register { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
