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
    /// ѧ������ڰ���ʾ��2
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
                
        // �������رա���ťʱ,�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}