using Examen_17_07;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Timers;

namespace ParrentConsole
{
    internal class Program
    {
        static List<string> list_names = new List<string>();
        static Desktop desktop = new Desktop();
        //static Timer timer = new Timer();
        static void Main(string[] args)
        {
            //Timer timer = new Timer();
            //timer.Interval = 10;
            //timer.Tick += ((s, e) => ProcessMonitor());
            //timer.Start();
            ProcessMonitor();
            ShowDisplay();
            ProcessMonitor();  
            Console.ReadLine();
        }
        static async void ShowDisplay()
        {
            await Task.Run(async () => {
                desktop.ShowDialog(); 
                await Task.Delay(1); 
            });
        }
        static async void ProcessMonitor()
        {
            await Task.Run(async() => {
                //using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                using (RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    string[] arr_app_names = reg_key.GetSubKeyNames();
                    foreach (var item_app_name in arr_app_names)
                    {
                        using (RegistryKey app_key = reg_key.OpenSubKey(item_app_name))
                        {
                            string display_name = app_key?.GetValue("DisplayName")?.ToString();
                            string app_name = app_key?.GetValue("DisplayIcon")?.ToString();
                            if (app_name != null && display_name != null && app_name.Contains(".exe"))
                            {
                                string process_name = Regex.Match(app_name, @".*\\(.*)\.exe").Groups[1].Value;
                                foreach (var item in Process.GetProcessesByName(process_name))
                                {
                                    if (!list_names.Contains(display_name)) list_names.Add(display_name);
                                    //Console.WriteLine(display_name);
                                }
                            }
                        }
                    }
                    list_names.ForEach(Console.WriteLine);

                    desktop.listBox_ProgramsRun.Items.AddRange(list_names.ToArray());
                    //desktop.ShowDialog();
                }
                await Task.Delay(1);
            });
            
        }
    }
}
