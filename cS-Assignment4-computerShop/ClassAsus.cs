using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cS_Assignment4_computerShop
{
    class ClassAsus: ClassComputers
    {
        private string brand;
        private double price;

        public string cABrand{
            get{ return this.brand;}
            set{this.brand=value;}
        }
        public double cAPrice{
            get{ return this.price;}
            set{this.price=value;}
        }

        public ClassAsus(string motherboard, string cpu, string soundCard, string videoCard, string networkCard, string hdd, string monitor, string brand, double price)
            :base (motherboard, cpu, soundCard, videoCard, networkCard, hdd, monitor)
        {
            this.cABrand = brand;
            this.cAPrice = price;
        }
        public override string PrintInfo()
        {
            string message = "Asus computer details: " + Environment.NewLine + "Brand: " + this.cABrand + Environment.NewLine + "Price: " + cAPrice + Environment.NewLine +
                 base.PrintInfo();
            return message;
        }
    }
}
