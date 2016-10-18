using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    class ClassHP: ClassComputers
    {
        private string brand;
        private double price;

        public string cHPBrand{
            get{ return this.brand;}
            set{this.brand=value;}
        }
        public double cHPPrice{
            get{ return this.price;}
            set{this.price=value;}
        }

        public ClassHP(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor, string brand, double price)
            :base (motherboard, cpu, soundCard, videoCard, networkCard, hdd, monitor)
        {
            this.cHPBrand = brand;
            this.cHPPrice = price;
        }
        public override string PrintInfo()
        {
            string message = "HP computer details: " + Environment.NewLine + "Brand: " + this.cHPBrand + Environment.NewLine + "Price: " + cHPPrice + Environment.NewLine +
               base.PrintInfo();
            return message;
        }
    }
}
