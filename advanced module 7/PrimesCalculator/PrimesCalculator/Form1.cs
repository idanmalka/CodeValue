using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private readonly ManualResetEvent _stopResultsInputHandle = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            int first, last;
            int.TryParse(firstNumberText.Text, out first);
            int.TryParse(LastNumberText.Text, out last);
            ThreadPool.QueueUserWorkItem((x) => ThreadCode(first,last));
        }

        private void ThreadCode(int first,int last)
        {
            var list = Enumerable.Range(first, last).Select(y => y).Where(IsPrime);
            Invoke(new Action(() => Results.Items.Clear()));
            UpdateResults(list);
        }

        private void UpdateResults(IEnumerable<int> list)
        {
            foreach (var num in list)
            {
                if (!CancelationCheck()) return;
                Invoke(new Action(() => Results.Items.Add(num)));
                Thread.Sleep(100);
            }
        }

        private bool CancelationCheck()
        {
            if (!_stopResultsInputHandle.WaitOne(0)) return true;
            Invoke(new Action(() => Results.Items.Add("Canceled")));
            _stopResultsInputHandle.Reset();
            return false;
        }

        private static bool IsPrime(int x)
        {
            if (x < 0) throw new ArgumentOutOfRangeException();
            if (x == 1) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _stopResultsInputHandle.Set();
        }
    }
}
