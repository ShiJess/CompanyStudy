//*************************************************
//Copyright (C):	Sujie
//�ļ�����File Name����	SayHello.cs
//���ߣ�Author����	Sujie
//�汾��Version����	1.0
//�������ڣ�Create Date����	2013.07.05
//����������Description����
//��Ҫ�����б�Function List����
//�޸ļ�¼��Revision History����
//*************************************************

using System;
using System.Windows;

namespace Sujie.SayHello
{
    class SayHello
    {
        [STAThread]
        public static void Main()
        {
            Window win = new Window();
            win.Title = "Say Hello";
            win.Show();

            Application app = new Application();
            app.Run();
        }
    }
}