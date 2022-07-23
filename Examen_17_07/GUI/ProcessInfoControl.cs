using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_17_07.GUI
{
    public partial class ProcessInfoControl : UserControl
    {
        Desktop desktop;
        TimeSpan timeSpan = new TimeSpan();
        TimeSpan durationSpan = TimeSpan.FromSeconds(1);
        string processName;
        public ProcessInfoControl(Desktop dt,DateTime time, string name,string pr_name,int y)
        {
            InitializeComponent();
            desktop = dt;
            processName = pr_name;
            timeSpan = DateTime.Now.ToUniversalTime() - time.ToUniversalTime();
            labelTime.Text = timeSpan.ToString().Remove(8); //time.ToShortTimeString(); 
            labelProcessName.Text = name; //$"({pr_name})" + name;
            Location = new Point(0,y);
            
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += ((s, e) => { Monitoring(); });
            timer.Start();
        }
        
        async void Monitoring()
        {
            bool procGo = false;
            foreach (var item in Process.GetProcessesByName(processName))
            {
                procGo = true;
            }
            if (procGo)
            {
                timeSpan += durationSpan;
                labelTime.Text = timeSpan.ToString().Remove(8);
            }
            if(timeSpan>=TimeSpan.FromMinutes(int.Parse(desktop.comboBox1.SelectedItem.ToString())))
            {
                if (!desktop.listBox_ProgramsRun.Items.Contains(labelProcessName.Text))
                { 
                    desktop.listBox_ProgramsRun.Items.Add(labelProcessName.Text);
                }
                if (!desktop.list_Black.Contains(processName))
                {
                    desktop.list_Black.Add(processName);
                }
            }
            await Task.Delay(1);
        }
    }
}
