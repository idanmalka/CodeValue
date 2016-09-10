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
        public string ShufersalItemCode { get; set; }
        public string RamiLeviItemCode { get; set; }
        public string VictoryItemCode { get; set; }
        public double Ammount { get; set; }
    }
}
