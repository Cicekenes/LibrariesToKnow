using Hangfire;
using System.Drawing;

namespace _5Hangfire.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string fileName,string watermarkText)
        {
            //DelayedJob
            return BackgroundJob.Schedule(() => ApplyWatermark(fileName, watermarkText), TimeSpan.FromSeconds(30));
        }
        public static void ApplyWatermark(string fileName, string watermarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/pictures", fileName);
            using (var bitMap = Bitmap.FromFile(path))
            {
                using (Bitmap tempBitMap = new Bitmap(bitMap.Width, bitMap.Height))
                {
                    using (Graphics grp = Graphics.FromImage(tempBitMap))
                    {
                        grp.DrawImage(bitMap, 0, 0);
                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitMap.Height - 50);
                        grp.DrawString(watermarkText, font, brush, point);
                        tempBitMap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/pictures/watermarks", fileName));
                    }
                }
            }
        }
    }
}
