﻿namespace IntermediateForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Exemple42 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exemple42
            // 
            this.Exemple42.Location = new System.Drawing.Point(12, 12);
            this.Exemple42.Name = "Exemple42";
            this.Exemple42.Size = new System.Drawing.Size(260, 23);
            this.Exemple42.TabIndex = 0;
            this.Exemple42.Text = "实例42 在程序中添加控件";
            this.Exemple42.UseVisualStyleBackColor = true;
            this.Exemple42.Click += new System.EventHandler(this.Exemple42_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Exemple42);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exemple42;
    }
}

