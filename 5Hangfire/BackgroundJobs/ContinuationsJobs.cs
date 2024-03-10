using Hangfire;
using System.Diagnostics;

namespace _5Hangfire.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void WriteWatermarkStatusJob(string id,string fileName)
        {
            BackgroundJob.ContinueJobWith(id,()=> Debug.WriteLine($"{fileName} : resim'e watermark eklenmiştir."));
        }
    }
}
