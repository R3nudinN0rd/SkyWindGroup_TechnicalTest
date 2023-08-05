using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using SkyWindGroup_TechnicalTest.LotteryNumberGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class DrawHistoryProfile : Profile
    {
        public DrawHistoryProfile()
        {
            CreateMap<DrawHistory, DrawHistoryDTO>().ReverseMap();
            CreateMap<DrawHistory, DrawHistoryDTO_POST>().ReverseMap();
            CreateMap<DrawHistory, DrawHistoryDTO_PUT>().ReverseMap();
            CreateMap<DrawHistory, DrawHistoryDTO_NumberGenerated>().ReverseMap();
        }
    }
}
