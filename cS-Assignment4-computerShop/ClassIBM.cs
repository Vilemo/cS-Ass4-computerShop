using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    class ClassIBM: ClassComputers
    {
        private string brand;
        private double price;

        public string cIBMBrand{
            get{ return this.brand;}
            set{this.brand=value;}
        }
        public double cIBMPrice{
            get{ return this.price;}
            set{this.price=value;}
        }

        public ClassIBM(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor, string brand, double price)
            :base (motherboard, cpu, soundCard, videoCard, networkCard, hdd, monitor)
        {
            this.cIBMBrand = brand;
            this.cIBMPrice = price;
        }
        public override string PrintInfo()
        {
            string message = "IBM computer details: " + Environment.NewLine + "Brand: " + this.cIBMBrand + Environment.NewLine + "Price: " + cIBMPrice + Environment.NewLine +
               base.PrintInfo();
            return message;
        }
    }
}
