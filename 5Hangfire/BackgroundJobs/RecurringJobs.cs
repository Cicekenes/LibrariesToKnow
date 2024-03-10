using Hangfire;
using System.Diagnostics;

namespace _5Hangfire.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1",()=> EmailReport(),Cron.Minutely);
        }

        //Windows servis gibi çalışmaktadır. Yani belli günlerde, belli zamanlarda.
        public static void EmailReport()
        {
            Debug.Write("Rapor,email olarak gönderildi");
        }
    }
}
