using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;


namespace Backend.Utils
{
    public class FileUtils
    {
        public static (ExecutionStatus status, FileStream? file) FileStreamFromPath(string path)
        {
            try
            {
                var fileStream = new FileStream(path, FileMode.Open);
           
                    return (ExecutionStatus.SUCCESS, fileStream);
               
            }
            catch
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }

        public static byte[] BytesFromFilePath(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        //public static FileContentResult FileResultFromFilePath(string filePath, string downloadName)
        //{
        //    var bytes = BytesFromFilePath(filePath);
        //    var result = new FileContentResult(bytes, "image/png");
        //    result.FileDownloadName = downloadName;
        //    return result;
        //}

        public static FileContentResult FileResultFromFilePath(string filePath, string downloadName)
        {
            var bytes = BytesFromFilePath(filePath);


            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream"; // Default if unknown
            }

            var result = new FileContentResult(bytes, contentType)
            {
                FileDownloadName = downloadName
            };

            return result;
        }
    }
}
