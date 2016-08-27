using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundPrimeCalc
{
    //Nice job
    public partial class Form1 : Form
    {
        private readonly BackgroundWorker _worker;
        private IEnumerable _resList;
        public Form1()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += WorkerDoWork;
            _worker.RunWorkerCompleted += WorkComplete;
            _worker.WorkerSupportsCancellation = true;
            _worker.WorkerReportsProgress = true;
            _worker.ProgressChanged += ProgressReport;

            InitializeComponent();
        }

        private void ProgressReport(object sender, ProgressChangedEventArgs args)
        {
            ProgressBar.Value = args.ProgressPercentage;
        }

        private void WorkComplete(object sender, EventArgs args)
        {
        }

        private void WorkerDoWork(object sender, EventArgs args)
        {
            int first, last;
            int.TryParse(FirstNumberBox.Text, out first);
            int.TryParse(LastNumberBox.Text, out last);
            try
            {
                _resList = Enumerable.Range(first, last).Select(x => x).Where(IsPrime);
                foreach (var num in _resList)
                {
                    Invoke(new Action(() => ResultsListBox.Items.Add(num)));
                }
            }
            catch(OperationCanceledException)
            {
               Invoke(new Action(()=> ResultsListBox.Items.Add("Canceled")));
            }

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (_worker.IsBusy) return;
            ResultsListBox.Items.Clear();
            ProgressBar.Value = 0;
            _worker.RunWorkerAsync();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();

        }

        private bool IsPrime(int x)
        {
            int first, last;
            int.TryParse(FirstNumberBox.Text, out first);
            int.TryParse(LastNumberBox.Text, out last);
            _worker.ReportProgress(100*(x-first)/(last-first+1));
            if (x < 0) throw new ArgumentOutOfRangeException();
            if (x == 1) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if(_worker.CancellationPending) throw new OperationCanceledException();
                if (x%i == 0) return false;
            }
            return true;
        }

    }
}
