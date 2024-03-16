//using BlazorFileUpload.Shared;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Tangy_DataAccess.Data;

//namespace BlazorFileUpload.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentDocController : ControllerBase
//    {
//        private readonly IWebHostEnvironment _env;
//        private readonly ApplicationDbContext _context;

//        public PaymentDocController(IWebHostEnvironment env, ApplicationDbContext context)
//        {
//            _env = env;
//            _context = context;
//        }

//        private void EnsureFolderExistsPayment(string folderPath)
//        {
//            if (!Directory.Exists(folderPath))
//            {

//                Directory.CreateDirectory(folderPath);
//            }
//        }

//        [HttpGet("{fileName}")]
//        public async Task<IActionResult> DownloadFilePayment(string fileName)
//        {
//            var paymentDoc = await _context.PaymentDocs.FirstOrDefaultAsync(u => u.StoredFileName.Equals(fileName));

//            var path = Path.Combine(_env.ContentRootPath, "payments", fileName);

//            var memory = new MemoryStream();
//            using (var stream = new FileStream(path, FileMode.Open))
//            {
//                await stream.CopyToAsync(memory);
//            }
//            memory.Position = 0;
//            return File(memory, paymentDoc.ContentType, Path.GetFileName(path));
//        }

//        [HttpPost]
//        public async Task<ActionResult<List<PaymentDoc>>> UploadFilePayment(List<IFormFile> files)
//        {
//            List<PaymentDoc> paymentDocs = new List<PaymentDoc>();
//            var folderpath = Path.Combine(_env.ContentRootPath, "payments");
//            EnsureFolderExistsPayment(folderpath);

//            foreach (var file in files)
//            {
//                var paymentDoc = new PaymentDoc();
//                //string trustedFileNameForFileStorage;
//                var untrustedFileName = file.FileName;
//                paymentDoc.FileName = untrustedFileName;
//                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

//                //trustedFileNameForFileStorage = Path.GetRandomFileName();
//                var path = Path.Combine(_env.ContentRootPath, "payments", untrustedFileName);
//                //var path = Path.Combine(_env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

//                await using FileStream fs = new(path, FileMode.Create);// error
//                await file.CopyToAsync(fs);

//                paymentDoc.StoredFileName = untrustedFileName;
//                //uploadResult.StoredFileName = trustedFileNameForFileStorage;
//                paymentDoc.ContentType = file.ContentType;
//                paymentDocs.Add(paymentDoc);

//                _context.PaymentDocs.Add(paymentDoc);
//            }

//            await _context.SaveChangesAsync();

//            return Ok(paymentDocs);
//        }
//    }
//}