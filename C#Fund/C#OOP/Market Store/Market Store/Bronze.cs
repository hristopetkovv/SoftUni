namespace Market_Store
{
    public class Bronze : Card
    {
        public Bronze(decimal turnover, decimal purchaseValue) 
            : base(turnover, purchaseValue)
        {
        }

        public override decimal Discount()
        {
            if (base.Turnover >= 100 && base.Turnover <= 300)
            {
                base.DiscountRate = 1;
            }
            else if (this.Turnover > 300)
            {
                base.DiscountRate = 2.5m;
            }

            decimal discountPrice = base.DiscountRate * base.PurchaseValue / 100;

            return discountPrice;
        }
    }
}
