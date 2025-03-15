using AutoMapper;
using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Request;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Mappers
{
    public class UserMapping : Profile
    {

        public UserMapping() 
        {
            CreateMap<User, UserResponseModel>()
                .ForMember(dest => dest.UserId, src => src.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateUserRequest, User>();

            CreateMap<Item, ItemResponseModel>();
        }
    }
}
