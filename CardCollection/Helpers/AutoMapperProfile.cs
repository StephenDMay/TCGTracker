using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardCollection.Entities;
using CardCollection.Models;


namespace CardCollection.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, User>();
            CreateMap<RegisterModel, Entities.User>();
            CreateMap<UpdateModel, Entities.User>();
        }

       
    }
}
