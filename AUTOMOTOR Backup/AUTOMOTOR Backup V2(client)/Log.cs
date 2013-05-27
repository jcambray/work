using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clientbackup
{
    class Log
    {
        public static void write(string s)
        {
            if(!File.Exists(Environment.CurrentDirectory + @"\Log.txt"))
            {
                File.CreateText(Environment.CurrentDirectory + @"\Log.txt");
            }
            StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Log.txt");
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        public static void notifieDebutSauvegarde(string s)
        {
            Log.write("*****************************************************");
            Log.write("\n");
            Log.write("----------------------------------------------------");
            Log.write("---------------SAUVEGARDE AUTOMATIQUE---------------");
            Log.write("----------------------------------------------------");
            Log.write("\n");
            Log.write("Debut de sauvegarde le " + s);
            Log.write("\n");
        }

        public static void notifieFinSauvegarde(string s)
        {
            Log.write("\n");
            Log.write("Fin de sauvegarde le " + s);
            Log.write("\n");
            Log.write("----------------------------------------------------");
            Log.write("----------------------------------------------------");
            Log.write("----------------------------------------------------");
            Log.write("\n");
            Log.write("*****************************************************");

        }

        public static void open()
        {
            string path = Environment.CurrentDirectory + @"\Log.txt";
            if(!File.Exists(path))
            {
                File.Create(Environment.CurrentDirectory + @"\Log.txt");
            }
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(path);
            System.Diagnostics.Process.Start(psi);
            
        }
    }
}
