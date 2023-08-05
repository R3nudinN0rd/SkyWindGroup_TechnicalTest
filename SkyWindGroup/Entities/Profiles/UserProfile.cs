using AutoMapper;
using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using SkyWindGroup_TechnicalTest.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User,UserDTO_POST>().ReverseMap();
            CreateMap<User, UserDTO_PUT>().ReverseMap();
        }
    }
}
