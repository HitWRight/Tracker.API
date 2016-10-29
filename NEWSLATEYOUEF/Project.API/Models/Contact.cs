using System;
using System.Collections.Generic;

namespace Project.API.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
