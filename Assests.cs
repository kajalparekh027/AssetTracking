using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrakingSystem {



    class Assets {

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

        public Assets(string type, string brand, string office, DateTime purchaseDate, string model, string price) {
            Type = type;
            Brand = brand;
            Office = office;
            PurchaseDate = purchaseDate;
            Model = model;
            Price = price;
        }
    }
    class Computer : Assets {
        public Computer(string type, string brand, string office, DateTime purchaseDate, string model, string price) : base(type, brand, office, purchaseDate, model, price) {
        }

        internal object OrderBy(Func<object, object> p) {
            throw new NotImplementedException();
        }
    }
    class Phone : Assets {
        public Phone(string type, string brand, string office, DateTime purchaseDate, string model, string price) : base(type, brand, office, purchaseDate, model, price) {
        }
    }
}
