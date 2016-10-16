using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Serializable]
    public class ItemGeneralData
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        
        /*
         This design is very specific to the minimal requirements of the assignment, 
         And does not support addition of more stores, in example..
         A simple string (chain id) -> string (item code) dictionary would do just fine, don't you think?
        
             */
        public string ShufersalItemCode { get; set; }
        public string RamiLeviItemCode { get; set; }
        public string VictoryItemCode { get; set; }
        public double Ammount { get; set; }
    }
}
