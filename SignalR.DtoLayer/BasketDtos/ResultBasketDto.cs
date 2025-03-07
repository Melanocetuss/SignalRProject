﻿namespace SignalR.DtoLayer.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int MenuTableID { get; set; }
    }
}
