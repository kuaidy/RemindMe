using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe.Services
{
    public class SignInService
    {
        public static void SignInMicrosoftRewards()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string url = $"https://cn.bing.com/search?q={i}";
                    string exePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                    Process.Start(exePath, url);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
