using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clientbackup
{
    class Log
    {
        public static void write(string s)
        {
            try
            {
                if (!File.Exists(Environment.CurrentDirectory + @"/Data/Log.txt"))
                {
                    File.CreateText(Environment.CurrentDirectory + @"/Data/Log.txt");
                }
                StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"/Data/Log.txt");
                sw.WriteLine(s);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }

        public static void notifieDebutSauvegarde()
        {
            Log.write("-" + DateTime.Now.ToShortDateString() + "à " + DateTime.Now.ToShortTimeString() + " Debut de sauvegarde.");
        }

        public static void notifieFinSauvegarde()
        {
            Log.write("-" + DateTime.Now.ToShortDateString() + "à " + DateTime.Now.ToShortTimeString() + " Fin de sauvegarde.");
        }

        public static void open()
        {
            string path = Environment.CurrentDirectory + @"/Data/Log.txt";
            if(!File.Exists(path))
            {
                File.Create(Environment.CurrentDirectory + @"/Data/Log.txt");
            }
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(path);
            System.Diagnostics.Process.Start(psi); 
        }

        public static void effacer()
        {
            try
            {
                File.Delete(Environment.CurrentDirectory + @"/Data/Log.txt");
                File.CreateText(Environment.CurrentDirectory + @"/Data/Log.txt");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
