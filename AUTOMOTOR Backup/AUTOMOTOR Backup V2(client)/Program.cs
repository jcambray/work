using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace clientbackup
{
    static class Program
    {
        //static Mutex m;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*bool owned;
            Mutex m = new Mutex(true, Application.ProductName, out owned);
            if (owned)
            {*/
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mf = new MainForm();
                Application.Run(mf);
                //m.ReleaseMutex();
            /*}
            else
            {
                MessageBox.Show("L'application est déja lancée", Application.ProductName);
            }*/
        }
    }
}
