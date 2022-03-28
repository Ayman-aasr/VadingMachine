using System;

namespace VendingMacine.Module
{
    public class Coffee : Items
    {
        private readonly string _coffeeType;
        private readonly char _cupSize;
        public Coffee(string coffeeType, char cupSize)
        {
            _coffeeType = coffeeType;
            _cupSize = cupSize;
        }
        public override void CalculateProfit(double PurchasingPrice, double SellingPrice)
        {
            switch (_cupSize)
            {
                case 's':
                    Profit=((PurchasingPrice - SellingPrice) * 1);
                    break;
                case 'm':
                    Profit = ((PurchasingPrice - SellingPrice) * 2);
                    break;
                case 'l':
                    Profit = ((PurchasingPrice - SellingPrice) * 3);
                    break;
                default:
                    Console.WriteLine("Unrecognized cup size");
                    break;

            }
        }
    }
}
