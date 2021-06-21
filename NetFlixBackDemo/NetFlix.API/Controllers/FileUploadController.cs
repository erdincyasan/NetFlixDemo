using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace NetFlix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {

        [HttpPost]
        [Authorize()]
        public IActionResult Post()
        {
            var formfile = Request.Form.Files[0];
            var formFileExt = System.IO.Path.GetExtension(formfile.FileName);
            var filePath = Path.GetTempFileName();
            var folderPath = Path.Combine("Resources", "Images");
            var fullPath = Path.Combine(folderPath, formfile.FileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                formfile.CopyTo(stream);
                return Ok(new { fullPath });
            }
            //var stream = System.IO.File.Create(filePath);
            // filePath.CopyTo()
        }
    }
}
