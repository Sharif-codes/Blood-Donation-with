using System;
using System.Collections.Generic;

namespace Bloodbank_proj.Models
{
    public partial class Information
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Location { get; set; }
        public int Contact { get; set; }
    }
}
