using Examen_17_07.Classes;
using Examen_17_07.GUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Examen_17_07
{
    public partial class Desktop : Form
    {
        string path = Directory.GetCurrentDirectory() + "/history.txt";
        int Y = 0;
        public List<string> list_Black = new List<string>();
        public Desktop()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 3;
            using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                this.BackgroundImage = Image.FromFile(reg_key.GetValue("WallPaper").ToString());
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        

        private void Desktop_Load(object sender, EventArgs e)
        {
            File.AppendAllText(path, $"\nOpen - {DateTime.Now}");
            Password_Form passForm = new Password_Form();
            passForm.ShowDialog();
            if (!passForm.varif_Ok) { this.Close(); }
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Examen"))
                {
                    if(Password_Class.License_key == key.GetValue("Key").ToString())
                    {
                        button_Key.Visible = false;
                        button_Statistic.Visible = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
       
        public void AddControl( DateTime dt,string d_n,string p_n )
        {
            Invoke(new Action(() => {
                ProcessInfoControl processInfoControl = new ProcessInfoControl(this, dt, d_n, p_n, Y);
                panelProcessGo.Controls.Add(processInfoControl);
                Y += 25;
            }));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Black.Clear();
            listBox_ProgramsRun.Items.Clear();
        }

        private void button_Key_Click(object sender, EventArgs e)
        {
            Password_Form passForm = new Password_Form();
            passForm.label1.Text = "Key";
            passForm.ShowDialog();
            if (passForm.varif_Ok)
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Examen"))
                {
                    key.SetValue("Key", Password_Class.License_key);
                }
                button_Key.Visible = false;
                button_Statistic.Visible = true;
            }
        }

        private void button_Statistic_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(path));
        }

        private void Desktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.AppendAllText(path, $"\tClosed - {DateTime.Now}");
        }
    }
}
