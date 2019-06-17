using Microsoft.AspNetCore.Http;

namespace Handled.Models.ViewModels
{
    public class IncidentPhotoUploadViewModel
    {
        public Incident Incident { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
