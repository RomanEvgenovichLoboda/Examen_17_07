using Examen_17_07;
using Examen_17_07.GUI;
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
using System.Windows.Threading;
//using System.Timers;

namespace ParrentConsole
{
    public class Program2
    {
        static List<string> list_names = new List<string>();
        static Desktop desktop = new Desktop();
        static void Main(string[] args)
        {
            Console.Title= "Parrent Control";
            
            ShowDisplay();
            ProcessMonitor();  
            char choice = '9';
            do
            {
                Console.Clear();
                Console.WriteLine("Exit = 0");
                try
                {
                    choice = char.Parse(Console.ReadLine());
                }
                catch (Exception) { }
                
            } while (choice!='0');
            if(choice=='0')Application.Exit();

            Console.ReadLine();
        }
        static void ShowDisplay()
        {
             Task.Run(() => {
                desktop.ShowDialog();  
            });
        }
        public static void ProcessMonitor()
        {
             Task.Run(async() => {
                //using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                 using (RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                 {
                    string[] arr_app_names = reg_key.GetSubKeyNames();
                    while (true)
                    {
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
                                        if (!list_names.Contains(display_name)) 
                                        {
                                            list_names.Add(display_name);

                                                desktop.AddControl(item.StartTime, display_name, process_name);
                                        }
                                    }
                                }
                            }
                        }
                        await Task.Delay(1);
                    }
                 }
            });
        }
    }
}
