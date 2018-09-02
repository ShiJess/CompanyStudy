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
    /// ��ʾ����ʾʹ��ExecuteScalar()������ѯѧԱ����ѧԱ��Ϣ��������
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // �����ݿ����ӣ���ѯѧԱ��¼����
        private void btnTest_Click(object sender, EventArgs e)
        {
            // ���� Connection ����
            string connString = "Data Source=.;Initial Catalog=MySchool;User ID=sa;pwd=sa";
            SqlConnection connection = new SqlConnection(connString);

            int num = 0;  // ѡԱ��Ϣ������
            string message = "";  // �����Ľ����Ϣ
            // ��ѯ�õ� SQL ���
            string sql = "SELECT COUNT(*) FROM Student";

            try
            {
                connection.Open();// �����ݿ�����
                // ���� Command ����
                SqlCommand command = new SqlCommand(sql, connection);
                // ִ�� SQL ��ѯ
                num = (int)command.ExecuteScalar();

                message = string.Format("Student���й���{0}��ѧԱ��Ϣ��",num);
                MessageBox.Show(message,"��ѯ���",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception exp)
            {
                // ��������
                MessageBox.Show(exp.Message);
            }
            finally
            {
                // �ر����ݿ�����
                connection.Close();                
            }
        }
    }
}