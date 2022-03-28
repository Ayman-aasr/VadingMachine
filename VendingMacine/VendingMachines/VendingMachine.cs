using VendingMacine.Module;
using VendingMacine.MoneySlot;

namespace VendingMacine.VendingMachines
{
   

    public abstract class VendingMachine 
    {
        private IMoneySlot _moneySlot;
        private  IMoneySlot _currentBalance;
        private readonly IMoneySlot _tempSlot;
        public double _change;

        public VendingMachine(IMoneySlot moneySlot, IMoneySlot currentBalance, IMoneySlot tempMonySolt)
        {
            _tempSlot = tempMonySolt;
            _moneySlot = moneySlot;
          
            _moneySlot.CalculateBalanceInUSD();
            _currentBalance = currentBalance;
            _currentBalance.CalculateBalanceInUSD();
            _change = 0;
            Logger.GetLogger(typeof(VendingMachine));
        }
      
        public bool ValidateChange()
        {
            Logger.Info("Check if SNACKERS can serve you with this order ");
            if (_currentBalance.BalanceInUSD >= this._change )
            {

                Logger.Info("Copy current balance to temp.");
                double remainingChange = _change;
                _tempSlot.Currency = "USD";
                _tempSlot.GetNoteSlot().GetNoteBalance().NumberOf50Dollars=(_currentBalance.GetNoteSlot().GetNoteBalance().NumberOf50Dollars);
                _tempSlot.GetNoteSlot().GetNoteBalance().NumberOf20Dollars=(_currentBalance.GetNoteSlot().GetNoteBalance().NumberOf20Dollars);

                _tempSlot.GetCoinSlot().GetCoinBalance().NumberOf1Dollar=(_currentBalance.GetCoinSlot().GetCoinBalance().NumberOf1Dollar);
                _tempSlot.GetCoinSlot().GetCoinBalance().NumberOf50c=(_currentBalance.GetCoinSlot().GetCoinBalance().NumberOf50c);
                _tempSlot.GetCoinSlot().GetCoinBalance().NumberOf20c=(_currentBalance.GetCoinSlot().GetCoinBalance().NumberOf20c);
                _tempSlot.GetCoinSlot().GetCoinBalance().NumberOf10c=(_currentBalance.GetCoinSlot().GetCoinBalance().NumberOf10c);


                NoteBalance currentNoteBalance = _tempSlot.GetNoteSlot().GetNoteBalance();
                CoinsBalance currentCoinBalance = _tempSlot.GetCoinSlot().GetCoinBalance();
                int numberOfUnitsToBeRemoved = 0;
                double valueOfUnitsToBeRemoved = 0.0;

                //-------------------------------------------------
                numberOfUnitsToBeRemoved = (int)(remainingChange / 50.0);
                Logger.Info("check the snacks can be to return 50$ ");
                if (currentNoteBalance.NumberOf50Dollars >= numberOfUnitsToBeRemoved)
                {

                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 50.0;
                    currentNoteBalance.NumberOf50Dollars=(currentNoteBalance.NumberOf50Dollars - numberOfUnitsToBeRemoved);
                    remainingChange -= valueOfUnitsToBeRemoved;

                   
                }
                else if (numberOfUnitsToBeRemoved > currentNoteBalance.NumberOf50Dollars)
                {
                    valueOfUnitsToBeRemoved = currentNoteBalance.NumberOf50Dollars * 50.0;
                    currentNoteBalance.NumberOf50Dollars=0;
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                //-------------------------------------------------
                Logger.Info("check the snacks can be to return 20$ ");
                numberOfUnitsToBeRemoved = (int)(remainingChange / 20.0);
                if (currentNoteBalance.NumberOf20Dollars >= numberOfUnitsToBeRemoved)
                {
                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 20.0;
                    currentNoteBalance.NumberOf20Dollars=(currentNoteBalance.NumberOf20Dollars - numberOfUnitsToBeRemoved);
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                else if (numberOfUnitsToBeRemoved > currentNoteBalance.NumberOf20Dollars)
                {
                    valueOfUnitsToBeRemoved = currentNoteBalance.NumberOf20Dollars * 20.0;
                    currentNoteBalance.NumberOf20Dollars=0;
                    remainingChange -= valueOfUnitsToBeRemoved;

                }

                //-----------------------------------------------
                Logger.Info("check the snacks can be to return 1$ coin ");
                numberOfUnitsToBeRemoved = (int)(remainingChange / 1.0);
                if (currentCoinBalance.NumberOf1Dollar >= numberOfUnitsToBeRemoved)
                {
                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 1.0;
                    currentCoinBalance.NumberOf1Dollar=(currentCoinBalance.NumberOf1Dollar - numberOfUnitsToBeRemoved);
                    remainingChange -= valueOfUnitsToBeRemoved;

                }
                else if (numberOfUnitsToBeRemoved > currentCoinBalance.NumberOf1Dollar)
                {
                    valueOfUnitsToBeRemoved = currentCoinBalance.NumberOf1Dollar * 1.0;
                    currentCoinBalance.NumberOf1Dollar=0;
                    remainingChange -= valueOfUnitsToBeRemoved;
                }


                //-----------------------------------------------
                Logger.Info("check the snacks can be to return 50c coin ");
                numberOfUnitsToBeRemoved = (int)(remainingChange / 0.5);
                if (currentCoinBalance.NumberOf50c >= numberOfUnitsToBeRemoved)
                {
                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 0.5;
                    currentCoinBalance.NumberOf50c=currentCoinBalance.NumberOf50c - numberOfUnitsToBeRemoved;
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                else if (numberOfUnitsToBeRemoved > currentCoinBalance.NumberOf50c)
                {
                    valueOfUnitsToBeRemoved = currentCoinBalance.NumberOf50c * 0.5;
                    currentCoinBalance.NumberOf50c=0;
                    remainingChange -= valueOfUnitsToBeRemoved;

                }

                //-----------------------------------------------
                Logger.Info("check the snacks can be to return 20c coin ");
                numberOfUnitsToBeRemoved = (int)(remainingChange / 0.2);
                if (currentCoinBalance.NumberOf20c >= numberOfUnitsToBeRemoved)
                {
                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 0.2;
                    currentCoinBalance.NumberOf20c=(currentCoinBalance.NumberOf20c - numberOfUnitsToBeRemoved);
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                else if (numberOfUnitsToBeRemoved > currentCoinBalance.NumberOf20c)
                {
                    valueOfUnitsToBeRemoved = currentCoinBalance.NumberOf20c * 0.2;
                    currentCoinBalance.NumberOf20c=(0);
                    remainingChange -= valueOfUnitsToBeRemoved;
                }

                //-----------------------------------------------
                Logger.Info("check the snacks can be to return 10c coin ");

                numberOfUnitsToBeRemoved = (int)(remainingChange / 0.1);
                if (currentCoinBalance.NumberOf10c >= numberOfUnitsToBeRemoved)
                {
                    valueOfUnitsToBeRemoved = numberOfUnitsToBeRemoved * 0.1;
                    currentCoinBalance.NumberOf10c=(currentCoinBalance.NumberOf10c - numberOfUnitsToBeRemoved);
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                else if (numberOfUnitsToBeRemoved > currentCoinBalance.NumberOf10c)
                {
                    valueOfUnitsToBeRemoved = currentCoinBalance.NumberOf10c * 0.1;
                    currentCoinBalance.NumberOf10c=0;
                    remainingChange -= valueOfUnitsToBeRemoved;
                }
                if (remainingChange == 0.0)
                {
                    _currentBalance = _tempSlot;
                    _currentBalance.CalculateBalanceInUSD();
                    _change = 0.0;
                    _tempSlot.CalculateBalanceInUSD();
                    Logger.Info("the snack machine accept order");
                    return true;
                }
            }
            return _change == 0;
        }
  

        public void ReturnMoney()
        {
            Logger.Info("Start to return Amount");
            _change = 0.0;
            NoteBalance currentNoteBalance = _currentBalance.GetNoteSlot().GetNoteBalance();
            CoinsBalance currentCoinBalance = _currentBalance.GetCoinSlot().GetCoinBalance();

            NoteBalance toBeCanceledNotes = _moneySlot.GetNoteSlot().GetNoteBalance();
            CoinsBalance toBeCanceledCoins = _moneySlot.GetCoinSlot().GetCoinBalance();

            if (currentNoteBalance.NumberOf20Dollars >= toBeCanceledNotes.NumberOf20Dollars)
                currentNoteBalance.NumberOf20Dollars=currentNoteBalance.NumberOf20Dollars - toBeCanceledNotes.NumberOf20Dollars;

            Logger.Info($"the Number of 20$ note should be return {currentNoteBalance.NumberOf20Dollars}");

            if (currentNoteBalance.NumberOf50Dollars >= toBeCanceledNotes.NumberOf50Dollars)
                currentNoteBalance.NumberOf50Dollars=(currentNoteBalance.NumberOf50Dollars - toBeCanceledNotes.NumberOf50Dollars);
            Logger.Info($"the Number of 50$ note should be return {currentNoteBalance.NumberOf50Dollars}");

            if (currentCoinBalance.NumberOf1Dollar > toBeCanceledCoins.NumberOf1Dollar)
                currentCoinBalance.NumberOf1Dollar=(currentCoinBalance.NumberOf1Dollar - toBeCanceledCoins.NumberOf1Dollar);
            Logger.Info($"the Number of 1$ coin should be return {currentCoinBalance.NumberOf1Dollar}");
            if (currentCoinBalance.NumberOf50c > toBeCanceledCoins.NumberOf50c)
                currentCoinBalance.NumberOf50c=(currentCoinBalance.NumberOf50c - toBeCanceledCoins.NumberOf50c);
            Logger.Info($"the Number of 50c coin should be return {currentCoinBalance.NumberOf50c}");

            if (currentCoinBalance.NumberOf20c > toBeCanceledCoins.NumberOf20c)
                currentCoinBalance.NumberOf20c=(currentCoinBalance.NumberOf20c - toBeCanceledCoins.NumberOf20c);
            Logger.Info($"the Number of 20c coin should be return {currentCoinBalance.NumberOf20c}");
            if (currentCoinBalance.NumberOf10c > toBeCanceledCoins.NumberOf10c)
                currentCoinBalance.NumberOf10c=(currentCoinBalance.NumberOf10c - toBeCanceledCoins.NumberOf10c);
            Logger.Info($"the Number of 10c coin should be return {currentCoinBalance.NumberOf10c}");

            this.ClearMoneySlot();

           _currentBalance.CalculateBalanceInUSD();
            _moneySlot.CalculateBalanceInUSD();
        }



        public void ClearMoneySlot()
        {
            NoteBalance toBeCanceledNotes = _moneySlot.GetNoteSlot().GetNoteBalance();
            CoinsBalance toBeCanceledCoins = _moneySlot.GetCoinSlot().GetCoinBalance();

            toBeCanceledNotes.NumberOf20Dollars=0;
            toBeCanceledNotes.NumberOf50Dollars=0;
            toBeCanceledCoins.NumberOf10c = 0;

            toBeCanceledCoins.NumberOf20c = 0;
            toBeCanceledCoins.NumberOf50c = 0;
            toBeCanceledCoins.NumberOf1Dollar = 0;
            Logger.Info("Clear Mony Slot");
        }

        public void CleanCardSlot()
        {
            CardBalance toBeCanceledCard = _moneySlot.GetCardSlot().GetCardBalance();
            toBeCanceledCard.SetCollectedFromCard(0.0);
            Logger.Info("Clear Card Slot");
        }
      


        public abstract bool Purchase(ref Items item);

        public abstract bool PurchaseWithCard(ref Items item);

        public abstract void RefillBalance();
        public abstract bool IsValidCurancy(string Currency);

        public  abstract bool AcceptMoney(Items item);
        public abstract void CalculateChange(double sellingPrice);
    }
}
