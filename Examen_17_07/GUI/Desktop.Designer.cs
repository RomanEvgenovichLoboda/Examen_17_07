﻿namespace Examen_17_07
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
            this.SuspendLayout();
            // 
            // listBox_ProgramsRun
            // 
            this.listBox_ProgramsRun.FormattingEnabled = true;
            this.listBox_ProgramsRun.ItemHeight = 16;
            this.listBox_ProgramsRun.Location = new System.Drawing.Point(308, 12);
            this.listBox_ProgramsRun.Name = "listBox_ProgramsRun";
            this.listBox_ProgramsRun.Size = new System.Drawing.Size(207, 212);
            this.listBox_ProgramsRun.TabIndex = 0;
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 298);
            this.Controls.Add(this.listBox_ProgramsRun);
            this.Name = "Desktop";
            this.Text = "Desktop";
            this.Load += new System.EventHandler(this.Desktop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBox_ProgramsRun;
    }
}
