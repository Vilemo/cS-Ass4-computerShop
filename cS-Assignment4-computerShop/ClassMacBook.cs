using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    class ClassMacBook : ClassComputers
    {
        private string brand;
        private double price;

        public string cMBBrand{
            get{ return this.brand;}
            set{this.brand=value;}
        }
        public double cMBPrice{
            get{ return this.price;}
            set{this.price=value;}
        }

        public ClassMacBook(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor, string brand, double price)
            :base (motherboard, cpu, soundCard, videoCard, networkCard, hdd, monitor)
        {
            this.cMBBrand = brand;
            this.cMBPrice = price;
        }
        public override string PrintInfo()
        {
            string message = "MacBook computer details: " + Environment.NewLine + "Brand: " + this.cMBBrand + Environment.NewLine + "Price: " + cMBPrice + Environment.NewLine +
                base.PrintInfo();
            return message;
        }

    }
}
