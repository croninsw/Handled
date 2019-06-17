using Microsoft.AspNetCore.Http;

namespace Handled.Models.ViewModels
{
    public class CarPhotoUploadViewModel
    {
        public Car Car { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}