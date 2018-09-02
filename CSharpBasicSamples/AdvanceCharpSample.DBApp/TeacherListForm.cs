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
    /// ѧ������ڰ���ʾ��1
    /// </summary>
    public partial class TeacherListForm : Form
    {
        private DataSet dataSet = new DataSet();����// ��������ʼ��DataSet
        private SqlDataAdapter dataAdapter;����     // ����DataAdapter
        
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

            // ��ӡ���ݼ��� Teacher ��
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                    row["TeacherId"], row["TeacherName"],row["Sex"]);
            }
        } 
    }
}