using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
   public class WrongUserRoleException:Exception {
        /* Will be used to restrict user's roles:
         Client = 0 - can get stuff from warehouse, but can't add stuff to warehouse
        Supplier= 1 - can add stuff to warehouse, but can't retrieve it
         */
    }
}
