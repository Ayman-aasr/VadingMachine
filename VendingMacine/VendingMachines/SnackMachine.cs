using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VendingMacine.Module;
using VendingMacine.Money;
using VendingMacine.MoneySlot;

namespace VendingMacine.VendingMachines
{
    public interface ISnackMachine
    {
        void CalculateChange(double sellingPrice);
        List<Snack> GetSnackStock();
        IMoneySlot GetMoneySolt();
        IMoneySlot GetCurrentBalance();
        bool IsValidCurancy(string Currency);
        bool Purchase(ref Items item);
        bool PurchaseWithCard(ref Items item);
        bool AcceptMoney(Items item);
        void ReturnMoney();
        void RefillBalance();
        double GetChange();
        void SetChange(double change);
    }

    public class SnackMachine : VendingMachine, ISnackMachine
    {
        private readonly IMoneySlot _moneySlot;
        private readonly IMoneySlot _currentBalance;
        private readonly INote _note;
        private readonly ICoin _coin;
        public SnackMachine(IMoneySlot moneySlot, IMoneySlot currentBalance, IMoneySlot tempMonySolt, INote note , ICoin coin) : base(moneySlot, currentBalance, tempMonySolt)
        {
            _moneySlot = moneySlot;
            _currentBalance = currentBalance;
            _note = note;
            _coin = coin;
            RefillBalance();
            Logger.GetLogger(typeof(SnackMachine));
        }

        public IMoneySlot GetMoneySolt()
        { return _moneySlot; }
        public List<Snack> GetSnackStock()
        {
            var result = new List<Snack>();
            using (var rd = new StreamReader("snacks.csv"))
            {
                int id = 1;
                while (!rd.EndOfStream)
                {
                    var snackItemsRows = rd.ReadLine().Split(';');
                    var snackItemsList = snackItemsRows.FirstOrDefault().Split(',');
                    int snackWeight = 0;
                    int.TryParse(snackItemsList[5].Trim(), out snackWeight);

                    result.Add(new Snack(snackWeight)
                    {
                        Name = snackItemsList[0].Trim(),
                        Description = snackItemsList[1].Trim(),
                        PurchasingPrice = double.Parse(snackItemsList[2].Trim()),
                        SellingPrice = double.Parse(snackItemsList[3].Trim()),
                        AvailableItems = int.Parse(snackItemsList[4].Trim()),
                        Id = id
                    });
                    id++;


                }
                rd.Close();
            }
            Logger.Info($"Fill {result.Count}snacks to machine");
            return result;

        }

        public override bool IsValidCurancy(string Currency)
        {
            return Currency == "USD";
        }



        public override void CalculateChange(double sellingPrice)
        {
            if (_moneySlot.BalanceInUSD > sellingPrice)
            _change = Math.Round((_moneySlot.BalanceInUSD - sellingPrice), 4);
        }

        public override bool Purchase(ref Items item)
        {
            if (ValidateChange())
            {
              
                item.CalculateProfit(item.SellingPrice, item.PurchasingPrice);
                item.AvailableItems -= 1;
                Logger.Info($"{item.Name} was sold and the profit is {item.Profit} and machine has {item.AvailableItems} available snack of {item.Name} ");
                this.ClearMoneySlot();
                return true;
            }
            return false;
        }

        public override bool PurchaseWithCard(ref Items item)
        {
            try
            {
                _moneySlot.GetCardSlot().GetCardBalance().SetCollectedFromCard(item.SellingPrice);
                item.CalculateProfit(item.SellingPrice, item.PurchasingPrice);
                item.AvailableItems -= 1;
                _change = 0.0;
                _currentBalance.GetCardSlot().GetCardBalance().SetCollectedFromCard(_currentBalance.GetCardSlot().GetCardBalance().GetCollectedFromCard() + _moneySlot.GetCardSlot().GetCardBalance().GetCollectedFromCard());
                _moneySlot.CalculateBalanceInUSD();
                _currentBalance.CalculateBalanceInUSD();
                Logger.Info(_moneySlot.GetCardSlot().GetCardBalance().GetCollectedFromCard());
                Logger.Info(_currentBalance.BalanceInUSD);
                Logger.Info($"{item.Name} was sold and the profit is {item.Profit} and machine has {item.AvailableItems} available snack of {item.Name} ");
                CleanCardSlot();
                return true;
            }
            catch(Exception e)
            {
                Logger.Error($"An Error Occurred while Purchas eWith Card of snack {item.Name} error{e?.Message?? e?.InnerException?.Message} ");
                return false;
            }
        }

        public override void RefillBalance()
        {
            Logger.Info("Start to ReFill money to machime");
           
            using (var rd = new StreamReader("money.csv"))
            {
                int id = 1;
                while (!rd.EndOfStream)
                {
                    var data = rd.ReadLine().Split(',');
                    if (data[1].Trim() == "c" || (data[1].Trim() == "$" && data[2].Trim() == "1"))
                    {
                        _coin.CoinValue = int.Parse(data[2]);
                        _coin.Currency = "USD";
                        _coin.Category = data[1].Trim().ToCharArray().SingleOrDefault();// as char;
                        if (IsValidCurancy(_coin.Currency))
                        {
                            _currentBalance.UpdateBalance(_coin);
                        }

                        else
                        {
                            Logger.Warn($"the snack machine not accepts {_coin.Currency} , it accepts USD Only");
                            Console.WriteLine("USD only");
                         
                        }
                    }
                    else if (data[1].Trim() == "$")
                    {
                        _note.Category = data[1].Trim().ToCharArray().SingleOrDefault();// as char;
                        _note.Currency = "USD";
                        _note.NoteValue = int.Parse(data[2]);
                        _currentBalance.UpdateBalance(_note);
                        if (IsValidCurancy(_coin.Currency))
                        {
                            _currentBalance.UpdateBalance(_note);
                        }

                        else
                        {
                            Logger.Warn($"the snack machine not accepts {_coin.Currency} , it accepts USD Only");
                            Console.WriteLine("USD only");
                        }
                    }
                  


                }
                rd.Close();
            }
 
        }

        public override bool AcceptMoney(Items item)
        {
            return _moneySlot.BalanceInUSD >= (item?.SellingPrice??0);
        }

        public IMoneySlot GetCurrentBalance()
        {
            return _currentBalance;
        }

        public double GetChange()
        {
            return _change;
        }
        public void SetChange(double change)
        {
            _change = change;
        }
    }
}
