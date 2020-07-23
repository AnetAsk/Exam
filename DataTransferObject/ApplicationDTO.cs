using Domain.Model.Enums;
using System;

namespace DataTransferObject
{
    public class ApplicationDTO
    {
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile Profile1 { get; set; }
        public Profile Profile2 { get; set; }
        public College College { get; set; }
    }
}
