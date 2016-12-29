namespace ODXConverter
{
    partial class NewForm
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
        /// the contents of this method with the code 
        /// or.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDTCShortName = new System.Windows.Forms.TextBox();
            this.tbDTCDisplayTrobuleCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDTCNumber = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 253);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbDTCShortName);
            this.panel2.Controls.Add(this.tbDTCDisplayTrobuleCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.tbDTCName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbDTCNumber);
            this.panel2.Location = new System.Drawing.Point(20, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 217);
            this.panel2.TabIndex = 5;
            // 
            // tbDTCShortName
            // 
            this.tbDTCShortName.Location = new System.Drawing.Point(167, 96);
            this.tbDTCShortName.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tbDTCShortName.Name = "tbDTCShortName";
            this.tbDTCShortName.Size = new System.Drawing.Size(200, 20);
            this.tbDTCShortName.TabIndex = 8;
            // 
            // tbDTCDisplayTrobuleCode
            // 
            this.tbDTCDisplayTrobuleCode.Location = new System.Drawing.Point(167, 36);
            this.tbDTCDisplayTrobuleCode.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tbDTCDisplayTrobuleCode.Name = "tbDTCDisplayTrobuleCode";
            this.tbDTCDisplayTrobuleCode.Size = new System.Drawing.Size(200, 20);
            this.tbDTCDisplayTrobuleCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(9, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Short Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Display Trouble Code";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(122, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add DTC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDTCName
            // 
            this.tbDTCName.Location = new System.Drawing.Point(167, 65);
            this.tbDTCName.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tbDTCName.Name = "tbDTCName";
            this.tbDTCName.Size = new System.Drawing.Size(200, 20);
            this.tbDTCName.TabIndex = 3;
            this.tbDTCName.BackColorChanged += new System.EventHandler(this.tbDTCTextBox_BackColorChanged);
            this.tbDTCName.TextChanged += new System.EventHandler(this.tbDTCName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text";
            // 
            // tbDTCNumber
            // 
            this.tbDTCNumber.Location = new System.Drawing.Point(167, 7);
            this.tbDTCNumber.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tbDTCNumber.Name = "tbDTCNumber";
            this.tbDTCNumber.Size = new System.Drawing.Size(200, 20);
            this.tbDTCNumber.TabIndex = 2;
            this.tbDTCNumber.BackColorChanged += new System.EventHandler(this.tbDTCTextBox_BackColorChanged);
            this.tbDTCNumber.TextChanged += new System.EventHandler(this.tbDTCNumber_TextChanged);
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 278);
            this.Controls.Add(this.panel1);
            this.Name = "NewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add DTC / Add DID";
            this.Load += new System.EventHandler(this.NewForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDTCName;
        private System.Windows.Forms.TextBox tbDTCNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbDTCShortName;
        private System.Windows.Forms.TextBox tbDTCDisplayTrobuleCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}