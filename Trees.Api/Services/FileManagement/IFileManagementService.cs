namespace Trees.Api.Services.FileManagement
{
    public interface IFileManagementService
    {
        Task<string> Create(string name, string base64Str, FileType type);
        void Delete(string name, FileType type);
    }
}
