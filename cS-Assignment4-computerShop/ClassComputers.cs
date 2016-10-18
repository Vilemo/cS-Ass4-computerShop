using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    public abstract class ClassComputers //abstract clas doesn't allow to create objects of that class (so you need child class(es))
    {
        private string motherboard;
        private string cpu;
        private string soundCard;
        private string videoCard;
        private string networkCard;
        private string hdd;
        private string monitor;

        public ClassComputers() : this("","","","","","","")
        { }
        public ClassComputers(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor)
        {
            this.MB = motherboard;
            this.CPU = cpu;
            this.sCard = soundCard;
            this.vCard = videoCard;
            this.nCard = networkCard;
            this.HDD = hdd;
            this.Monitor = monitor;
        }
        public string MB
        {
            get { return this.motherboard; }
            set { this.motherboard = value; }
        }
        public string CPU
        {
            get { return this.cpu; }
            set { this.cpu = value; }
        }
        public string sCard
        {
            get { return this.soundCard; }
            set { this.soundCard = value; }
        }
        public string vCard
        {
            get { return this.videoCard; }
            set { this.videoCard = value; }
        }
        public string nCard
        {
            get { return this.networkCard; }
            set { this.networkCard = value; }
        }
        public string HDD
        {
            get { return this.hdd; }
            set { this.hdd = value; }
        }
        public string Monitor
        {
            get { return this.monitor; }
            set { this.monitor = value; }
        }

        public virtual string PrintInfo()
        { //virtual method to allow it to be overriden
            string messge = "Motherboard: " + MB + Environment.NewLine + "CPU: " + CPU + Environment.NewLine +
                "Sound card: " + sCard + Environment.NewLine + "Video card: " + vCard + Environment.NewLine + "Network card: " + nCard + Environment.NewLine +
                "HDD: " + HDD + Environment.NewLine + "Monitor: "+Monitor;
            return messge;
        }
    }
}
