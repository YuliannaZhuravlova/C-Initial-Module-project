using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyZoo {
    // Just simple interface to cover Task #4
    public interface IZooGoods { 
        string GoodsType { get; set; }
        string Measure { get; set; }
        int ProductCode { get; set; }
    }
}
