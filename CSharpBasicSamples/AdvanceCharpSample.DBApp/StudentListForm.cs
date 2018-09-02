using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MySchool
{
    /// <summary>
    /// ѧԱ��Ϣ�б���
    /// </summary>
    public partial class StudentListForm : Form
    {
        DataSet dataSet = new DataSet("MySchool");  // ���� DataSet ����
        SqlDataAdapter dataAdapter;  ����           // ����һ����������������

        public StudentListForm()
        {
            InitializeComponent();
        }

        // ��������¼���������ʱ������ݼ�����ʾ����
        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // ��ѯ�õ� sql ���
            string sql = "SELECT StudentId, LoginId, StudentName, StudentNO, Sex, Phone, Address, JobWanted FROM Student";
            // ���� DataAdapter ����
            dataAdapter = new SqlDataAdapter(sql, DBHelper.connection);
            // ������ݼ�
            dataAdapter.Fill(dataSet, "Student");

            // ָ�� DataGridView ����Դ����ʾ����
            dgvStudent.DataSource = dataSet.Tables["Student"];

            // ����ɸѡ������Ĭ��ֵ
            cboSex.Text = "ȫ��";
        }

        // �������޸ġ���ť Click �¼������������ύ�����ݿ�
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "ȷ��Ҫ�����޸���", "������ʾ",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)  // ȷ���޸�
            {
                // �Զ����ɸ��������õ�����
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                // ���޸Ĺ��������ύ�����ݿ�
                dataAdapter.Update(dataSet, "Student");
            }
        }

        // ��ɸѡ����ť�� Click �¼��������SQL��䣬����������ݼ�
        private void btnReFill_Click(object sender, EventArgs e)
        {
            // ���� SQL ���
            string sql = "SELECT StudentId, LoginId, StudentName, StudentNO, Sex, Phone, Address, JobWanted FROM Student";

            // ������Ͽ��ѡ����� SQL ���
            switch (cboSex.Text)
            {
                case "��":  // �����Ա�Ϊ�е�����
                    sql += " WHERE Sex = '��'";
                    break;
                case "Ů": // �����Ա�ΪŮ������
                    sql += " WHERE Sex = 'Ů'";
                    break;
                default:   // �����κβ���
                    break;
            }

            dataSet.Tables["Student"].Clear();

            // ����ָ�� DataAdapter ����Ĳ�ѯ���
            dataAdapter.SelectCommand.CommandText = sql;
            // ����������ݼ�
            dataAdapter.Fill(dataSet, "Student");
        }

        // �رհ�ť�¼������رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ��ˢ�¡���ť�� Click �¼���������������ݼ�����ʾ
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // ��ѯ�õ� sql ���
            string sql = "SELECT StudentId, LoginId, StudentName, StudentNO, Sex, Phone, Address, JobWanted FROM Student";

            cboSex.Text = "ȫ��";
            dataSet.Tables["Student"].Clear(); // ���ԭ���ı�

            // ���� DataAdapter ����
            dataAdapter.SelectCommand.CommandText = sql;
            
            // ������ݼ�
            dataAdapter.Fill(dataSet, "Student");
        }
    }
}