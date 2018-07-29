namespace FileUpload_WebAPI.UploadRepo
{
    public class FileUploadDetails 
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
        public string FileCreatedTime { get; set; }
        
    }
}