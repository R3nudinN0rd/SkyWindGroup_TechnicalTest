using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.TicketModels;
using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using SkyWindGroup_TechnicalTest.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO_POST>().ReverseMap();
            CreateMap<Ticket, TicketDTO_PUT>().ReverseMap();
        }
    }
}
