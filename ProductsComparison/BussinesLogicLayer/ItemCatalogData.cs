using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    public class ItemCatalogData
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public double Ammount { get; set; }
        public Dictionary<string,double> PricesByChainName {get; set; }
        public ItemGeneralData GeneralData { get; set; }  

        public ItemCatalogData(ItemGeneralData src)
        {
            ItemId = src.ItemId;
            ItemName = src.ItemName;
            Category = src.ItemCategory;
            Ammount = src.Ammount;
            PricesByChainName = new Dictionary<string, double>();
            GeneralData = src;
        }

        public static implicit operator ItemCatalogData(ItemGeneralData src)
        {
            return new ItemCatalogData(src);
        }
    }
}
