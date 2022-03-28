
namespace VendingMacine
{
    partial class MainForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblToBeBalance = new System.Windows.Forms.Label();
            this.lbllCurrentBalance = new System.Windows.Forms.Label();
            this.txtMoneyRemaining = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTotalCashInserted = new System.Windows.Forms.TextBox();
            this.txtItemSelected = new System.Windows.Forms.TextBox();
            this.btnEndCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnFiftyDollar = new System.Windows.Forms.Button();
            this.btnTwentyDollar = new System.Windows.Forms.Button();
            this.btnOneDollar = new System.Windows.Forms.Button();
            this.btn50c = new System.Windows.Forms.Button();
            this.btn20c = new System.Windows.Forms.Button();
            this.btn10c = new System.Windows.Forms.Button();
            this.rdButtonCard = new System.Windows.Forms.RadioButton();
            this.rdButtonPayCash = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelItems = new System.Windows.Forms.Panel();
            this.btnSortByPrice = new System.Windows.Forms.Button();
            this.btnSortByName = new System.Windows.Forms.Button();
            this.txtSearchInput = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(222, 596);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblToBeBalance);
            this.panel1.Controls.Add(this.lbllCurrentBalance);
            this.panel1.Controls.Add(this.txtMoneyRemaining);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtTotalCashInserted);
            this.panel1.Controls.Add(this.txtItemSelected);
            this.panel1.Controls.Add(this.btnEndCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnFiftyDollar);
            this.panel1.Controls.Add(this.btnTwentyDollar);
            this.panel1.Controls.Add(this.btnOneDollar);
            this.panel1.Controls.Add(this.btn50c);
            this.panel1.Controls.Add(this.btn20c);
            this.panel1.Controls.Add(this.btn10c);
            this.panel1.Controls.Add(this.rdButtonCard);
            this.panel1.Controls.Add(this.rdButtonPayCash);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 593);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Snack Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total Cash Inserted";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total Cash to be Return";
            // 
            // lblToBeBalance
            // 
            this.lblToBeBalance.AutoSize = true;
            this.lblToBeBalance.Location = new System.Drawing.Point(13, 298);
            this.lblToBeBalance.Name = "lblToBeBalance";
            this.lblToBeBalance.Size = new System.Drawing.Size(87, 13);
            this.lblToBeBalance.TabIndex = 15;
            this.lblToBeBalance.Text = "To Be Balance:0";
            // 
            // lbllCurrentBalance
            // 
            this.lbllCurrentBalance.AutoSize = true;
            this.lbllCurrentBalance.Location = new System.Drawing.Point(10, 260);
            this.lbllCurrentBalance.Name = "lbllCurrentBalance";
            this.lbllCurrentBalance.Size = new System.Drawing.Size(95, 13);
            this.lbllCurrentBalance.TabIndex = 14;
            this.lbllCurrentBalance.Text = "Current Balance :0";
            // 
            // txtMoneyRemaining
            // 
            this.txtMoneyRemaining.Location = new System.Drawing.Point(10, 220);
            this.txtMoneyRemaining.Name = "txtMoneyRemaining";
            this.txtMoneyRemaining.ReadOnly = true;
            this.txtMoneyRemaining.Size = new System.Drawing.Size(190, 20);
            this.txtMoneyRemaining.TabIndex = 13;
            this.txtMoneyRemaining.Text = "0.00";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(10, 168);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(190, 20);
            this.txtPrice.TabIndex = 12;
            this.txtPrice.Text = "0.00";
            // 
            // txtTotalCashInserted
            // 
            this.txtTotalCashInserted.Location = new System.Drawing.Point(10, 126);
            this.txtTotalCashInserted.Name = "txtTotalCashInserted";
            this.txtTotalCashInserted.ReadOnly = true;
            this.txtTotalCashInserted.Size = new System.Drawing.Size(190, 20);
            this.txtTotalCashInserted.TabIndex = 11;
            this.txtTotalCashInserted.Text = "0.00";
            // 
            // txtItemSelected
            // 
            this.txtItemSelected.Location = new System.Drawing.Point(10, 72);
            this.txtItemSelected.Name = "txtItemSelected";
            this.txtItemSelected.ReadOnly = true;
            this.txtItemSelected.Size = new System.Drawing.Size(190, 20);
            this.txtItemSelected.TabIndex = 10;
            // 
            // btnEndCancel
            // 
            this.btnEndCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnEndCancel.Location = new System.Drawing.Point(115, 481);
            this.btnEndCancel.Name = "btnEndCancel";
            this.btnEndCancel.Size = new System.Drawing.Size(75, 38);
            this.btnEndCancel.TabIndex = 9;
            this.btnEndCancel.Text = "End/Cancle";
            this.btnEndCancel.UseVisualStyleBackColor = false;
            this.btnEndCancel.Click += new System.EventHandler(this.btnEndCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Green;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirm.Location = new System.Drawing.Point(16, 481);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 39);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnFiftyDollar
            // 
            this.btnFiftyDollar.Location = new System.Drawing.Point(153, 393);
            this.btnFiftyDollar.Name = "btnFiftyDollar";
            this.btnFiftyDollar.Size = new System.Drawing.Size(37, 23);
            this.btnFiftyDollar.TabIndex = 7;
            this.btnFiftyDollar.Text = "50 $";
            this.btnFiftyDollar.UseVisualStyleBackColor = true;
            this.btnFiftyDollar.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // btnTwentyDollar
            // 
            this.btnTwentyDollar.Location = new System.Drawing.Point(83, 393);
            this.btnTwentyDollar.Name = "btnTwentyDollar";
            this.btnTwentyDollar.Size = new System.Drawing.Size(37, 23);
            this.btnTwentyDollar.TabIndex = 6;
            this.btnTwentyDollar.Text = "20 $";
            this.btnTwentyDollar.UseVisualStyleBackColor = true;
            this.btnTwentyDollar.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // btnOneDollar
            // 
            this.btnOneDollar.Location = new System.Drawing.Point(26, 393);
            this.btnOneDollar.Name = "btnOneDollar";
            this.btnOneDollar.Size = new System.Drawing.Size(37, 23);
            this.btnOneDollar.TabIndex = 5;
            this.btnOneDollar.Text = "1 $";
            this.btnOneDollar.UseVisualStyleBackColor = true;
            this.btnOneDollar.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // btn50c
            // 
            this.btn50c.Location = new System.Drawing.Point(153, 353);
            this.btn50c.Name = "btn50c";
            this.btn50c.Size = new System.Drawing.Size(37, 23);
            this.btn50c.TabIndex = 4;
            this.btn50c.Text = "50 c";
            this.btn50c.UseVisualStyleBackColor = true;
            this.btn50c.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // btn20c
            // 
            this.btn20c.Location = new System.Drawing.Point(83, 353);
            this.btn20c.Name = "btn20c";
            this.btn20c.Size = new System.Drawing.Size(37, 23);
            this.btn20c.TabIndex = 3;
            this.btn20c.Text = "20 c";
            this.btn20c.UseVisualStyleBackColor = true;
            this.btn20c.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // btn10c
            // 
            this.btn10c.Location = new System.Drawing.Point(26, 353);
            this.btn10c.Name = "btn10c";
            this.btn10c.Size = new System.Drawing.Size(37, 23);
            this.btn10c.TabIndex = 2;
            this.btn10c.Text = "10 c";
            this.btn10c.UseVisualStyleBackColor = true;
            this.btn10c.Click += new System.EventHandler(this.btnMoneySlot_Click);
            // 
            // rdButtonCard
            // 
            this.rdButtonCard.AutoSize = true;
            this.rdButtonCard.Location = new System.Drawing.Point(16, 431);
            this.rdButtonCard.Name = "rdButtonCard";
            this.rdButtonCard.Size = new System.Drawing.Size(93, 17);
            this.rdButtonCard.TabIndex = 1;
            this.rdButtonCard.Text = "Pay With Card";
            this.rdButtonCard.UseVisualStyleBackColor = true;
            this.rdButtonCard.CheckedChanged += new System.EventHandler(this.ChangePaymentMethod_CheckedChanged);
            // 
            // rdButtonPayCash
            // 
            this.rdButtonPayCash.AutoSize = true;
            this.rdButtonPayCash.Location = new System.Drawing.Point(16, 330);
            this.rdButtonPayCash.Name = "rdButtonPayCash";
            this.rdButtonPayCash.Size = new System.Drawing.Size(70, 17);
            this.rdButtonPayCash.TabIndex = 0;
            this.rdButtonPayCash.Text = "Pay Cash";
            this.rdButtonPayCash.UseVisualStyleBackColor = true;
            this.rdButtonPayCash.CheckedChanged += new System.EventHandler(this.ChangePaymentMethod_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 602);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 286);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelItems);
            this.panel3.Controls.Add(this.btnSortByPrice);
            this.panel3.Controls.Add(this.btnSortByName);
            this.panel3.Controls.Add(this.txtSearchInput);
            this.panel3.Location = new System.Drawing.Point(223, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 591);
            this.panel3.TabIndex = 1;
            // 
            // panelItems
            // 
            this.panelItems.Location = new System.Drawing.Point(15, 57);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(667, 626);
            this.panelItems.TabIndex = 3;
            // 
            // btnSortByPrice
            // 
            this.btnSortByPrice.Location = new System.Drawing.Point(543, 28);
            this.btnSortByPrice.Name = "btnSortByPrice";
            this.btnSortByPrice.Size = new System.Drawing.Size(97, 23);
            this.btnSortByPrice.TabIndex = 2;
            this.btnSortByPrice.Text = "Sort by price";
            this.btnSortByPrice.UseVisualStyleBackColor = true;
            this.btnSortByPrice.Click += new System.EventHandler(this.btnSortSnackItem_Click);
            // 
            // btnSortByName
            // 
            this.btnSortByName.Location = new System.Drawing.Point(437, 28);
            this.btnSortByName.Name = "btnSortByName";
            this.btnSortByName.Size = new System.Drawing.Size(97, 23);
            this.btnSortByName.TabIndex = 1;
            this.btnSortByName.Text = "Sort A-Z";
            this.btnSortByName.UseVisualStyleBackColor = true;
            this.btnSortByName.Click += new System.EventHandler(this.btnSortSnackItem_Click);
            // 
            // txtSearchInput
            // 
            this.txtSearchInput.Location = new System.Drawing.Point(15, 32);
            this.txtSearchInput.Name = "txtSearchInput";
            this.txtSearchInput.Size = new System.Drawing.Size(414, 20);
            this.txtSearchInput.TabIndex = 0;
            this.txtSearchInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearchInput_MouseClick);
            this.txtSearchInput.TextChanged += new System.EventHandler(this.txtSearchInput_TextChanged);
            this.txtSearchInput.MouseLeave += new System.EventHandler(this.txtSearchInput_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 597);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFiftyDollar;
        private System.Windows.Forms.Button btnTwentyDollar;
        private System.Windows.Forms.Button btnOneDollar;
        private System.Windows.Forms.Button btn50c;
        private System.Windows.Forms.Button btn20c;
        private System.Windows.Forms.Button btn10c;
        private System.Windows.Forms.RadioButton rdButtonCard;
        private System.Windows.Forms.RadioButton rdButtonPayCash;
        private System.Windows.Forms.Button btnEndCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSortByPrice;
        private System.Windows.Forms.Button btnSortByName;
        private System.Windows.Forms.TextBox txtSearchInput;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.TextBox txtItemSelected;
        private System.Windows.Forms.TextBox txtMoneyRemaining;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTotalCashInserted;
        private System.Windows.Forms.Label lblToBeBalance;
        private System.Windows.Forms.Label lbllCurrentBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}