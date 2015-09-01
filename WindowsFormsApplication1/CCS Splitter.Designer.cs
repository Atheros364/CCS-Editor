namespace WindowsFormsApplication1
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
            this.fileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitallButton = new System.Windows.Forms.Button();
            this.splitorderButton = new System.Windows.Forms.Button();
            this.splittimeButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(243, 34);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(75, 23);
            this.fileButton.TabIndex = 0;
            this.fileButton.Text = "Choose File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a .ccs file to split";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "CCS File";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitallButton
            // 
            this.splitallButton.Location = new System.Drawing.Point(31, 91);
            this.splitallButton.Name = "splitallButton";
            this.splitallButton.Size = new System.Drawing.Size(172, 23);
            this.splitallButton.TabIndex = 3;
            this.splitallButton.Text = "Split all of the segments";
            this.splitallButton.UseVisualStyleBackColor = true;
            this.splitallButton.Click += new System.EventHandler(this.splitallButton_Click);
            // 
            // splitorderButton
            // 
            this.splitorderButton.Location = new System.Drawing.Point(31, 139);
            this.splitorderButton.Name = "splitorderButton";
            this.splitorderButton.Size = new System.Drawing.Size(172, 23);
            this.splitorderButton.TabIndex = 4;
            this.splitorderButton.Text = "Split out of order segments";
            this.splitorderButton.UseVisualStyleBackColor = true;
            this.splitorderButton.Click += new System.EventHandler(this.splitorderButton_Click);
            // 
            // splittimeButton
            // 
            this.splittimeButton.Location = new System.Drawing.Point(31, 186);
            this.splittimeButton.Name = "splittimeButton";
            this.splittimeButton.Size = new System.Drawing.Size(172, 23);
            this.splittimeButton.TabIndex = 5;
            this.splittimeButton.Text = "Split segments at a certain time";
            this.splittimeButton.UseVisualStyleBackColor = true;
            this.splittimeButton.Click += new System.EventHandler(this.splittimeButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(218, 189);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            this.waterMarkActive = true;
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Text = "H:MM:SS";
            this.textBox2.GotFocus += timeBox_GotFocus;
            this.textBox2.LostFocus += timeBox_LostFocus;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 241);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.splittimeButton);
            this.Controls.Add(this.splitorderButton);
            this.Controls.Add(this.splitallButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileButton);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button splitallButton;
        private System.Windows.Forms.Button splitorderButton;
        private System.Windows.Forms.Button splittimeButton;
        private System.Windows.Forms.TextBox textBox2;

        public bool waterMarkActive;
    }
}

