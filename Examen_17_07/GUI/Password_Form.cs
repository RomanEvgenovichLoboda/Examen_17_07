using Examen_17_07.Classes;
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
    public partial class Password_Form : Form
    {
        public bool varif_Ok=false;
        public Password_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (label1.Text == "Пароль")
                {
                    if (Password_Class.Varificaton(textBox1.Text))
                    {
                        varif_Ok = true;
                        this.Close();
                    }
                    else { MessageBox.Show("Error Password"); }
                }
                else
                {
                    if (Password_Class.Varif_Key(textBox1.Text))
                    {
                        varif_Ok = true;
                        this.Close();
                    }
                    else { MessageBox.Show("Error Key"); }
                }

                
            }
        }
    }
}
