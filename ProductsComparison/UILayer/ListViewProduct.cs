using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UILayer
{
    class ListViewProduct
    {
        public enum PriceMark
        {
            Natural = 0,
            Cheap = 1,
            Expansive = 2
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Ammount { get; set; }
        public PriceMark Color { get; set; }

    }
}
