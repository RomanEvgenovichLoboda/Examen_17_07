//using ParrentConsole;
using Examen_17_07.GUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_17_07
{
    public partial class Desktop : Form
    {
        int Y = 0;
         List<string> list_names = new List<string>();
        //public Timer timer = new Timer();
        public Desktop()
        {
            InitializeComponent();
            using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                this.BackgroundImage = Image.FromFile(reg_key.GetValue("WallPaper").ToString());
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;


            
            //ProcessMonitor();
        }

        

        private void Desktop_Load(object sender, EventArgs e)
        {
            //Password_Form passForm = new Password_Form();
            //passForm.ShowDialog();
            //if (!passForm.varif_Ok) { this.Close(); }
        }

        //public async void ProcessMonitor()
        //{
        //    await Task.Run(async () =>
        //    {
        //        //using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
        //        using (RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
        //        {
        //            string[] arr_app_names = reg_key.GetSubKeyNames();
        //            while (true)
        //            {
        //                foreach (var item_app_name in arr_app_names)
        //                {
        //                    using (RegistryKey app_key = reg_key.OpenSubKey(item_app_name))
        //                    {
        //                        string display_name = app_key?.GetValue("DisplayName")?.ToString();
        //                        string app_name = app_key?.GetValue("DisplayIcon")?.ToString();
        //                        if (app_name != null && display_name != null && app_name.Contains(".exe"))
        //                        {
        //                            string process_name = Regex.Match(app_name, @".*\\(.*)\.exe").Groups[1].Value;
        //                            foreach (var item in Process.GetProcessesByName(process_name))
        //                            {
        //                                if (!list_names.Contains(display_name)) 
        //                                {
        //                                    list_names.Add(display_name);
        //                                    //listBox_ProgramsRun.Items.Add(display_name);

        //                                    AddControl(item.StartTime, display_name, process_name);

        //                                    //Invoke(new Action(() => {
        //                                    //    ProcessInfoControl processInfoControl = new ProcessInfoControl(this,item.StartTime, display_name, process_name, Y);
        //                                    //    panelProcessGo.Controls.Add(processInfoControl); }));

        //                                    //ProcessInfoControl processInfoControl = new ProcessInfoControl(item.StartTime, display_name, Y);
        //                                    //Controls.Add(processInfoControl);
        //                                    //Y += 55;
        //                                }

        //                                //Console.WriteLine(display_name);
        //                            }
        //                        }
        //                    }
        //                }
        //                await Task.Delay(1);
        //            }

        //            //list_names.ForEach(Console.WriteLine);

        //            //listBox_ProgramsRun.Items.AddRange(list_names.ToArray());
        //            //desktop.ShowDialog();
        //        }

        //    });

        //}
        public void AddControl( DateTime dt,string d_n,string p_n )
        {
            Invoke(new Action(() => {
                ProcessInfoControl processInfoControl = new ProcessInfoControl(this, dt, d_n, p_n, Y);
                panelProcessGo.Controls.Add(processInfoControl);
                Y += 50;
            }));
        }
    }
}
