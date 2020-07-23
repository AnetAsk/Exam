using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using University.DTOs;
using MediatR;
using University.Domain.Enums;

namespace University.WebAPI.ApplicationMediatr.FilingAnApplication
{
    public class FilingApplicationCommand : IRequest<ApplicationDTO>
    {
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile ProfileFirst { get; set; }
        public Profile ProfileSecond { get; set; }
        public College College { get; set; }

        public FilingApplicationCommand(ApplicationDTO application)
        {
            IIN = application.IIN;
            Score = application.Score;
            ProfileFirst = application.ProfileFirst;
            ProfileSecond = application.ProfileSecond;
            College = application.College;
        }
    }
}
