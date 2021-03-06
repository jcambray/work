﻿using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;

namespace clientbackup
{
    class Serialization
    {
        public static void serialize(bool o)
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/autologon.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, o);
            fichier.Close();
        }

        public static void serialize(ArrayList list)
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/files.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, list);
            fichier.Close();
        }

        public static bool deserialize()
        {
            try
            {
                FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/autologon.txt", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                bool o = (bool)bf.Deserialize(fichier);
                fichier.Dispose();
                return o;
            }
            catch (FileNotFoundException)
            {
                serialize(false);
                bool o = false;
                return o;
            }

        }

        public static ArrayList deserializeList()
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/files.txt", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();
            ArrayList list = (ArrayList)bf.Deserialize(fichier);
            fichier.Dispose();
            return list;
        }

        public static void serializeToXML(ArrayList list, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList));
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/" + filename, FileMode.Create);
            serializer.Serialize(fichier, list);
            fichier.Close();
            fichier.Dispose();
        }

        public static ArrayList deserializeXML(string filename)
        {
            try
            {
                FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/" + filename, FileMode.OpenOrCreate);
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList));
                ArrayList list = (ArrayList)serializer.Deserialize(fichier);
                fichier.Close();
                fichier.Dispose();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static void serializeLastSaveDate(DateTime date)
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastSaveDate.aut", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, date);
            fichier.Close();
        }

        public static DateTime deserializeLastSaveDate(bool init)
        {
            try
            {
                 FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastSaveDate.aut", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                DateTime dt = (DateTime)bf.Deserialize(fichier);
                fichier.Dispose();
                return dt;
            }
            catch (FileNotFoundException)
            {
                if (init)
                {
                    serializeLastSaveDate(DateTime.Now);
                }

                return new DateTime(2000,1,1);
            }
        }

        public static string deserializeEmpFichierConfig()
        {
            return ConfigurationManager.AppSettings["empFichierConfig"];
        }

        public static Configuration deserializeConfig()
        {
            FileStream fichier = new FileStream(deserializeEmpFichierConfig(), FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Configuration c = (Configuration)bf.Deserialize(fichier);
            fichier.Dispose();
            return c;
        }

        public static void serializeLastVirtualSaveDate()
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastVirtualSaveDate.aut", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, DateTime.Now);
            fichier.Close();
        }

        public static DateTime deserializeLastVirtualSaveDate()
        {
            if (!File.Exists(Environment.CurrentDirectory + @"/Data/lastVirtualSaveDate.aut"))
            {
                serializeLastVirtualSaveDate();
            }
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastVirtualSaveDate.aut", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DateTime dt = (DateTime)bf.Deserialize(fichier);
            fichier.Dispose();
            return dt;
        }

        public static void serializeMDPAdmin(string mdp)
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/MDPAdmin.aut", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, mdp);
            fichier.Close();
        }

        public static string deserializeMDPAdmin()
        {
            try
            {
                FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/MDPAdmin.aut", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                string mdp = (string)bf.Deserialize(fichier);
                fichier.Dispose();
                return mdp;
            }
            catch
            {
                return null;
            } 
        }

        public static void serializeEtatDerniereSave(char c)
        {
            FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastSaveState.aut", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, c);
            fichier.Close();
        }

        public static char deserializeEtatDerniereSave()
        {
            try
            {
                FileStream fichier = new FileStream(Environment.CurrentDirectory + @"/Data/lastSaveState.aut", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                char c = (char)bf.Deserialize(fichier);
                fichier.Dispose();
                return c;
            }
            catch
            {
                serializeEtatDerniereSave(' ');
                return ' ';
            }
        }

    
    } 
}
