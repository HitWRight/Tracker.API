using System;
using System.Collections.Generic;

namespace Tracker.API.Models
{
    public partial class UsageBuffer
    {
        public int ComputerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UsedProgram { get; set; }
    }
}
