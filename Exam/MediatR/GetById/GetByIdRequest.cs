using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.GetById
{
    public class GetByIdRequest : IRequest<ApplicationDTO>
    {
        public Guid Id { get; set; }

        public GetByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
