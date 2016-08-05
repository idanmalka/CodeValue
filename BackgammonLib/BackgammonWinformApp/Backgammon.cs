using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgammonLib;

namespace BackgammonWinformApp
{
    public partial class BackGammon : Form
    {
        public bool DiceRolled { set; get; }
        public bool FirstDiceSelected { set; get; }
        public bool SecondDiceSelected { set; get; }
        public int StepSelected { set; get; }
        public bool IsStepSelected { set; get; }

        public BackGammon()
        {
            InitializeComponent(); 
        }

        public void ClearLog()
        {
            Invoke((MethodInvoker)delegate {
                TextArea.Text = ""; // runs on UI thread
            });
        }
        private void DiceRollButton_Click(object sender, EventArgs e)
        {
            DiceRolled = true;
        }

        private void FirstDiceButton_Click(object sender, EventArgs e)
        {
            FirstDiceSelected = true;
        }

        private void secondDiceButton_Click(object sender, EventArgs e)
        {
            SecondDiceSelected = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Button startButton = (Button) sender;
            startButton.Visible = false;
        }

        private void buttonTool_Click(object sender, EventArgs e)
        {
            int step;
            int.TryParse(((System.Windows.Forms.Button) sender).Name, out step);
            StepSelected = step;
            IsStepSelected = true;
        }

    }
}
