namespace SignalR.DtoLayer.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}