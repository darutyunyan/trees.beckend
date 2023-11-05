namespace Trees.Api.Services.FileManagement
{
    public class FileManagementService : IFileManagementService
    {
        public FileManagementService(IHostEnvironment environment)
        {
            _rootFolderPath = Path.Combine(environment.ContentRootPath, WEB_ROOT_FOLDER);
        }

        public async Task<string> Create(string name, string base64Str, FileType type)
        {
            string folderPath = _GetFolderPath(type);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileFullName = _GetFileFullName(name, type);

            _CheckOnExist(folderPath, fileFullName);

            string filePath = Path.Combine(folderPath, fileFullName);

            byte[] imageBytes = Convert.FromBase64String(base64Str);

            await File.WriteAllBytesAsync(filePath, imageBytes);

            return filePath;
        }

        public void Delete(string name, FileType type)
        {
            string folderPath = _GetFolderPath(type);

            string fileFullName = _GetFileFullName(name, type);

            string filePath = Path.Combine(folderPath, fileFullName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public string _GetFolderPath(FileType type)
        {
            string subFolder = string.Empty;

            switch (type)
            {
                case FileType.Img:
                    subFolder = IMAGES_FOLDER;
                    break;
                default:
                    throw new ArgumentException(nameof(type));
            }

            return Path.Combine(_rootFolderPath, subFolder);
        }

        public string _GetFileFullName(string name, FileType type)
        {
            switch (type)
            {
                case FileType.Img:
                    return name.ToLower() + JPG_FORMAT;
                default:
                    throw new ArgumentException(nameof(type));
            }
        }

        private void _CheckOnExist(string folderPath, string fileName)
        {
            string[] files = Directory.GetFiles(folderPath);

            if (files.Any(img => img.Contains(fileName)))
                throw new ArgumentException(nameof(fileName)); //WebApiException(sharedLocal["ALREADY_EXIST_MESSAGE"]); // todo
        }

        private const string WEB_ROOT_FOLDER = @"wwwroot";
        private const string IMAGES_FOLDER = @"Images";
        private const string JPG_FORMAT = @".jpg";

        private readonly string _rootFolderPath;
    }
}
