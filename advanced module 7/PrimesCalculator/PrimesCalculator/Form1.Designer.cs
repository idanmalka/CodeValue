namespace PrimesCalculator
{
    partial class Form1
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
            this.Results = new System.Windows.Forms.ListBox();
            this.CalcButton = new System.Windows.Forms.Button();
            this.firstNumberText = new System.Windows.Forms.TextBox();
            this.LastNumberText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Results
            // 
            this.Results.FormattingEnabled = true;
            this.Results.Location = new System.Drawing.Point(153, 2);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(120, 173);
            this.Results.TabIndex = 0;
            // 
            // CalcButton
            // 
            this.CalcButton.Location = new System.Drawing.Point(37, 12);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(75, 23);
            this.CalcButton.TabIndex = 1;
            this.CalcButton.Text = "Calculate";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // firstNumberText
            // 
            this.firstNumberText.Location = new System.Drawing.Point(27, 56);
            this.firstNumberText.Name = "firstNumberText";
            this.firstNumberText.Size = new System.Drawing.Size(100, 20);
            this.firstNumberText.TabIndex = 2;
            // 
            // LastNumberText
            // 
            this.LastNumberText.Location = new System.Drawing.Point(27, 101);
            this.LastNumberText.Name = "LastNumberText";
            this.LastNumberText.Size = new System.Drawing.Size(100, 20);
            this.LastNumberText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "First:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(37, 141);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 176);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastNumberText);
            this.Controls.Add(this.firstNumberText);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.Results);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Results;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.TextBox firstNumberText;
        private System.Windows.Forms.TextBox LastNumberText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
    }
}

