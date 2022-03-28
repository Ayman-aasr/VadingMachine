using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using VendingMacine.Module;
using VendingMacine.Money;
using VendingMacine.VendingMachines;

namespace VendingMacine
{
    public partial class MainForm : Form
    {
        private string searchInput = "Search ...";
        private readonly ISnackMachine _snackMachine;
        private readonly INote _note;
        private readonly ICoin _coin;
        private Items _selectedSnack;
        private  List<Snack> _snackItems = new List<Snack>();
        private string _orderSnackItemBy= "Id";
        public MainForm(ISnackMachine snackMachine, INote note, ICoin money)
        {
            InitializeComponent();
            txtSearchInput.Text = searchInput;
            _snackMachine = snackMachine;
            _note = note;
            _coin = money;
            FillSnackSoket();
            EnableButtonCoinSolt(false);
            rdButtonPayCash.Checked = false;
        }


        private void FillSnackSoket()
        {
            _snackItems = _snackMachine.GetSnackStock();
            DrawSnackSoketinMachine();
        }
        private void DrawSnackSoketinMachine()
        {
            int currentRow = 0;
            int currentColumn = 0;
            string filter = txtSearchInput.Text.Trim();
            if(filter== searchInput)
            { filter = ""; }
            var sortProperty = typeof(Snack).GetProperty(_orderSnackItemBy);
            foreach (var snack in _snackItems.Where(_=>_.Name.ToLower().Contains(filter.ToLower()) || filter== string.Empty).OrderBy(_=> sortProperty.GetValue(_, null)))
            {
                if(currentColumn ==5)
                {
                    currentRow += 1;
                    currentColumn = 0;
                }
                TextBox txtSnackItem = new TextBox();
                txtSnackItem.Location = new Point((currentColumn * 125), (125 * currentRow));
                txtSnackItem.Size = new Size(120, 120);
                txtSnackItem.Name = $"snackItem{snack.Id.ToString()}";
                txtSnackItem.Text = snack.AvailableItems >= 1 ?$"{snack.Name} {Environment.NewLine}{snack.Description}{Environment.NewLine}{snack.SellingPrice}": $"{ txtSnackItem.Text}{Environment.NewLine}UnAvailable";
                txtSnackItem.Padding = new Padding(6);
                txtSnackItem.ReadOnly = true;
                txtSnackItem.Multiline = true;
                txtSnackItem.Font = new System.Drawing.Font("Microsoft Arial", 11F,
                FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                txtSnackItem.Cursor = Cursors.Default;
                txtSnackItem.BackColor = _selectedSnack?.Id == snack.Id ? Color.Aqua : Color.White;
                txtSnackItem.ForeColor =snack.AvailableItems>=1 ?Color.Black:Color.Red; 
                if (snack.AvailableItems>=1)
                {
                    txtSnackItem.Click += new EventHandler(btnSnackItemSelected_Click); //assign click handler
                   
                }
                panelItems.Controls.Add(txtSnackItem);
                currentColumn++;
            }
        }

        protected void btnSnackItemSelected_Click(object sender, EventArgs e)
        {
            TextBox txtButton = sender as TextBox;
           if(_selectedSnack !=null)
            {
                var txtSnackControls = this.panelItems.Controls.Find($"snackItem{_selectedSnack.Id.ToString()}",true);
                TextBox btnSnackControls = txtSnackControls[0] as TextBox;
                btnSnackControls.BackColor = Color.White;
                btnSnackControls.ForeColor = Color.Black;
            }
            var id = int.Parse(txtButton.Name.Replace("snackItem", ""));
            _selectedSnack = _snackItems?.FirstOrDefault(_=>_.Id==id)??null;
            if (_selectedSnack != null)
            {
                txtItemSelected.Text = _selectedSnack.Name;
                txtPrice.Text = _selectedSnack.SellingPrice.ToString("0.00");
                txtButton.BackColor = Color.Aqua;
            }
            UpdateStatus();
        }
        private void txtSearchInput_TextChanged(object sender, EventArgs e)
        {
            panelItems.Controls.Clear();
            DrawSnackSoketinMachine();
        }

        private void txtSearchInput_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtSearchInput.Text== searchInput)
            {
                txtSearchInput.Text = string.Empty;
            }
        }

        private void txtSearchInput_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchInput.Text == string.Empty)
            {
                txtSearchInput.Text = searchInput;
            }
        }
        
     
          private void btnMoneySlot_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string[] data = btn.Text.Split(' ');

            if (data[1].Trim() == "c" || (data[1].Trim() == "$" && data[0].Trim()=="1"))
            {
                _coin.CoinValue = int.Parse(data[0]);
                _coin.Currency = "USD";
                _coin.Category = data[1].Trim().ToCharArray().SingleOrDefault();// as char;
                if (_snackMachine.IsValidCurancy(_coin.Currency))
                {
                    _snackMachine.GetMoneySolt().UpdateBalance(_coin);
                    _snackMachine.GetCurrentBalance().UpdateBalance(_coin);
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("USD only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Console.WriteLine("USD only");
                    return;
                }
            }
            else if (data[1].Trim() == "$")
            {
                _note.Category = data[1].Trim().ToCharArray().SingleOrDefault();// as char;
                _note.Currency = "USD";
                _note.NoteValue= int.Parse(data[0]);
                _snackMachine.GetMoneySolt().UpdateBalance(_note);
                _snackMachine.GetCurrentBalance().UpdateBalance(_note);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("USD only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Console.WriteLine("USD only");
                return;
            }

            UpdateStatus();
         }

        public void UpdateStatus()
        {
            if ((_selectedSnack?.Id??0) !=0)
            {
                txtPrice.Text = _selectedSnack.SellingPrice.ToString("0.00");
                _snackMachine.CalculateChange(_selectedSnack?.SellingPrice ?? 0);
                _snackMachine.GetMoneySolt().CalculateBalanceInUSD();
                _snackMachine.GetCurrentBalance().CalculateBalanceInUSD();
                lbllCurrentBalance.Text = $"Current balance: {_snackMachine.GetCurrentBalance().BalanceInUSD.ToString("0.00")}";
                lblToBeBalance.Text=$"To Be balance: {(_snackMachine.GetCurrentBalance().BalanceInUSD - _snackMachine.GetChange()).ToString("0.00")}" ;

                 txtTotalCashInserted.Text = _snackMachine.GetMoneySolt().BalanceInUSD.ToString("0.00");
                txtMoneyRemaining.Text = _snackMachine.GetChange().ToString("0.00");
               btnConfirm.Enabled = (_snackMachine.AcceptMoney(_selectedSnack) || !rdButtonCard.Checked && !rdButtonPayCash.Checked);
                

              
            }
            else
            {
                Console.WriteLine("Please Selected item");
            }
        }

        private void ChangePaymentMethod_CheckedChanged(object sender, EventArgs e)
        {
            
            var rdbButton = sender as RadioButton;
            lbllCurrentBalance.Text = $"Current balance: {_snackMachine.GetCurrentBalance().BalanceInUSD}";
            lblToBeBalance.Text = $"To Be balance: {(_snackMachine.GetCurrentBalance().BalanceInUSD +(_selectedSnack?.SellingPrice??0)).ToString("0.00")}";
            btnConfirm.Enabled = (_snackMachine.AcceptMoney(_selectedSnack) || !rdButtonCard.Checked && !rdButtonPayCash.Checked);

            if (rdbButton.Checked)
            {
                if (rdbButton.Name == "rdButtonCard")
                {
                    rdButtonPayCash.Checked = false;
                    EnableButtonCoinSolt(false);
                    btnConfirm.Enabled = true;
                }
                else if (rdbButton.Name == "rdButtonPayCash" && rdbButton.Checked)
                {
                    rdButtonCard.Checked = false;
                    EnableButtonCoinSolt(true);
                }
            }
        }

        private void btnEndCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void CleanAll()
        {
            _snackMachine.SetChange(0);
            lbllCurrentBalance.Text = $"Current balance: {(_snackMachine.GetCurrentBalance().BalanceInUSD).ToString("0.00")}";
            lblToBeBalance.Text = $"To Be balance: {(_snackMachine.GetCurrentBalance().BalanceInUSD - _snackMachine.GetChange()).ToString("0.00")}";

            txtMoneyRemaining.Text = "0.00";
            txtPrice.Text = "0.00";
            var txtSnackControls = this.panelItems.Controls.Find($"snackItem{_selectedSnack.Id.ToString()}", true);
            TextBox btnSnackControls = txtSnackControls[0] as TextBox;
            btnSnackControls.BackColor = Color.White;
            btnSnackControls.ForeColor = Color.Black;
          
            txtTotalCashInserted.Text = "0.00";
            txtItemSelected.Text = string.Empty;
            btnConfirm.Enabled = false;
            _selectedSnack = null;
            rdButtonCard.Checked = false;
            rdButtonPayCash.Checked = false;
            EnableButtonCoinSolt(false);
        }

        private void EnableButtonCoinSolt(bool isEnable)
        {
            btn10c.Enabled = isEnable;
            btn20c.Enabled = isEnable;
            btn50c.Enabled = isEnable;
            btnOneDollar.Enabled = isEnable;
            btnTwentyDollar.Enabled = isEnable;
            btnFiftyDollar.Enabled = isEnable;
        }

        private void btnSortSnackItem_Click(object sender, EventArgs e)
        {
            var btnSort = sender as Button;
            bool isOrder = false;
            if(btnSort.Name.Equals("btnSortByName") && _orderSnackItemBy!="Name")
            {
                isOrder = true;
                _orderSnackItemBy = "Name";
            }
            else if(btnSort.Name.Equals("btnSortByPrice") && _orderSnackItemBy != "SellingPrice")
            {
                isOrder = true;
                _orderSnackItemBy = "SellingPrice";
            }
            if(isOrder)
            {
                panelItems.Controls.Clear();
                DrawSnackSoketinMachine();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           

            if (rdButtonPayCash.Checked)
                if (_snackMachine.Purchase(ref (_selectedSnack)))
                {

                    System.Windows.Forms.MessageBox.Show("Please take your snack and change", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateSnackList();

                    UpdateStatus();
                    CleanAll();


                    DrawSnackSoketinMachine();
                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("SNACKERS cannot serve you with this order. We don't have enough variance of change", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    Cancel();
                }
            else if (rdButtonCard.Checked)
            {

               if (_snackMachine.PurchaseWithCard(ref _selectedSnack))
               {
                  
                    System.Windows.Forms.MessageBox.Show("Please take your snack fees charged successfully of your card", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateSnackList();

                    UpdateStatus();
                    CleanAll();
                   
                    
                    DrawSnackSoketinMachine();
                  
                }
               else
                {
                    System.Windows.Forms.MessageBox.Show("Something went wrong", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cancel();
                }
            }
        }

        private void UpdateSnackList()
        {
            foreach (var item in _snackItems.Where(_ => _.Id == _selectedSnack.Id))
            {
                item.AvailableItems = _selectedSnack.AvailableItems;
            }
        }

        public void Cancel()
        {
            _snackMachine.ReturnMoney();
            CleanAll();
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cancel();
        }
    }
}
