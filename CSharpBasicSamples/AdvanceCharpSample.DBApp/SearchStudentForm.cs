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

        // �����û�
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

        // ɾ���û�
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            // ȷ���û�ѡ����һ��ѧԱ��ִ��ɾ������
            if (lvStudent.SelectedItems.Count == 0)
            {
                MessageBox.Show("��û��ѡ���κ��û�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                // Ϊ��ֹ��ɾ����Ҫ��ѯ��
                DialogResult choice = MessageBox.Show("ȷ��Ҫɾ�����û���","��������",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                // ���ȷ��ɾ������ִ��ɾ������
                if (choice == DialogResult.Yes)
                {
                    // ɾ����sql���
                    string sql = string.Format("DELETE FROM Student WHERE StudentID={0}",(int)lvStudent.SelectedItems[0].Tag);

                    // ����Command����
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);

                    int result = 0;  // �������

                    try
                    {
                        DBHelper.connection.Open();  // �����ݿ�����
                        result = command.ExecuteNonQuery();  // ִ������                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.connection.Close();  // �ر����ݿ�����
                    }

                    if (result < 1)  // ����ʧ��
                    {
                        MessageBox.Show("ɾ��ʧ�ܣ�", "�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else  // �����ɹ�
                    {
                        MessageBox.Show("ɾ���ɹ���", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillListView();  // ���²�ѯ��Ϣ����б���ͼ
                    }
                }
            }
        }

        // ���û�״̬�޸�Ϊ���
        private void tsmiActive_Click(object sender, EventArgs e)
        {
            // ȷ���û�ѡ����һ��ѧԱ��ִ���޸Ĳ���
            if (lvStudent.SelectedItems.Count == 0)
            {
                MessageBox.Show("��û��ѡ���κ��û�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ɾ����sql���
                string sql = string.Format("Update Student SET UserStateId=1 WHERE StudentID={0}", (int)lvStudent.SelectedItems[0].Tag);
                int result = 0;  // �������

                try
                {
                    // ����Command����
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();          // �����ݿ�����
                    result = command.ExecuteNonQuery();  // ִ������                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();  // �ر����ݿ�����
                }
                if (result < 1)  // ����ʧ��
                {
                    MessageBox.Show("�޸�ʧ�ܣ�", "�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else  // �����ɹ�
                {
                    MessageBox.Show("�޸ĳɹ���", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillListView();  // ���²�ѯ��Ϣ����б���ͼ
                }
            }
        }

        // ���û�״̬�޸�Ϊ�ǻ��
        private void tsmiInActive_Click(object sender, EventArgs e)
        {
            // ȷ���û�ѡ����һ��ѧԱ��ִ���޸Ĳ���
            if (lvStudent.SelectedItems.Count == 0)
            {
                MessageBox.Show("��û��ѡ���κ��û�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ɾ����sql���
                string sql = string.Format("Update Student SET UserStateId=0 WHERE StudentID={0}", (int)lvStudent.SelectedItems[0].Tag);
                int result = 0;  // �������

                try
                {
                    // ����Command����
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();          // �����ݿ�����
                    result = command.ExecuteNonQuery();  // ִ������                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();  // �ر����ݿ�����
                }
                if (result < 1)  // ����ʧ��
                {
                    MessageBox.Show("�޸�ʧ�ܣ�", "�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else  // �����ɹ�
                {
                    MessageBox.Show("�޸ĳɹ���", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillListView();  // ���²�ѯ��Ϣ����б���ͼ
                }
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

                lvStudent.Items.Clear();    // ���ListView�е�������

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
                        lviStudent.Tag = (int)dataReader["StudentID"];      // ��ID����Tag��
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