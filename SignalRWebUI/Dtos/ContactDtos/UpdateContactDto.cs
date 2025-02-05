namespace SignalRWebUI.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}