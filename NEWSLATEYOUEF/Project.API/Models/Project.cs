﻿using System;
using System.Collections.Generic;

namespace Project.API.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ClientId { get; set; }
    }
}
