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
        //static Timer timer = new Timer();
        static void Main(string[] args)
        {
            //DispatcherTimer timer = new DispatcherTimer();
            //Timer timer = new Timer();
            //timer.Interval = TimeSpan.FromSeconds(1);
           // timer.Tick += ((s, e) => ProcessMonitor());
            //timer.Start();

            //desktop.timer.Tick+= ((s, e) => ProcessMonitor());
            //desktop.timer.Start();

            //ProcessMonitor();
            ShowDisplay();

            //TimeMonitor();
            //ProcessMonitor();  

            //TimerStart();
            // ShowDisplay();
            char choice = '9';
            do
            {
                Console.Clear();
                Console.WriteLine("Exit = 0");
                try
                {
                    choice = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                   
                }
                
            } while (choice!='0');
            if(choice=='0')Application.Exit();

            Console.ReadLine();
        }
        //static async void TimerStart()
        //{
        //    await Task.Run(async () =>
        //    {
        //        Timer timer = new Timer();
        //        timer.Interval = 100;
        //        timer.Tick += ((s, e) => ProcessMonitor());
        //        timer.Start();
        //        await Task.Delay(1);
        //    });
        //}

        static void ShowDisplay()
        {
             Task.Run(() => {
                desktop.ShowDialog();  
            });
        }

        static async void TimeMonitor()
        {
            //Task.Run(async () => {
                while (true)
                {
                    foreach (ProcessInfoControl item in desktop.panelProcessGo.Controls)
                    {
                        if (TimeSpan.Parse(item.labelTime.ToString()) >= TimeSpan.FromMinutes(10))
                        {
                            if (!desktop.listBox_ProgramsRun.Items.Contains(item.labelProcessName))
                                desktop.listBox_ProgramsRun.Items.Add(item.labelProcessName);
                        }
                    }
                    await Task.Delay(1000);
                }
            
            
           // });
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
                                            desktop.listBox_ProgramsRun.Items.Add(display_name);
                                            Console.WriteLine(display_name);
                                        }
                                        //Console.WriteLine(display_name);
                                    }
                                }
                            }
                        }
                        //list_names.ForEach(Console.WriteLine);

                        //desktop.listBox_ProgramsRun.Items.AddRange(list_names.ToArray());
                        await Task.Delay(1000);
                    }
                    
                    //desktop.ShowDialog();
                }
                
            });
            
        }
    }
}
