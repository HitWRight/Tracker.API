using System;
using System.Collections.Generic;

namespace Tracker.API.Models
{
    public partial class Usage
    {
        public int Id { get; set; }
        public int SoftwareId { get; set; }
        public DateTime Date { get; set; }
        public int ComputerId { get; set; }
        public int SecondsSpent { get; set; }
    }
}
