using System;
using System.Collections.Generic;

namespace Tracker.API.Models
{
    public partial class User
    {
        public Guid UserUid { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
    }
}
