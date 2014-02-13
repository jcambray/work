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

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(1000);
            bool owned;
            Mutex m = new Mutex(true, Application.ProductName, out owned);
            if (owned)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                    MainForm mf = new MainForm();
                    if (mf.launch)
                    { Application.Run(mf); }
                else
                    { Application.Exit(); }
                    m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("L'application est déja lancée", Application.ProductName);
            }
        }
    }
}
