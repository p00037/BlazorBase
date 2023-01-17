using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileDownloadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("api/download/test")]
        public IActionResult Download()
        {
            var fileName = "text1.txt";
            var filePath = $"{_webHostEnvironment.WebRootPath}\\download\\{fileName}";
            var file = System.IO.File.ReadAllBytes(filePath);

            return File(file, "application/octet-stream", fileName);
        }
    }
}
