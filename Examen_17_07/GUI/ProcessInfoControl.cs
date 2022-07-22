using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_17_07.GUI
{
    public partial class ProcessInfoControl : UserControl
    {
        public ProcessInfoControl(DateTime time, string name,int y)
        {
            InitializeComponent();
            labelTime.Text = time.ToShortTimeString();
            labelProcessName.Text = name;
            Location = new Point(0,y);
        }
    }
}
