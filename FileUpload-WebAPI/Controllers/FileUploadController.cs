using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FileUpload_WebAPI.UploadRepo;

namespace FileUpload_WebAPI.Controllers
{
    [RoutePrefix("api/fileupload")]
    public class FileUploadController : ApiController
    {
        [Mime]
        [Route("upload")]
        [HttpPost]
        public async Task<FileUploadDetails> Upload()
        {
            // file path
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

            var multiFormDataStreamProvider = new MultiFileUploadProvider(fileuploadPath);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multiFormDataStreamProvider);

            string uploadingFileName = multiFormDataStreamProvider
                .FileData.Select(x => x.LocalFileName).FirstOrDefault();

            // Create response
            return new FileUploadDetails
            {

                FilePath = uploadingFileName,

                FileName = Path.GetFileName(uploadingFileName),

                FileLength = new FileInfo(uploadingFileName).Length,

                FileCreatedTime = DateTime.Now.ToLongDateString()
            };
        }
    }
}
