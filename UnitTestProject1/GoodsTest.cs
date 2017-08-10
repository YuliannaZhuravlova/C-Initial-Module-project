using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyZoo;

namespace UnitTestProject1 {
    [TestClass]
    public class GoodsTest {
        private int count;

        [TestMethod]
        public void AddGoodTest() { // Test add new goods
            //--Arrange
            ZooGoods new1 = new WetFood();
            new1.ProductCode = 1;
            ZooGoods.AddZooGood(new1);
            ZooGoods new2 = new DryFood();
            new2.ProductCode = 2;
            ZooGoods.AddZooGood(new2);
            
            //--Act
              ZooGoods goods1= ZooGoods.GetGood(1);

            //--Assert
            Assert.AreEqual(goods1, new1);
            
        }

        [TestMethod]
        public void ValidateValidTest() { //Test validate Measure is filled
            //-- Arrange
            var goods = new ZooGoods();
            goods.Name = "Kiltix";
            goods.Measure = "Piece";
            var expected = true;
          
            //--Act
            var actual = goods.Validate();
           
            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingMeasure() { // Test validate Measure is empty
            //-- Arrange
            var goods = new ZooGoods();
            goods.Name = "Felix";
                var expected = false;
            
            //--Act
            var actual = goods.Validate();
            
            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFoodGoodsTypeTest() { // Test return correct Goods Type
            //--Arrange
            var food = new Food();
           string expected = "Food";
           
            //--Act
            string actual = food.GoodsType;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWetFoodGoodsTypeTest() { // Test return correct Wet Goods Type
            //--Arrange
            var wetfood = new WetFood();
            string expected = "WetFood";

            //--Act
            string actual = wetfood.FoodType;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDryFoodGoodsTypeTest() {// Test return correct Dry Goods Type
            //--Arrange
            var dryfood = new DryFood();
            string expected = "DryFood";

            //--Act
            string actual = dryfood.FoodType;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountStuffTest() {// Test to return correct number of stuff in warehouse
            
            //--Arrange
            ZooGoods.AddZooGood(new WetFood { ProductCode = 10});
            Warehouse warehouse = new Warehouse(new Suppliers());
            warehouse.AddStuffNoAuthCheck(10, 30);
            
            //--Act
            count =warehouse.CountStuff(10);
            
            //--Assert
            Assert.AreEqual(count, 30);
        }
    }
}
