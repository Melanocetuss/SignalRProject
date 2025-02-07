namespace SignalRWebUI.Dtos.OrderDetailDtos
{
    public class CreateOrderDetailDto
    {
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}