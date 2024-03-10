using _5Hangfire.Services;
using Hangfire;

namespace _5Hangfire.BackgroundJobs
{
    /// <summary>
    /// Tek işlem yapmak adına bu job kullanılır. Örnek vermek gerekirse, bir kullanıcı sisteme üye olduktan sonra mail göndermek buna bir örnektir.
    /// </summary>
    public class FireAndForgetJobs
    {
        public static void EmailSendToUserJob(string userId,string message)
        {
            //Tek seferliğine çalışır.Bir kuyruk sistemi gibidir.
            BackgroundJob.Enqueue<IEmailSender>(x=>x.Sender(userId,message));
        }
    }
}
