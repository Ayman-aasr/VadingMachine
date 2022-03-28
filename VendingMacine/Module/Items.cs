using System;

namespace VendingMacine.Module
{
  public abstract class Items
    {
        public string Name { get; set; }
        public String Description { get; set; }
        public double PurchasingPrice { get; set; }
        public double SellingPrice { get; set; }
        public double Profit { get; set; }
        public int AvailableItems { get; set; }
        public int Id { get; set; }
        public abstract void CalculateProfit(double PurchasingPrice, double SellingPrice);
    }

   
}
