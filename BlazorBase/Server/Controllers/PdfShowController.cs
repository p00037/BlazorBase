using BlazorBase.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfShowController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PdfShowController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET api/<PdfShowController>/5
        [HttpGet]
        public PrintResult Get()
        {
            var originalFilePath = $"{_webHostEnvironment.WebRootPath}\\download\\test.pdf";
            string fileName = Guid.NewGuid().ToString("N") + ".pdf";
            var copyFilePath = $"{_webHostEnvironment.WebRootPath}\\download\\{fileName}";
            System.IO.File.Copy(originalFilePath, copyFilePath);
            return new PrintResult(fileName, RequestResult.CreateSuccess());
        }

    }
}
