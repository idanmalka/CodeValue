using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultBox.Items.Clear();
            Del d = Program.CalcPrimes;
            int first, last;
            int.TryParse(firstNumber.Text,out first);
            int.TryParse(lastNumber.Text, out last);
            d.BeginInvoke(first, last, SetResult, d);
        }

        private void SetResult(IAsyncResult ar)
        {
            IEnumerable<int> result = ((Del) ar.AsyncState).EndInvoke(ar);
            foreach (var num in result)
            {
                // invoke - synchronic , beginInvoke - Asynchronic
                // UI Blocked
                Invoke((MethodInvoker)delegate
                {
                    ResultBox.Items.Add(num); // runs on UI thread
                });
            }
        }
    }
}
