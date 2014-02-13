using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace clientbackup
{
   public class Configuration
    {
        private int nbjours;
        private int heure;
        private int minute;
        private int period;
        private int nbSaves;
        private string path;
        private string password;
        private char autoShutDown;
        private DateTime nextSaveDate;

        public Configuration()
        {
            this.period = Convert.ToInt32(ConfigurationManager.AppSettings["period"]);
            this.heure = Convert.ToInt32(ConfigurationManager.AppSettings["heure"]);
            this.minute = Convert.ToInt32(ConfigurationManager.AppSettings["minute"]);
            this.path = ConfigurationManager.AppSettings["path"];
            this.password = ConfigurationManager.AppSettings["password"];
            this.nbSaves = Convert.ToInt32(ConfigurationManager.AppSettings["nbSaves"]);
            this.nextSaveDate = Convert.ToDateTime(ConfigurationManager.AppSettings["nextSave"]);
            this.autoShutDown = Convert.ToChar(ConfigurationManager.AppSettings["autoShutDown"]);
        }

        public Configuration(int nbj,int h, int min, int per, int nbSav, string p, string pwd)
        {
            this.nbjours = nbj;
            this.heure = h;
            this.minute = min;
            this.period = per;
            this.nbSaves = nbSav;
            this.path = p;
            this.password = pwd;
        }                    
    

        public int getHeure()
        {
            return this.heure;
        }

        public int getMinute()
        {
            return this.minute;
        }

        public int getPeriode()
        {
            return this.period;
        }

        public int getNbSaves()
        {
            return this.nbSaves;
        }

        public string getPath()
        {
            return this.path;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setHeure(int h)
        {
            this.heure = h;
        }

        public void setMinute(int m)
        {
            this.minute = m;
        }

        public void setPeriode(int p)
        {
            this.period = p;
        }

        public void setNbSaves(int nb)
        {
            this.nbSaves = nb;
        }

        public void setPath(string pa)
        {
            this.path = pa;
        }

        public void setPassword(string pass)
        {
            this.password = pass;
        }

        public int getNbJours()
        {
            return this.nbjours;
        }

        public DateTime getNextSaveDate()
        {
            return this.nextSaveDate;
        }

        public char getAutoShutDown()
        {
            return this.autoShutDown;
        }

        public void setAutoShutDown(char c)
        {
            this.autoShutDown = c;
        }

     
    }
}
