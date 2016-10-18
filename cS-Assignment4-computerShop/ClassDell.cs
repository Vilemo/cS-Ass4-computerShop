using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    class ClassDell: ClassComputers
    {
        private string brand;
        private double price;

        public string cDBrand{
            get{ return this.brand;}
            set{this.brand=value;}
        }
        public double cDPrice{
            get{ return this.price;}
            set{this.price=value;}
        }

        public ClassDell(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor, string brand, double price)
            :base (motherboard, cpu, soundCard, videoCard, networkCard, hdd, monitor)
        {
            this.cDBrand = brand;
            this.cDPrice = price;
        }
        public override string PrintInfo()
        {
            string message = "Dell computer details: " + Environment.NewLine + "Brand: " + this.cDBrand + Environment.NewLine + "Price: " + cDPrice + Environment.NewLine +
                base.PrintInfo();
            return message;
        }
    }
}
