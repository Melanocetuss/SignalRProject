﻿namespace SignalR.EntityLayer.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}