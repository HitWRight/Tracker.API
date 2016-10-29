using System;
using System.Collections.Generic;

namespace Tracker.API.Models
{
    public partial class Computer
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public byte[] Macaddress { get; set; }
        public string Name { get; set; }
    }
}
