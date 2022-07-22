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
            timeSpan = DateTime.Now.ToUniversalTime() - time.ToUniversalTime();
            labelTime.Text = timeSpan.ToString().Remove(5); //time.ToShortTimeString(); 
            labelProcessName.Text = name;
            Location = new Point(0,y);
            processName = pr_name;
            //TimerStart();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += async(s, e) => Monitoring();
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
            if(timeSpan>=TimeSpan.FromMinutes(10))
            {
                if (!desktop.listBox_ProgramsRun.Items.Contains(labelProcessName.Text))
                    desktop.listBox_ProgramsRun.Items.Add(labelProcessName.Text);
            }
            
        }
    }
}
