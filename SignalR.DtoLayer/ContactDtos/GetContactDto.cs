﻿namespace SignalR.DtoLayer.ContactDtos
{
    public class GetContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}