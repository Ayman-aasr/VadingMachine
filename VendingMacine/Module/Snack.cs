using System;

namespace VendingMacine.Module
{
    public class Snack : Items
    {
        private readonly int _weightInGM;
        public Snack(int weightInGM):base()
        { _weightInGM = weightInGM; }
        public override void CalculateProfit(double PurchasingPrice, double SellingPrice)
        {
            switch (_weightInGM)
            {
                case 20:
                    Profit= ((PurchasingPrice - SellingPrice) * 1);
                    break;
                case 30:
                    Profit=((PurchasingPrice - SellingPrice) * 2);
                    break;
                case 50:
                    Profit=((PurchasingPrice - SellingPrice) * 3);
                    break;
                default:
                    Console.WriteLine("Unrecognized snack weight");
                    break;
                    
            }
        }
    }
}
