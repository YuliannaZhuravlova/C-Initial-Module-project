using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    public class Warehouse {
        private Partners Partner;
        public Warehouse(Partners partner) {
            Partner = partner;
        }

         private Dictionary<ZooGoods, int> Stuff = new Dictionary<ZooGoods, int>(); // Create Dictionary with Goods and quantity per each stuff

        //Add stuff to Warehouse
        public void AddStuff(int productCode, int count){
            if(!(Partner.PartnerType == PartnerType.Supplier)) { // The only Supplier is allowed to do it
                throw new WrongUserRoleException();
            }
            ZooGoods zooGoods = ZooGoods.GetGood(productCode); // Get such Goods is available in Goods List

            if(zooGoods == null) {
                throw new NoSuchGoodsException();//                Check if such goods exist in the system
            }

            if (Stuff.ContainsKey(zooGoods)) { //If Stuff is yet in Warehouse, just increase the number
                Stuff[zooGoods] +=  count;
            }
            else {
                Stuff.Add(zooGoods, count);// If Stuff is not in Warehouse, add it
            }

        }

        //Harcoded adding of stuff in administration mode (without checking of role)
        public void AddStuffNoAuthCheck(int productCode, int count) {
            ZooGoods zooGoods = ZooGoods.GetGood(productCode);

            if (zooGoods == null) {
                throw new NoSuchGoodsException();
            }

            if (Stuff.ContainsKey(zooGoods)) {
                Stuff[zooGoods] += count;
            } else {
                Stuff.Add(zooGoods, count);
            }

        }
        //Retrive the stuff from Waterhouse (by Product code and Numer)
        public void GetStuff(int productCode, int count) {
            if (!(Partner.PartnerType == PartnerType.Client)) { // Only Clients can get the stuff from Warehouse
                throw new WrongUserRoleException ();
            }
                        ZooGoods zooGoods = ZooGoods.GetGood(productCode);

            if (zooGoods == null) {
                throw new NoSuchGoodsException();// Check if such goods exist in the system
            }

            if (!Stuff.ContainsKey(zooGoods)) {
                throw new NotEnoughGoodsException(); // Check if goods is in the Warehouse at all
            }
            if (Stuff[zooGoods] < count) {
                throw new NotEnoughGoodsException(); // Check if goods is avaliable for given nominal
            }
            Stuff[zooGoods] -= count;// retrive number of current 
        }
        //Count and return the number of current Goods in Warehouse
        public int CountStuff(int productCode ) { 
            ZooGoods zooGoods = ZooGoods.GetGood(productCode);

            if (zooGoods == null) {
                throw new NoSuchGoodsException(); // If such Goods exists in the system
            }
            if (!Stuff.ContainsKey(zooGoods)) { // If Goods stores in Warehouse
                return 0;
            } else {
                return Stuff[zooGoods]; // Return available nominal
            }
        }
    }
}
