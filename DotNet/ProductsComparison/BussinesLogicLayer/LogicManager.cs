using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DataAccessLayer;


namespace BussinesLogicLayer
{
    public class LogicManager
    {

        private readonly List<ItemGeneralData> _itemsGeneralData;
        private ItemsCatalog _catalog;

        public LogicManager()
        {
            _itemsGeneralData = ItemGeneralDataLoader.GetItemsData();
        }

        public ItemsCatalog GetCatalogItems()
        {
            if (_catalog != null)
                return _catalog;

            _catalog = new ItemsCatalog();
            foreach (var item in _itemsGeneralData)
                _catalog.Add(item);
            return _catalog;
        }

        public void UpdateCartData(List<ItemCatalogData> cart)
        {
            var generalData = CatalogToGeneral(cart);
            var fullData = ItemsFullDataLoader.GetItemsData(generalData);

            foreach (var itemCatalogData in cart)
                UpdateItemDetails(itemCatalogData, fullData);
        }

        private static void UpdateItemDetails(ItemCatalogData itemCatalogData, Dictionary<int, List<ItemFullData>> fullData)
        {
            foreach (var item in fullData)
            {
                if (itemCatalogData.ItemId != item.Key) continue;
                UpdatePrices(itemCatalogData, item);
            }
        }

        private static void UpdatePrices(ItemCatalogData itemCatalogData, KeyValuePair<int, List<ItemFullData>> item)
        {
            foreach (var itemFullData in item.Value)
            {
                //Update catalog from full data
                double price;
                double.TryParse(itemFullData.ItemPrice, out price);

                if (!itemCatalogData.PricesByChainName.ContainsKey(itemFullData.ChainName))
                    itemCatalogData.PricesByChainName.Add(itemFullData.ChainName, 0);

                itemCatalogData.PricesByChainName[itemFullData.ChainName] = price;
            }
        }

        private static List<ItemGeneralData> CatalogToGeneral(List<ItemCatalogData> items)
        {
            var itemGeneralDatas = items.Select(i=>i.GeneralData).ToList();

            for (int i = 0; i < items.Count; i++)
                itemGeneralDatas[i].Ammount = items[i].Ammount;

            return itemGeneralDatas;
        }


        public void SaveCartToFile(Cart cart, string path)
        {
            var items = CatalogToGeneral(cart.GetItemsList().ToList());
            Task.Run(()=>ExistingShopingListAccess.SaveCartToFile(items,path));
        }

        public Cart LoadCartFromFile(string path)
        {
            return new Cart(ExistingShopingListAccess.LoadCartFromFile(path));
        }
    }
}
