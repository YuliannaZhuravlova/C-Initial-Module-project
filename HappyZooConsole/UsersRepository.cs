using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyZoo;

namespace HappyZooConsole {
    public static class UsersRepository {
        public static List<IUsers> Users = new List<IUsers> {
            new Clients {UserLogin = "JAZ",Password="1", PartnerName="Yulianna" , Phone="0001"},
            new Clients {UserLogin = "VPV",Password="3", PartnerName="Volodymyr" , Phone="331"},
            new Suppliers {UserLogin = "HNB",Password="2", PartnerName = "Elena", Phone ="222"},
            new Suppliers {UserLogin = "IRSP",Password="3", PartnerName = "Iryna", Phone ="444"},
        };
            }
}
