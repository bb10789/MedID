using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AzureAPI.Dtos;
using AzureAPI.Model;

namespace AzureAPI.Profiles {
    public class MedidProfile : Profile {
        public MedidProfile() {
            CreateMap<UserId, UserIdCreateDto>();
            CreateMap<UserIdCreateDto, UserId>();
            CreateMap<InteractionCreateDto, Interaction>();
        }
    }
}
