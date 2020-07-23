using Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Application
    {
        public int Id { get; set; } 
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile Profile1 { get; set; }
        public Profile Profile2 { get; set; }
        public College College { get; set; }
    }
}
