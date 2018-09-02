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
    /// ��Ա��Ϣ�б���
    /// </summary>
    public partial class TeacherListForm : Form
    {
        private DataSet dataSet = new DataSet();����// ��������ʼ��DataSet
        private SqlDataAdapter dataAdapter;�������� // ����DataAdapter
        
        public TeacherListForm()
        {
            InitializeComponent();
        }

        // �������ʱ�������
        private void TeacherListForm_Load(object sender, EventArgs e)
        {
            // ��ѯ�õ� sql ���
            string teacherSql = "SELECT TeacherID,LoginId,LoginPwd,TeacherName,Sex,BirthDay FROM Teacher";
            
            // ��ʼ�� DataAdapter
            dataAdapter = new SqlDataAdapter(teacherSql, DBHelper.connection);          

            // ��� DataSet
            dataAdapter.Fill(dataSet, "Teacher");

            // ��DataGridView������Դ
            dgvTeacher.DataSource = dataSet.Tables["Teacher"];
        }        

        // �����������޸ġ���ťʱ�������ݼ��ĸ����ύ�����ݿ�
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ȷʵҪ���޸ı��浽���ݿ���?","������ʾ",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "Teacher");
            }            
        }

        // �����رհ�ťʱ,�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ������ˢ�¡���ťʱ������������ݼ�
        private void btnFresh_Click(object sender, EventArgs e)
        {
            dataSet.Tables["Teacher"].Clear();    // ���ԭ��������
            dataAdapter.Fill(dataSet,"Teacher");  // �������
        }
    }
}