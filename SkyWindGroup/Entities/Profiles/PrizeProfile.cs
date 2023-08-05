using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.PrizeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class PrizeProfile : Profile
    {
        public PrizeProfile()
        {
            CreateMap<Prize, PrizeDTO>().ReverseMap();
            CreateMap<Prize, PrizeDTO_POST>().ReverseMap();
            CreateMap<Prize, PrizeDTO_PUT>().ReverseMap();
        }
    }
}
