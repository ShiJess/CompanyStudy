using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //���������ƶ��¼��������
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("��׽�������!({0},{1})", e.X, e.Y);
        }
    }
}