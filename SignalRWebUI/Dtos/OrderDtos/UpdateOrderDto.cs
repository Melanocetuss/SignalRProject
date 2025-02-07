namespace SignalRWebUI.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}