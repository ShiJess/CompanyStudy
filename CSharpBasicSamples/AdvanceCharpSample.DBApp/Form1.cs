using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OpenCloseDB
{
    /// <summary>
    /// ��ʾ����ʾ�򿪺͹ر����ݿ⣬��ʹ���쳣����
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ���Դ����ݿ�Ĳ��������finally
        private void btnTest_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=.;Initial Catalog=MySchool;User ID=sa;pwd=sa";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                // �򿪳ɹ�
                connection.Open();
                MessageBox.Show("�����ݿ����ӳɹ�");                
            }
            catch (Exception ex)
            {
                // ��ʧ��
                MessageBox.Show("�����쳣");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // �ر����ݿ�
                connection.Close();
                MessageBox.Show("�ر����ݿ����ӳɹ�");
            }
        }
    }
}