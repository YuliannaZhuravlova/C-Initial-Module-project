using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo
{
    public class ZooGoods:IZooGoods {

        //Initialize properties for ZooGoods class
        private string _Name;
       public static int InstanceCount { get; set; }
        public string GoodsType { get; set; }
        public string Measure { get; set; }
        public int ProductCode { get; set; }
     
        //Costructors for Goods class
        public ZooGoods()        {          
        }
         public ZooGoods(int productCode) {
         this.ProductCode = productCode;
        }

      private static List<ZooGoods> GoodsList = new List<ZooGoods>();
        // Add new goods to Goods List
        public static void AddZooGood (ZooGoods newGoods)  { 
            if (newGoods == null) {
                throw new NullReferenceException("newGoods");
            }
            for (int i = 0; i < GoodsList.Count; i++) {
                if (GoodsList[i].ProductCode == newGoods.ProductCode) {
                    throw new Exception("Goods already exists!");
                }
                    }
            GoodsList.Add(newGoods);

        }
        // Update information for existed goods from the List
        public static bool UpdGoods(ZooGoods updGoods) { 
            if (updGoods == null) {
                throw new NullReferenceException("updGoods");
            }
            for (int i = 0; i < GoodsList.Count; i++) {
                if (GoodsList[i].ProductCode == updGoods.ProductCode) {
                   GoodsList[i]=updGoods;
                    return true;
                }
            }
            return false;
            }
        // Return information about current Goods
        public static ZooGoods GetGood (int productCode) 
                      { 
             for(int i = 0; i < GoodsList.Count; i++) {
                if (GoodsList[i].ProductCode == productCode) {
                    return GoodsList[i];
                }
            }
            return null;
        }
        
       // Delete current Goods from the List
               public static bool DelGoods(int productCode) { 
            for (int i = 0; i < GoodsList.Count; i++) {
                if (GoodsList[i].ProductCode == productCode) {
                    GoodsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public override string ToString() {
            return "Code: " + ProductCode + ", Name: " + Name + ", Type: " + GoodsType + ", Measure: " + Measure;
        }
        //Method to check that Name and Measure properties are not empty
        public bool Validate() { 
            var isValid = true;
            if (string.IsNullOrWhiteSpace(Name)) isValid = false;
            if (string.IsNullOrWhiteSpace(Measure)) isValid = false;
            return isValid;
        }
        //Method to return/assign Name value
        public string Name        {
            get            {
                return _Name;
            }
            set            {
                _Name = value;
            }
        }
    }
}
