namespace _5Hangfire.Services
{
    public interface IEmailSender
    {
        Task Sender(string userId,string message);
    }
}
