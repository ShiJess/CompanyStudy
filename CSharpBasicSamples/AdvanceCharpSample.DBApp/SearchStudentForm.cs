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
    /// ��ѯѧԱ�û�����
    /// �����¿��ð���ʾ��3
    /// </summary>
    public partial class SearchStudentForm : Form
    {
        public SearchStudentForm()
        {
            InitializeComponent();
        }

        // ������ȡ������ťʱ���رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // �����û���ʾ��3
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLoginId.Text == "")  // ���������û������ܲ���
            {
                MessageBox.Show("�������û���", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginId.Focus();
            }            
            else  // �����û�
            {
                FillListView();  // ����б���ͼ
            }
        }     

        /// <summary>
        /// ���ݲ�ѯ�����������ݿ��ж�ȡ��Ϣ������б���ͼ
        /// </summary>
        private void FillListView()
        {
            string loginId;      // �û���
            string studentName;  // ����
            string studentNO;    // ѧ��
            int userStateId;     // �û�״̬Id 
            string userState;    // �û�״̬

            // ����ѧԱ�û���sql���
            string sql = string.Format(
                "SELECT StudentID,LoginId,StudentNO,StudentName,UserStateId FROM Student WHERE LoginId like '%{0}%'", txtLoginId.Text
                );
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection); // ����Command����                
                DBHelper.connection.Open();  // �����ݿ�����

                SqlDataReader dataReader = command.ExecuteReader();  // ִ�в�ѯ�û�����

                lvStudent.Items.Clear();  // ���ListView�е�������

                // ��������û�������У��͵�����ʾ��
                if (!dataReader.HasRows)
                {
                    MessageBox.Show("��Ǹ��û����Ҫ�ҵ��û���", "�����ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ���鵽�Ľ��ѭ��д��ListView��
                    while (dataReader.Read())
                    {
                        // �������ݿ��ж�ȡ�����û�����������ѧ�š��û�״̬������Ӧ�ı���
                        loginId = (string)dataReader["LoginId"];
                        studentName = (string)dataReader["StudentName"];
                        studentNO = (string)dataReader["StudentNO"];
                        userStateId = (int)dataReader["UserStateId"];
                        userState = (userStateId == 1) ? "�" : "�ǻ";

                        ListViewItem lviStudent = new ListViewItem(loginId);//����һ��ListView��
                        lviStudent.Tag = (int)dataReader["StudentID"];  // ��ID����Tag��
                        lvStudent.Items.Add(lviStudent); // ��ListView�����һ������
                        lviStudent.SubItems.AddRange(new string[] { studentName, studentNO, userState });//��ǰ�����������
                    }
                }
                dataReader.Close();  //�ر�dataReader
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ѯ���ݿ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();  // �ر����ݿ�����
            }
        }                 
    }
}