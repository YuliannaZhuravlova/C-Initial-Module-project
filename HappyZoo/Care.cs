using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    public class Care:ZooGoods {
        // Class Care is a child class of Goods, with assigned by default Care to GoodsType
        public Care() {
            GoodsType = "Care";
        }
        public string DogCare { get; set; }
        public string CatCare { get; set; }
    }
}
