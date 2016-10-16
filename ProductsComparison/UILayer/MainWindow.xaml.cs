using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BussinesLogicLayer;
using Microsoft.Win32;

namespace UILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogicManager _manager;

        public MainWindow()
        {
            InitializeComponent();
            /*
             It is good that you thought of MVVM, but in a true MVVM application you would have no code in the *.xaml.cs of a file.
             This is easily accomplished with an MVVM framework.
             One of my favorites is Caliburn.Micro, but you can look others up - there are plenty.

             This should get you started with caliburn:
             http://caliburnmicro.com/
             */
            _manager = new LogicManager();
            TreeViewModel.SetTreeDesign(CatalogTree,_manager);
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = TreeViewModel.GetSelectedItems(CatalogTree.Items).ToArray();
            var numberOfItems = selectedItems.Length;
            var cart = new Cart();
            Task.Run(() => FillCart(selectedItems, cart, _manager))
                .ContinueWith(i => UpdateView(cart, numberOfItems));
        }

        /*When going the MVVM way, we do not use events, but instead Commands
         * 
         * Consider: https://msdn.microsoft.com/en-us/magazine/dn237302.aspx
         */
        private void SaveCartButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = TreeViewModel.GetSelectedItems(CatalogTree.Items).ToArray();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.Filter = "Text documents (.xml)|*.xml";
            var result = saveFileDialog.ShowDialog();
            var path = saveFileDialog.FileName;

            if (result == false)
                return;

            Task.Run(() =>
            {
                var cart = new Cart();

                FillCart(selectedItems, cart, _manager);
                _manager.SaveCartToFile(cart, path);
            });
        }

        private void LoadCartButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "Text documents (.xml)|*.xml";
            var result = openFileDialog.ShowDialog();
            var path = openFileDialog.FileName;

            if (result == false)
                return;

            Task.Run(() =>
            {
                var cart = _manager.LoadCartFromFile(path);
                var numberOfItems = cart.GetItemsList().Count();
                Dispatcher.InvokeAsync(() => {
                    _manager.UpdateCartData(cart.GetItemsList().ToList());
                    UpdateView(cart, numberOfItems);
                });
            });

        }

        //This belongs in a View Model- which is in charge of User Interaction Logic.
        private void UpdateView(Cart cart,int numberOfItems)
        {
            var ramiLeviPrice = cart.GetTotalPriceByChain("RamiLevi").ToString(CultureInfo.CurrentCulture);
            var shufersalPrice = cart.GetTotalPriceByChain("Shufersal").ToString(CultureInfo.CurrentCulture);
            var victoryPrice = cart.GetTotalPriceByChain("Victory").ToString(CultureInfo.CurrentCulture);

            var ramiLeviCart = cart.GetSortedDescendingItemsByChainName("RamiLevi").ToArray();
            var shufersalCart = cart.GetSortedDescendingItemsByChainName("Shufersal").ToArray();
            var victoryCart = cart.GetSortedDescendingItemsByChainName("Victory").ToArray();

            Dispatcher.InvokeAsync(() =>
            {
                RamiLeviPriceTextBlock.Text = ramiLeviPrice;
                ShufersalPriceTextBlock.Text = shufersalPrice;
                VictoryPriceTextBlock.Text = victoryPrice;

                RamiLeviCartListView.Items.Clear();
                ShufersalCartListView.Items.Clear();
                VictoryCartListView.Items.Clear();

                for (int i = 0; i < numberOfItems; i++)
                {
                    var color = GetColorByIndex(numberOfItems, i);
                    RamiLeviCartListView.Items.Add(new ListViewProduct { Name = ramiLeviCart[i].Item1, Price = ramiLeviCart[i].Item2, Ammount = ramiLeviCart[i].Item3, Color = color });
                    ShufersalCartListView.Items.Add(new ListViewProduct { Name = shufersalCart[i].Item1, Price = shufersalCart[i].Item2, Ammount = shufersalCart[i].Item3, Color = color });
                    VictoryCartListView.Items.Add(new ListViewProduct { Name = victoryCart[i].Item1, Price = victoryCart[i].Item2, Ammount = victoryCart[i].Item3, Color = color });
                }
            }); 
        }

        private static ListViewProduct.PriceMark GetColorByIndex(int numberOfItems, int i)
        {
            return (i == 0 || i == 1 || i == 2) ? ListViewProduct.PriceMark.Expansive 
                : (i == numberOfItems - 1 || i == numberOfItems - 2 || i == numberOfItems - 3) ? ListViewProduct.PriceMark.Cheap 
                : ListViewProduct.PriceMark.Natural;
        }

        private static void FillCart(IEnumerable<KeyValuePair<string, string>> selectedItems, Cart cart, LogicManager manager)
        {
            foreach (var item in selectedItems)
            {
                double ammountDummy;
                double.TryParse(item.Value, out ammountDummy);
                var itemTemp = manager.GetCatalogItems().GetItemByName(item.Key);
                itemTemp.Ammount = ammountDummy;
                cart.Add(itemTemp);
            }

            manager.UpdateCartData(cart.GetItemsList().ToList());
        }
    }
}
