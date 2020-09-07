using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DataAccessLayer;

namespace BussinesLogicLayer
{

    public class Cart
    {
        private readonly List<ItemCatalogData> _items;

        public Cart()
        {
            _items= new List<ItemCatalogData>();
        }

        public Cart(List<ItemGeneralData> items)
        {
            _items = new List<ItemCatalogData>();
            foreach (var item in items)
            {
                _items.Add(new ItemCatalogData(item));
            }
        }

        public void Add(ItemCatalogData item)
        {
            if (_items.Contains(item)) return;

            _items.Add(item);
        }

        public IEnumerable<ItemCatalogData> GetItemsList()
        {
            return new List<ItemCatalogData>(_items);
        }

        public double GetTotalPriceByChain(string chain)
        {
            try
            {
                return _items.Select(i => i.PricesByChainName[chain]*i.Ammount).Sum();
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public IEnumerable<Tuple<string, double, double>> GetSortedDescendingItemsByChainName(string chain)
        {

            if(_items[0].PricesByChainName.ContainsKey("Error"))
                return new List<Tuple<string, double, double>> { new Tuple<string, double, double>("קובץ שגוי",0,0) };
            
            return
                _items.Select(
                        i => new Tuple<string, double, double>(i.ItemName, i.PricesByChainName[chain], i.Ammount))
                    .OrderByDescending(i => i.Item2);
        }
    }
}