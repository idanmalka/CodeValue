using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ItemFullData
    {
        public string ChainId { get; set; }
        public string ChainName { get; set; }
        public string StoreId { get; set; }
        public int ItemId { get; set; }
        public string LastUpdateDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ItemPrice { get; set; }
    }
}
