using BlazorFileUpload.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tangy_DataAccess.Data;

namespace BlazorFileUpload.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public FileController(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        private void EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {

                Directory.CreateDirectory(folderPath);
            }
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var uploadResult = await _context.UploadResults.FirstOrDefaultAsync(u => u.StoredFileName.Equals(fileName));

            var path = Path.Combine(_env.ContentRootPath, "uploads", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, uploadResult.ContentType, Path.GetFileName(path));
        }

        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();
            var folderpath = Path.Combine(_env.ContentRootPath, "uploads");
            EnsureFolderExists(folderpath);

            foreach (var file in files)
            {
                var uploadResult = new UploadResult();
                //string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                //trustedFileNameForFileStorage = Path.GetRandomFileName();
                var path = Path.Combine(_env.ContentRootPath, "uploads", untrustedFileName);
                //var path = Path.Combine(_env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);// error
                await file.CopyToAsync(fs);

                uploadResult.StoredFileName = untrustedFileName;
                //uploadResult.StoredFileName = trustedFileNameForFileStorage;
                uploadResult.ContentType = file.ContentType;
                uploadResults.Add(uploadResult);

                _context.UploadResults.Add(uploadResult);
            }

            await _context.SaveChangesAsync();

            return Ok(uploadResults);
        }
    }
}