using AutoMapper;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;

public class RoleProfile : Profile
    {
        public RoleProfile()
    {
        CreateMap<RoleDTO, Role>();

        CreateMap<Role, RoleDTO>();

        CreateMap<Role, Role>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
    
    }

