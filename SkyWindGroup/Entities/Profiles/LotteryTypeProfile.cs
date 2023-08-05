using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class LotteryTypeProfile : Profile
    {
        public LotteryTypeProfile()
        {
            CreateMap<LotteryType, LotteryTypeDTO>().ReverseMap();
            CreateMap<LotteryType, LotteryTypeDTO_POST>().ReverseMap();
            CreateMap<LotteryType, LotteryTypeDTO_PUT>().ReverseMap();
        }
    }
}
