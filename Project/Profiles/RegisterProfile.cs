using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Models.Auth;

namespace Project.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterModel, RegisterModelDb>();
            CreateMap<RegisterModelDb, RegisterModel>();
        }
    }
}
