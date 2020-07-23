using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Enums;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.EditApplication
{
    public class EditApplicationRequest : IRequest<ApplicationDTO>
    {
        public Guid Id { get; set; }
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile ProfileFirst { get; set; }
        public Profile ProfileSecond { get; set; }
        public College College { get; set; }
        
        public EditApplicationRequest(Guid id, ApplicationDTO application)
        {
            Id = id;
            IIN = application.IIN;
            Score = application.Score;
            ProfileFirst = application.ProfileFirst;
            ProfileSecond = application.ProfileSecond;
            College = application.College;
        }
    }
}
