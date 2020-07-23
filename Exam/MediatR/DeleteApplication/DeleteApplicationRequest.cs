using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.DeleteApplication
{
    public class DeleteApplicationRequest : IRequest<string>
    {
        public Guid Id { get; set; }
        public DeleteApplicationRequest(Guid id)
        {
            Id = id;
        }
    }
}
