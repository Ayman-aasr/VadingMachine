
namespace VendingMacine
{
    partial class VendingMacineForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdButtonPayCash = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 623);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.rdButtonPayCash);
            this.panel2.Location = new System.Drawing.Point(5, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 384);
            this.panel2.TabIndex = 0;
            // 
            // rdButtonPayCash
            // 
            this.rdButtonPayCash.AutoSize = true;
            this.rdButtonPayCash.Location = new System.Drawing.Point(5, 31);
            this.rdButtonPayCash.Name = "rdButtonPayCash";
            this.rdButtonPayCash.Size = new System.Drawing.Size(70, 17);
            this.rdButtonPayCash.TabIndex = 0;
            this.rdButtonPayCash.TabStop = true;
            this.rdButtonPayCash.Text = "Pay Cash";
            this.rdButtonPayCash.UseVisualStyleBackColor = true;
            this.rdButtonPayCash.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // VendingMacineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 627);
            this.Controls.Add(this.panel1);
            this.Name = "VendingMacineForm";
            this.Text = "Vending Macine";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdButtonPayCash;
    }
}

