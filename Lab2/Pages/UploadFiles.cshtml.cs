using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages
{
    public class UploadFilesModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public UploadFilesModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [Required(ErrorMessage ="Please choose atleast one file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name ="Choose File(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach(var FileUP in FileUploads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "Images", FileUP.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await FileUP.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
