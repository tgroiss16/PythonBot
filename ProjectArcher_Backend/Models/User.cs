using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
