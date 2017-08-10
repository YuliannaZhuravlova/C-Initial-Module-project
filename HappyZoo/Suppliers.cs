using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    // Type of Partner which can add stuff to warehouse
    public class Suppliers: Partners { 
       
        public override PartnerType PartnerType { get { return PartnerType.Supplier; } }
    }
}
