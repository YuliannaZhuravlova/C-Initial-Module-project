using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    // Clients are partners who can get stuff from Warehouse
    public class Clients : Partners { 
        public override PartnerType PartnerType  { get{return PartnerType.Client;} }
    }
}
