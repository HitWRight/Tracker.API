using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace UsageClient
{
    class Program
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // Returns the name of the process owning the foreground window.
        private static string GetForegroundProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();

            // The foreground window can be NULL in certain circumstances, 
            // such as when a window is losing activation.
            if (hwnd == null)
                return "Unknown";

            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.Id == pid)
                    return p.ProcessName;
            }

            return "Unknown";
        }

        static void Main(string[] args)
        {
            while (true)
            {
                using (var wr = new StreamWriter("data.txt", true))
                {
                    wr.WriteLine(GetForegroundProcessName() + "||-||" + GetActiveWindowTitle());
                }

                Thread.Sleep(5000);



                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            {"computerId", "1"},
                            {"usedProgram", GetForegroundProcessName() + "||-||" + GetActiveWindowTitle()}
                        };
                    string json = JsonConvert.SerializeObject(values);

                    

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response =  client.PostAsync("http://localhost:5007/api/usagebuffer", content).Result;

                 

                    

                    Console.WriteLine(response.IsSuccessStatusCode);
                }
            }
        }
    }
}
