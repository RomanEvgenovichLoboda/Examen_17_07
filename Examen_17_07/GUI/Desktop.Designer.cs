namespace Examen_17_07
{
    partial class Desktop
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_ProgramsRun = new System.Windows.Forms.ListBox();
            this.panelProcessGo = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox_ProgramsRun
            // 
            this.listBox_ProgramsRun.BackColor = System.Drawing.Color.IndianRed;
            this.listBox_ProgramsRun.FormattingEnabled = true;
            this.listBox_ProgramsRun.ItemHeight = 16;
            this.listBox_ProgramsRun.Location = new System.Drawing.Point(487, 13);
            this.listBox_ProgramsRun.Name = "listBox_ProgramsRun";
            this.listBox_ProgramsRun.Size = new System.Drawing.Size(326, 212);
            this.listBox_ProgramsRun.TabIndex = 0;
            // 
            // panelProcessGo
            // 
            this.panelProcessGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelProcessGo.AutoScroll = true;
            this.panelProcessGo.Location = new System.Drawing.Point(13, 13);
            this.panelProcessGo.Name = "panelProcessGo";
            this.panelProcessGo.Size = new System.Drawing.Size(407, 273);
            this.panelProcessGo.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "60",
            "300",
            "720"});
            this.comboBox1.Location = new System.Drawing.Point(487, 252);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 298);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panelProcessGo);
            this.Controls.Add(this.listBox_ProgramsRun);
            this.Name = "Desktop";
            this.Text = "Desktop";
            this.Load += new System.EventHandler(this.Desktop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBox_ProgramsRun;
        public System.Windows.Forms.Panel panelProcessGo;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

