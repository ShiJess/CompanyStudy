using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MySchool
{
    /// <summary>
    /// About����
    /// </summary>
    public partial class AboutForm : Form
    {
        int index = 0;  // ͼƬ����ͼƬ������
        
        public AboutForm()
        {
            InitializeComponent();
        }
        
        // ��ʱ�����¼�����������ʱ�任ͼƬ���е�ͼƬ
        private void timer_Tick(object sender, EventArgs e)
        {
            // �����ǰ��ʾ��ͼƬ����û�е����ֵ�ͼ�������
            if (index < ilAnimation.Images.Count - 1)
            {
                index++;
            }
            else  // ����ӵ�һ��ͼƬ��ʼ��ʾ��������0��ʼ
            {
                index = 0;            
            }
            // ����ͼƬ����ʾ��ͼƬ   
            picAnimation.Image = ilAnimation.Images[index];
        }

        // ͼƬ��ĵ����¼������������ʱ�رմ���
        private void picOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}