using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MySchool
{
    /// <summary>
    /// ����ά�����ݿ������ַ������� Connection ����
    /// </summary>
    class DBHelper
    {
        // ���ݿ������ַ���
        private static string connString = "Data Source=.;Initial Catalog=MySchool;User ID=sa;Pwd=sa";

        // ���ݿ����� Connection ����
        public static SqlConnection connection = new SqlConnection(connString); 
    }
}
