using System;

namespace VendingMacine.Module
{
    public class Drink:Items
    {
        private readonly int _sizeInMill;
        public Drink(int sizeInMill)
        { _sizeInMill = sizeInMill; }

        public override void CalculateProfit(double PurchasingPrice, double SellingPrice)
        {
            switch (_sizeInMill)
            {
                case 150:
                    Profit = ((PurchasingPrice - SellingPrice) * 1);
                    break;
                case 250:
                    Profit = ((PurchasingPrice - SellingPrice) * 2);
                    break;
                case 300:
                    Profit=((PurchasingPrice - SellingPrice) * 3);
                    break;
                default:
                   
                    Console.WriteLine("Unrecognized drink size");
                    break;
            }
        }
    }
}
