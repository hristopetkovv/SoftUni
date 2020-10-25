namespace Market_Store
{
    using System.Text;

    public abstract class Card
    {
        protected Card(decimal turnover, decimal purchaseValue)
        {
            this.Turnover = turnover;
            this.PurchaseValue = purchaseValue;
        }

        protected decimal DiscountRate = 0;

        protected decimal Turnover { get; set; }

        protected decimal PurchaseValue { get; set; }

        public abstract decimal Discount();

        public decimal TotalPrice()
        {
            decimal totalPrice = this.PurchaseValue - this.Discount();

            return totalPrice;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Purchase value: ${this.PurchaseValue:f2}");
            sb.AppendLine($"Discount rate: {this.DiscountRate:f1}%");
            sb.AppendLine($"Discount: ${this.Discount():f2}");
            sb.AppendLine($"Total: ${this.TotalPrice():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
