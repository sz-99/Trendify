using Backend.Models.Enums;

namespace Backend.Utils
{
    public class FileUtils
    {
        public static (ExecutionStatus status, FileStream? file) FileStreamFromPath(string path)
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    return (ExecutionStatus.SUCCESS, fileStream);
                }
            }
            catch
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
    }
}
