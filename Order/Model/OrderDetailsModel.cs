namespace Order.Model
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
