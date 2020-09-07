namespace AsyncDemo
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
            this.firstNumber = new System.Windows.Forms.TextBox();
            this.lastNumber = new System.Windows.Forms.TextBox();
            this.ResultBox = new System.Windows.Forms.ListBox();
            this.Compute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNumber
            // 
            this.firstNumber.Location = new System.Drawing.Point(13, 35);
            this.firstNumber.Name = "firstNumber";
            this.firstNumber.Size = new System.Drawing.Size(100, 20);
            this.firstNumber.TabIndex = 0;
            // 
            // lastNumber
            // 
            this.lastNumber.Location = new System.Drawing.Point(13, 85);
            this.lastNumber.Name = "lastNumber";
            this.lastNumber.Size = new System.Drawing.Size(100, 20);
            this.lastNumber.TabIndex = 1;
            // 
            // ResultBox
            // 
            this.ResultBox.FormattingEnabled = true;
            this.ResultBox.Location = new System.Drawing.Point(119, 12);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(120, 95);
            this.ResultBox.TabIndex = 2;
            // 
            // Compute
            // 
            this.Compute.Location = new System.Drawing.Point(245, 38);
            this.Compute.Name = "Compute";
            this.Compute.Size = new System.Drawing.Size(63, 43);
            this.Compute.TabIndex = 3;
            this.Compute.Text = "Compute";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "First:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Compute);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.lastNumber);
            this.Controls.Add(this.firstNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNumber;
        private System.Windows.Forms.TextBox lastNumber;
        private System.Windows.Forms.ListBox ResultBox;
        private System.Windows.Forms.Button Compute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

