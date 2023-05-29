using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace FoodToGo_API.Controllers
{
    [ApiController]
    [Route("api/FileAPI")]
    public class FileController : ControllerBase
    {
        private readonly string _sharedFolderPath;

        public FileController(IOptions<SharedFolderOptions> options)
        {
            _sharedFolderPath = options.Value.Path;
        }

        [HttpGet("{fileName}")]
        [Authorize]
        [ResponseCache(Duration = 1000)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(string fileName)
        {
            var filePath = Path.Combine(_sharedFolderPath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var filePath = Path.Combine(_sharedFolderPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileUrl = Url.Action("Get", new { fileName = file.FileName });
            return Created("fileUrl", fileUrl);
        }

        [HttpDelete("{fileName}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(string fileName)
        {
            var filePath = Path.Combine(_sharedFolderPath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();
            System.IO.File.Delete(filePath);
            return NoContent();
        }
    }
}
