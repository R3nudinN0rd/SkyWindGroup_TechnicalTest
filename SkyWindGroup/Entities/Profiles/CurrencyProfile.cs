using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.CurrencyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
            CreateMap<Currency, CurrencyDTO_POST>().ReverseMap();
            CreateMap<Currency, CurrencyDTO_PUT>().ReverseMap();
        }
    }
}
