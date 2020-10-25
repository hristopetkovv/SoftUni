namespace Market_Store
{
    public class Silver : Card
    {
        public Silver(decimal turnover, decimal purchaseValue) 
            : base(turnover, purchaseValue)
        {
        }

        public override decimal Discount()
        {
            if (base.Turnover > 300)
            {
                base.DiscountRate = 3.5m;
            }
            else
            {
                base.DiscountRate = 2;
            }

            decimal discountPrice = base.DiscountRate * base.PurchaseValue / 100;

            return discountPrice;
        }
    }
}
