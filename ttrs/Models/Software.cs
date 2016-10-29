using System;
using System.Collections.Generic;

namespace Tracker.API.Models
{
    public partial class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductivityLevel { get; set; }
    }
}
