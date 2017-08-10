using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    // Interface to support user's methods: login, logout, register, change data
    public interface IUsers { 
        bool Login(string userLogin, string userPwd);
        bool Logout(string userLogin);
        bool Register(string userLogin, string userPwd);
        bool ChangeData(string userLogin, string newPwd);
    }
}
