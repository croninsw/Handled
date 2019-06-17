using Microsoft.AspNetCore.Http;

namespace Handled.Models.ViewModels
{
    public class CyclistPhotoUploadViewModel
    {
        public Cyclist Cyclist { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
