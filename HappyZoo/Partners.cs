using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    // Registered users which have access to Goods and Warehouse
    public class Partners:IUsers { 
               public string PartnerName { get; set; } // Partner's name
        public string Phone { get; set; }
        public virtual PartnerType PartnerType { get; }

        public string UserLogin { get; set; } // Login to HappyZoo system
        public string Password { get; set; } // Password to HappyZoo system

        public bool Login(string userLogin, string userPwd) { // Method return 'true' if user is registered in HappyZoo system
            return (userLogin == UserLogin && userPwd == Password);
        }

        public bool Logout(string userLogin) { // Method to logout
            return true;
        }

        public bool Register(string userLogin, string userPwd) { 
            throw new NotImplementedException();
        }

        public bool ChangeData(string userLogin, string newPwd) { // Method to change pasword for existed user
            if(UserLogin != userLogin) {
                return false;
            }
            Password = newPwd;
            return true;
        }
    }

    public enum PartnerType // Types of partners to restric access to HappyZoo system
    {
        Client = 0, // Can get stuff from Warehouse
        Supplier=1, // Can add stuff to Warehouse
    }
}
