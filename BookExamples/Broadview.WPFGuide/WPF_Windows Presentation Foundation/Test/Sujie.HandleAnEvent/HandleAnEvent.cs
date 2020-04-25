//*************************************************
//Copyright (C):	Sujie
//�ļ�����File Name����	HandleAnEvent.cs
//���ߣ�Author����	Sujie
//�汾��Version����	1.0
//�������ڣ�Create Date����	2013.07.05
//����������Description����
//��Ҫ�����б�Function List����
//�޸ļ�¼��Revision History����
//*************************************************

using System;
using System.Windows;
using System.Windows.Input;

namespace Sujie.HandleAnEvent
{
    class HandleAnEvent
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();

            Window win = new Window();
            win.Title = "Handle An Event";
            win.MouseDown += WindowOnMouseDown;

            app.Run(win);
        }
        static void WindowOnMouseDown(object sender,MouseButtonEventArgs args)
        {
            Window win = sender as Window;
            string strMessage = 
                string.Format("Window clicked with {0} button at point ({1})",
                            args.ChangedButton,args.GetPosition(win));
            MessageBox.Show(strMessage,win.Title);
        }
    }
}