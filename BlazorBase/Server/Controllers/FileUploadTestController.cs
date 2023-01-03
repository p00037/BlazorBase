using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.UploadTest;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FileUploadTestController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadTestController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("upload/multiple/{id}")]
        public async Task<IActionResult> OnPostUploadAsync([FromForm(Name = "files")] ICollection<IFormFile> files, string id)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var fileName = formFile.FileName;
                    //var filePath = Path.GetTempFileName();
                    var filePath = $"{_webHostEnvironment.WebRootPath}\\upload\\{id}.txt";

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }

        // POST api/<MstLoginUserController>
        [HttpPost("upload/filecheck")]
        public ActionResult<RequestResult> Post([FromBody] UploadEntity value)
        {
            return ApiResult.Execute(() =>
            {
                var filePath = $"{_webHostEnvironment.WebRootPath}\\upload\\{value.id}.txt";
                if (!System.IO.File.Exists(filePath))
                {
                    throw new Exception("ファイルが存在しません。");
                }
            });
        }
    }
}
