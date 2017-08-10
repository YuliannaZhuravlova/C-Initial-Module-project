using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyZoo;

namespace HappyZooConsole {
    class Program {
        static void Main(string[] args) {

            //User autorization
            Console.WriteLine("Input UserName:");
            string userLogin = Console.ReadLine();

            Console.WriteLine("Input password:");
            string password = Console.ReadLine();

            IUsers user = UsersRepository.Users.FirstOrDefault(x => x.Login(userLogin, password));
            if(user == null) {
                Console.WriteLine("Invalid");
                Console.ReadKey();
                return;
            }
                               
            //ZooGoods initialization
            
            var zooGoods = new ZooGoods();
            ZooGoods.AddZooGood(new WetFood {ProductCode = 1, Name = "ForCat", Measure ="l"  });
            ZooGoods.AddZooGood(new WetFood { ProductCode = 2, Name = "ForDog", Measure = "kg" });
            ZooGoods.AddZooGood(new DryFood { ProductCode = 3, Name = "ForCat", Measure = "kg" });
            ZooGoods.AddZooGood(new DryFood { ProductCode = 4, Name = "ForDog", Measure = "l" });
            ZooGoods.AddZooGood(new Care    { ProductCode = 5, Name = "ForCat", Measure = "ps" });
            ZooGoods.AddZooGood(new Care { ProductCode = 6, Name = "ForDog", Measure = "l" });


            //Warehouse initialization
            Warehouse warehouse = new Warehouse(user as Partners);
            warehouse.AddStuffNoAuthCheck(1, 30);
            warehouse.AddStuffNoAuthCheck(2, 15);
            warehouse.AddStuffNoAuthCheck(3, 10);
            warehouse.AddStuffNoAuthCheck(4, 30);
            warehouse.AddStuffNoAuthCheck(5, 3);
            warehouse.AddStuffNoAuthCheck(6, 9);

            //User choose the way to go
            while (true) {
                Console.WriteLine("Please, choose the operation:");
                Console.WriteLine("0 - Update goods list");
                Console.WriteLine("1 - Update  warehouse");
                Console.WriteLine("2 - Exit");
                string action = Console.ReadLine();
                if (action == "0") {
                    UpdateGoodsList(zooGoods);
                                    }
                if (action == "1") {
                    UpdateWarehouse(warehouse);
                }
                if (action == "2") {
                    return;
                }
            }

        }
        
        // If user select Warehouse - choose the operation to do
        private static void UpdateWarehouse(Warehouse warehouse) {
            while (true) {
                Console.WriteLine("Please, choose the operation:");
                Console.WriteLine("0 - Add Stuff to Warehouse");
                Console.WriteLine("1 - Get Stuff from Warehouse");
                Console.WriteLine("2 - Get Count from Warehouse");
                Console.WriteLine("3 - Return to previous menu");
                string action = Console.ReadLine();
                if (action == "0") {
                    AddStuffToWarehouse(warehouse);
                }
                if (action == "1") {
                    GetStuffFromWarehouse(warehouse);
                }
                if (action == "2") {
                    GetCountFromWarehouse(warehouse);
                }
                if (action == "3") {
                    return;
                }
            }
        }
        //Return the number of available current stuff in the Warehouse
        private static void GetCountFromWarehouse(Warehouse warehouse) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr= Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            try {
                int count = warehouse.CountStuff(productCode);
                Console.WriteLine(count);
            } catch (NoSuchGoodsException) {
                Console.WriteLine("No such goods!");
            }
                    }

        //Retrive the current stuff from warehouse
        private static void GetStuffFromWarehouse(Warehouse warehouse) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr = Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            Console.WriteLine("Enter Quantity:");
            string productQuantStr = Console.ReadLine();
            int productQuant = CheckProductCode(productQuantStr);
            try {
                warehouse.GetStuff(productCode, productQuant);
            } catch (WrongUserRoleException) {
                Console.WriteLine("You do not have permissions");
            } catch (NoSuchGoodsException) {
                Console.WriteLine("No such goods");
            } catch (NotEnoughGoodsException) {
                Console.WriteLine("Not enough goods");
            }
        }

        //Add the current stuff to the warehouse
        private static void AddStuffToWarehouse(Warehouse warehouse) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr = Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            Console.WriteLine("Enter Quantity:");
            string productQuantStr = Console.ReadLine();
            int productQuant = CheckProductCode(productQuantStr);
            try {
                warehouse.AddStuff(productCode, productQuant);
            } catch (WrongUserRoleException) {
                Console.WriteLine("You do not have permissions");
            }           catch(NoSuchGoodsException) {
                Console.WriteLine("No such goods");
            }
        }

        // If user select Goods List - choose the option to change
        private static void UpdateGoodsList(ZooGoods zooGoods) {
            while (true) {
                Console.WriteLine("Please, choose the operation with Goods:");
                Console.WriteLine("0 - Add Goods to the list");
                Console.WriteLine("1 - Get Goods information");
                Console.WriteLine("2 - Update Goods information");
                Console.WriteLine("3 - Delete Goods from the list");
                Console.WriteLine("4 - Return to previous menu");
                string action = Console.ReadLine();
                if (action == "0") {
                    AddGoodsToList(zooGoods);
                }
                if (action == "1") {
                    GetGoodsInfo(zooGoods);
                }
                if (action == "2") {
                    UpdGoodsInfo(zooGoods);
                                    }
                if (action == "3") {
                    DelGoodsFromList(zooGoods);
                }
                if (action == "4") {
                    return;
                                    }
            }
        }

        //Delete current goods from the  Goods List
        private static void DelGoodsFromList(ZooGoods zooGoods) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr = Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            ZooGoods.DelGoods(productCode);
        }

        //Get information about current goods
        private static void GetGoodsInfo(ZooGoods zooGoods) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr = Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            ZooGoods goods = ZooGoods.GetGood(productCode);
            Console.WriteLine(goods);
        }

        //Update information about current goods
        private static void UpdGoodsInfo(ZooGoods zooGoods) {
               Console.WriteLine("Enter Product code:");
                string productCodeStr = Console.ReadLine();
                int productCode = CheckProductCode(productCodeStr);
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Type:");
                string type = Console.ReadLine();
                Console.WriteLine("Enter Meausure:");
                string measure = Console.ReadLine();
            ZooGoods updGoods = new ZooGoods() ;
            updGoods.GoodsType = type;
            updGoods.Measure = measure;
            updGoods.ProductCode = productCode;
            updGoods.Name = name;               
            bool upd = ZooGoods.UpdGoods(updGoods);
             }

        //Add new goods to the Goods List
        private static void AddGoodsToList(ZooGoods zooGoods) {
            Console.WriteLine("Enter Product code:");
            string productCodeStr = Console.ReadLine();
            int productCode = CheckProductCode(productCodeStr);
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Meausure:");
            string measure = Console.ReadLine();
            ZooGoods.AddZooGood( new ZooGoods { ProductCode = productCode, Name = name, Measure = measure, GoodsType=type });
        }

        //Check if Product Code is valid
        private static int CheckProductCode(string productCodeStr) {
            int productCode;
            if (!int.TryParse(productCodeStr, out productCode)) {
                Console.WriteLine("Must be integer");
            }
            return productCode;
        }
    }
}
