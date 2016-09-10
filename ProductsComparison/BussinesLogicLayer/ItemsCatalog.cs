using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    public class ItemsCatalog
    {
        private readonly Dictionary<string,List<ItemCatalogData>> _catalog;

        public ItemsCatalog()
        {
            _catalog = new Dictionary<string, List<ItemCatalogData>>();
        }

        public ItemsCatalog(IEnumerable<ItemCatalogData> data)
        {
            foreach (var item in data)
            {
                Add(item);
            }
        }

        public void Add(ItemCatalogData item)
        {
            var categoryKey = item.Category;

            if (!_catalog.ContainsKey(categoryKey))
                _catalog.Add(categoryKey,new List<ItemCatalogData>());

            if (!_catalog[categoryKey].Contains(item))
                _catalog[categoryKey].Add(item);
        }

        public void Remove(ItemCatalogData item)
        {
            var categoryKey = item.Category;

            if (!_catalog.ContainsKey(categoryKey)) return;

            _catalog[categoryKey].Remove(item);

            if (_catalog[categoryKey].Count == 0)
                _catalog.Remove(categoryKey);
        }

        public ItemCatalogData GetItemByName(string name)
        {

            return (from category in _catalog
                        from item in category.Value
                        where item.ItemName == name
                        select item).First();

        }

        public Dictionary<string, List<ItemCatalogData>> GetCatalog()
        {
            return new Dictionary<string,List<ItemCatalogData>>(_catalog);
        }

    }
}
