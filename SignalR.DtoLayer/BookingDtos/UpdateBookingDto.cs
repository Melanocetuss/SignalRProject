namespace SignalR.DtoLayer.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}