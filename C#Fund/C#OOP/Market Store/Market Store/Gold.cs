using System;

namespace Market_Store
{
    public class Gold : Card
    {
        public Gold(decimal turnover, decimal purchaseValue) 
            : base(turnover, purchaseValue)
        {
        }

        public override decimal Discount()
        {
            if (base.Turnover > 100)
            {
                base.DiscountRate = Math.Round(base.Turnover / 100);
            }
            else
            {
                base.DiscountRate = 2;
            }

            if (base.DiscountRate > 10)
            {
                base.DiscountRate = 10;
            }

            decimal discountPrice = base.DiscountRate * base.PurchaseValue / 100;

            return discountPrice;
        }
    }
}
