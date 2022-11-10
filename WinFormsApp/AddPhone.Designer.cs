namespace Phoneshop.WinForms
{
    partial class AddPhone
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
            this.BrandtextBox = new System.Windows.Forms.TextBox();
            this.TypetextBox = new System.Windows.Forms.TextBox();
            this.DescriptiontextBox = new System.Windows.Forms.TextBox();
            this.PricetextBox = new System.Windows.Forms.TextBox();
            this.StocktextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrandtextBox
            // 
            this.BrandtextBox.Location = new System.Drawing.Point(49, 42);
            this.BrandtextBox.Name = "BrandtextBox";
            this.BrandtextBox.Size = new System.Drawing.Size(125, 27);
            this.BrandtextBox.TabIndex = 0;
            // 
            // TypetextBox
            // 
            this.TypetextBox.Location = new System.Drawing.Point(49, 101);
            this.TypetextBox.Name = "TypetextBox";
            this.TypetextBox.Size = new System.Drawing.Size(125, 27);
            this.TypetextBox.TabIndex = 1;
           
            // 
            // DescriptiontextBox
            // 
            this.DescriptiontextBox.Location = new System.Drawing.Point(49, 162);
            this.DescriptiontextBox.Name = "DescriptiontextBox";
            this.DescriptiontextBox.Size = new System.Drawing.Size(125, 27);
            this.DescriptiontextBox.TabIndex = 2;
            // 
            // PricetextBox
            // 
            this.PricetextBox.Location = new System.Drawing.Point(49, 223);
            this.PricetextBox.Name = "PricetextBox";
            this.PricetextBox.Size = new System.Drawing.Size(125, 27);
            this.PricetextBox.TabIndex = 3;
            // 
            // StocktextBox
            // 
            this.StocktextBox.Location = new System.Drawing.Point(49, 285);
            this.StocktextBox.Name = "StocktextBox";
            this.StocktextBox.Size = new System.Drawing.Size(125, 27);
            this.StocktextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price";
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Stock";
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(60, 347);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 12;
            this.DoneButton.Text = "button1";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // AddPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StocktextBox);
            this.Controls.Add(this.PricetextBox);
            this.Controls.Add(this.DescriptiontextBox);
            this.Controls.Add(this.TypetextBox);
            this.Controls.Add(this.BrandtextBox);
            this.Name = "AddPhone";
            this.Text = "AddPhone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox BrandtextBox;
        private TextBox TypetextBox;
        private TextBox DescriptiontextBox;
        private TextBox PricetextBox;
        private TextBox StocktextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button DoneButton;
    }
}