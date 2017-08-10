using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    public class  Food:ZooGoods {
        // Class Food is a child class of Goods, with assigned by default Food to GoodsType
        public Food () {
            GoodsType = "Food";
        }
        public string FoodType { get; set; }
          }
}
