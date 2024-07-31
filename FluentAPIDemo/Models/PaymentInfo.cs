namespace FluentAPIDemo.Models
{
    public class PaymentInfo
    {
        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public string? BillingEmail { get; set; }
        public decimal Amount { get; set; }
    }
}
