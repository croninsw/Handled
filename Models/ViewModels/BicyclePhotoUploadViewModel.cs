using Microsoft.AspNetCore.Http;

namespace Handled.Models.ViewModels
{
    public class BicyclePhotoUploadViewModel
    {
        public Bicycle Bicycle { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
