namespace Trees.Api.Services.Mail
{
    public interface IMailService
    {
        Task Send(string subject, string message); // exception
    }
}
