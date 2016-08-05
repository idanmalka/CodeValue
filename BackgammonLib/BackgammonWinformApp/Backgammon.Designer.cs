using System.Windows.Forms;

namespace BackgammonWinformApp
{
    partial class BackGammon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackGammon));
            this.label1 = new System.Windows.Forms.Label();
            this.DiceRollButton = new System.Windows.Forms.Button();
            this.FirstDiceLabel = new System.Windows.Forms.Label();
            this.SecondDiceLable = new System.Windows.Forms.Label();
            this.FirstDiceButton = new System.Windows.Forms.Button();
            this.SecondDiceButton = new System.Windows.Forms.Button();
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ButtonTools = new System.Windows.Forms.Button[26];
            this.LabelWhiteEaten = new System.Windows.Forms.Label();
            this.LabelBlackEaten = new System.Windows.Forms.Label();
            this.ButtonTools[0] = new System.Windows.Forms.Button();
            this.ButtonTools[1] = new System.Windows.Forms.Button();
            this.ButtonTools[2] = new System.Windows.Forms.Button();
            this.ButtonTools[3] = new System.Windows.Forms.Button();
            this.ButtonTools[4] = new System.Windows.Forms.Button();
            this.ButtonTools[5] = new System.Windows.Forms.Button();
            this.ButtonTools[6] = new System.Windows.Forms.Button();
            this.ButtonTools[7] = new System.Windows.Forms.Button();
            this.ButtonTools[8] = new System.Windows.Forms.Button();
            this.ButtonTools[9] = new System.Windows.Forms.Button();
            this.ButtonTools[10] = new System.Windows.Forms.Button();
            this.ButtonTools[11] = new System.Windows.Forms.Button();
            this.ButtonTools[12] = new System.Windows.Forms.Button();
            this.ButtonTools[13] = new System.Windows.Forms.Button();
            this.ButtonTools[14] = new System.Windows.Forms.Button();
            this.ButtonTools[15] = new System.Windows.Forms.Button();
            this.ButtonTools[16] = new System.Windows.Forms.Button();
            this.ButtonTools[17] = new System.Windows.Forms.Button();
            this.ButtonTools[18] = new System.Windows.Forms.Button();
            this.ButtonTools[19] = new System.Windows.Forms.Button();
            this.ButtonTools[20] = new System.Windows.Forms.Button();
            this.ButtonTools[21] = new System.Windows.Forms.Button();
            this.ButtonTools[22] = new System.Windows.Forms.Button();
            this.ButtonTools[23] = new System.Windows.Forms.Button();
            this.ButtonTools[24] = new System.Windows.Forms.Button();
            this.ButtonTools[25] = new System.Windows.Forms.Button();

            this.SuspendLayout();
            //
            //Label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Log:";
            // 
            // DiceRollButton
            // 
            this.DiceRollButton.Location = new System.Drawing.Point(645, 12);
            this.DiceRollButton.Name = "DiceRollButton";
            this.DiceRollButton.Size = new System.Drawing.Size(69, 39);
            this.DiceRollButton.TabIndex = 0;
            this.DiceRollButton.Text = "Roll Dice";
            this.DiceRollButton.UseVisualStyleBackColor = true;
            this.DiceRollButton.Click += new System.EventHandler(this.DiceRollButton_Click);
            // 
            // FirstDiceLabel
            // 
            this.FirstDiceLabel.AutoSize = true;
            this.FirstDiceLabel.Location = new System.Drawing.Point(642, 68);
            this.FirstDiceLabel.Name = "FirstDiceLabel";
            this.FirstDiceLabel.Size = new System.Drawing.Size(35, 13);
            this.FirstDiceLabel.TabIndex = 1;
            this.FirstDiceLabel.Text = "Dice1";
            // 
            // SecondDiceLable
            // 
            this.SecondDiceLable.AutoSize = true;
            this.SecondDiceLable.Location = new System.Drawing.Point(642, 161);
            this.SecondDiceLable.Name = "SecondDiceLable";
            this.SecondDiceLable.Size = new System.Drawing.Size(35, 13);
            this.SecondDiceLable.TabIndex = 2;
            this.SecondDiceLable.Text = "Dice2";
            // 
            // FirstDiceButton
            // 
            this.FirstDiceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FirstDiceButton.BackgroundImage")));
            this.FirstDiceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FirstDiceButton.Location = new System.Drawing.Point(648, 84);
            this.FirstDiceButton.Name = "FirstDiceButton";
            this.FirstDiceButton.Size = new System.Drawing.Size(65, 64);
            this.FirstDiceButton.TabIndex = 3;
            this.FirstDiceButton.UseVisualStyleBackColor = true;
            this.FirstDiceButton.Click += new System.EventHandler(this.FirstDiceButton_Click);
            // 
            // SecondDiceButton
            // 
            this.SecondDiceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SecondDiceButton.BackgroundImage")));
            this.SecondDiceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SecondDiceButton.Location = new System.Drawing.Point(648, 177);
            this.SecondDiceButton.Name = "SecondDiceButton";
            this.SecondDiceButton.Size = new System.Drawing.Size(65, 64);
            this.SecondDiceButton.TabIndex = 4;
            this.SecondDiceButton.UseVisualStyleBackColor = true;
            this.SecondDiceButton.Click += new System.EventHandler(this.secondDiceButton_Click);
            // 
            // TextArea
            // 
            this.TextArea.Location = new System.Drawing.Point(4, 25);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(95, 440);
            this.TextArea.TabIndex = 5;
            this.TextArea.Text = "Welcome!";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(275, 159);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(213, 99);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "START\nPlease Follow the Log to the left for instructions";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // button1
            // 
            this.ButtonTools[1].Location = new System.Drawing.Point(570, 28);
            this.ButtonTools[1].Name = "1";
            this.ButtonTools[1].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[1].TabIndex = 7;
            this.ButtonTools[1].UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.ButtonTools[2].Location = new System.Drawing.Point(534, 28);
            this.ButtonTools[2].Name = "2";
            this.ButtonTools[2].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[2].TabIndex = 8;
            this.ButtonTools[2].UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.ButtonTools[3].Location = new System.Drawing.Point(498, 28);
            this.ButtonTools[3].Name = "3";
            this.ButtonTools[3].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[3].TabIndex = 9;
            this.ButtonTools[3].UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.ButtonTools[4].Location = new System.Drawing.Point(462, 28);
            this.ButtonTools[4].Name = "4";
            this.ButtonTools[4].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[4].TabIndex = 10;
            this.ButtonTools[4].UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.ButtonTools[5].Location = new System.Drawing.Point(426, 28);
            this.ButtonTools[5].Name = "5";
            this.ButtonTools[5].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[5].TabIndex = 11;
            this.ButtonTools[5].UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.ButtonTools[6].Location = new System.Drawing.Point(390, 28);
            this.ButtonTools[6].Name = "6";
            this.ButtonTools[6].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[6].TabIndex = 12;
            this.ButtonTools[6].UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.ButtonTools[7].Location = new System.Drawing.Point(310, 28);
            this.ButtonTools[7].Name = "7";
            this.ButtonTools[7].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[7].TabIndex = 13;
            this.ButtonTools[7].UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.ButtonTools[8].Location = new System.Drawing.Point(274, 28);
            this.ButtonTools[8].Name = "8";
            this.ButtonTools[8].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[8].TabIndex = 14;
            this.ButtonTools[8].UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.ButtonTools[9].Location = new System.Drawing.Point(238, 28);
            this.ButtonTools[9].Name = "9";
            this.ButtonTools[9].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[9].TabIndex = 15;
            this.ButtonTools[9].UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.ButtonTools[10].Location = new System.Drawing.Point(202, 28);
            this.ButtonTools[10].Name = "10";
            this.ButtonTools[10].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[10].TabIndex = 16;
            this.ButtonTools[10].UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.ButtonTools[11].Location = new System.Drawing.Point(166, 28);
            this.ButtonTools[11].Name = "11";
            this.ButtonTools[11].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[11].TabIndex = 17;
            this.ButtonTools[11].UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.ButtonTools[12].Location = new System.Drawing.Point(130, 28);
            this.ButtonTools[12].Name = "12";
            this.ButtonTools[12].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[12].TabIndex = 18;
            this.ButtonTools[12].UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.ButtonTools[13].Location = new System.Drawing.Point(130, 415);
            this.ButtonTools[13].Name = "13";
            this.ButtonTools[13].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[13].TabIndex = 19;
            this.ButtonTools[13].UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.ButtonTools[14].Location = new System.Drawing.Point(166, 415);
            this.ButtonTools[14].Name = "14";
            this.ButtonTools[14].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[14].TabIndex = 20;
            this.ButtonTools[14].UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.ButtonTools[15].Location = new System.Drawing.Point(202, 415);
            this.ButtonTools[15].Name = "5";
            this.ButtonTools[15].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[15].TabIndex = 21;
            this.ButtonTools[15].UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.ButtonTools[16].Location = new System.Drawing.Point(238, 415);
            this.ButtonTools[16].Name = "16";
            this.ButtonTools[16].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[16].TabIndex = 22;
            this.ButtonTools[16].UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.ButtonTools[17].Location = new System.Drawing.Point(274, 415);
            this.ButtonTools[17].Name = "17";
            this.ButtonTools[17].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[17].TabIndex = 23;
            this.ButtonTools[17].UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.ButtonTools[18].Location = new System.Drawing.Point(310, 415);
            this.ButtonTools[18].Name = "18";
            this.ButtonTools[18].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[18].TabIndex = 24;
            this.ButtonTools[18].UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.ButtonTools[19].Location = new System.Drawing.Point(390, 415);
            this.ButtonTools[19].Name = "19";
            this.ButtonTools[19].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[19].TabIndex = 25;
            this.ButtonTools[19].UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.ButtonTools[20].Location = new System.Drawing.Point(426, 415);
            this.ButtonTools[20].Name = "20";
            this.ButtonTools[20].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[20].TabIndex = 26;
            this.ButtonTools[20].UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.ButtonTools[21].Location = new System.Drawing.Point(462, 415);
            this.ButtonTools[21].Name = "21";
            this.ButtonTools[21].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[21].TabIndex = 27;
            this.ButtonTools[21].UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.ButtonTools[22].Location = new System.Drawing.Point(498, 415);
            this.ButtonTools[22].Name = "22";
            this.ButtonTools[22].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[22].TabIndex = 28;
            this.ButtonTools[22].UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.ButtonTools[23].Location = new System.Drawing.Point(534, 415);
            this.ButtonTools[23].Name = "23";
            this.ButtonTools[23].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[23].TabIndex = 29;
            this.ButtonTools[23].UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.ButtonTools[24].Location = new System.Drawing.Point(570, 415);
            this.ButtonTools[24].Name = "24";
            this.ButtonTools[24].Size = new System.Drawing.Size(30, 23);
            this.ButtonTools[24].TabIndex = 30;
            this.ButtonTools[24].UseVisualStyleBackColor = true;
            //
            // 
            // button1
            // 
            this.ButtonTools[25].BackgroundImage = Properties.Resources.black;
            this.ButtonTools[25].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonTools[25].Location = new System.Drawing.Point(349, 121);
            this.ButtonTools[25].Name = "25";
            this.ButtonTools[25].Size = new System.Drawing.Size(32, 27);
            this.ButtonTools[25].TabIndex = 31;
            this.ButtonTools[25].UseVisualStyleBackColor = true;
            this.ButtonTools[25].Visible = false;
            // 
            // button2
            // 
            this.ButtonTools[0].BackgroundImage = Properties.Resources.white;
            this.ButtonTools[0].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonTools[0].Location = new System.Drawing.Point(349, 68);
            this.ButtonTools[0].Name = "0";
            this.ButtonTools[0].Size = new System.Drawing.Size(32, 27);
            this.ButtonTools[0].TabIndex = 32;
            this.ButtonTools[0].UseVisualStyleBackColor = true;
            this.ButtonTools[0].Visible = false;
            // 
            // LabelWhiteEaten
            // 
            this.LabelWhiteEaten.AutoSize = true;
            this.LabelWhiteEaten.Location = new System.Drawing.Point(346, 98);
            this.LabelWhiteEaten.Name = "label1";
            this.LabelWhiteEaten.Size = new System.Drawing.Size(38, 13);
            this.LabelWhiteEaten.TabIndex = 33;
            this.LabelWhiteEaten.Text = "0";
            this.LabelWhiteEaten.Visible = false;
            // 
            // LabelBlackEaten
            // 
            this.LabelBlackEaten.AutoSize = true;
            this.LabelBlackEaten.Location = new System.Drawing.Point(346, 151);
            this.LabelBlackEaten.Name = "label2";
            this.LabelBlackEaten.Size = new System.Drawing.Size(34, 13);
            this.LabelBlackEaten.TabIndex = 34;
            this.LabelBlackEaten.Text = "0";
           this.LabelBlackEaten.Visible = false;
            //
            // Handler for buttons
            //
            for (int i = 0; i < 26; i++)
                this.ButtonTools[i].Click += new System.EventHandler(this.buttonTool_Click);
            // 
            // BackGammon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(729, 467);
            this.Controls.Add(this.ButtonTools[25]);
            this.Controls.Add(this.ButtonTools[24]);
            this.Controls.Add(this.ButtonTools[23]);
            this.Controls.Add(this.ButtonTools[22]);
            this.Controls.Add(this.ButtonTools[21]);
            this.Controls.Add(this.ButtonTools[20]);
            this.Controls.Add(this.ButtonTools[19]);
            this.Controls.Add(this.ButtonTools[18]);
            this.Controls.Add(this.ButtonTools[17]);
            this.Controls.Add(this.ButtonTools[16]);
            this.Controls.Add(this.ButtonTools[15]);
            this.Controls.Add(this.ButtonTools[14]);
            this.Controls.Add(this.ButtonTools[13]);
            this.Controls.Add(this.ButtonTools[12]);
            this.Controls.Add(this.ButtonTools[11]);
            this.Controls.Add(this.ButtonTools[10]);
            this.Controls.Add(this.ButtonTools[9]);
            this.Controls.Add(this.ButtonTools[8]);
            this.Controls.Add(this.ButtonTools[7]);
            this.Controls.Add(this.ButtonTools[6]);
            this.Controls.Add(this.ButtonTools[5]);
            this.Controls.Add(this.ButtonTools[4]);
            this.Controls.Add(this.ButtonTools[3]);
            this.Controls.Add(this.ButtonTools[2]);
            this.Controls.Add(this.ButtonTools[1]);
            this.Controls.Add(this.ButtonTools[0]);
            this.Controls.Add(this.LabelBlackEaten);
            this.Controls.Add(this.LabelWhiteEaten);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.SecondDiceButton);
            this.Controls.Add(this.FirstDiceButton);
            this.Controls.Add(this.SecondDiceLable);
            this.Controls.Add(this.FirstDiceLabel);
            this.Controls.Add(this.DiceRollButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackGammon";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackGammon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button StartButton;// { private set; get; }
        public System.Windows.Forms.Button DiceRollButton;// { private set; get; }
        public System.Windows.Forms.Label FirstDiceLabel;// { private set; get; }
        public System.Windows.Forms.Label SecondDiceLable;// { private set; get; }
        public System.Windows.Forms.Button FirstDiceButton;// { private set; get; }
        public System.Windows.Forms.Button SecondDiceButton;// { private set; get; }
        public System.Windows.Forms.RichTextBox TextArea;// { private set; get; }
        public System.Windows.Forms.Button[] ButtonTools;
        public System.Windows.Forms.Label LabelBlackEaten;
        public System.Windows.Forms.Label LabelWhiteEaten;
        public System.Windows.Forms.Label label1;



    }
}

