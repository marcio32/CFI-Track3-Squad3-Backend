using AutoMapper;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;


    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
            .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.DeletedTimeUtc, opt => opt.MapFrom(src => (DateTime?)null));

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleDTO, opt => opt.MapFrom(src => src.Role));

            CreateMap<UserRegisterDTO, User>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.DeletedTimeUtc, opt => opt.MapFrom(src => (DateTime?)null))
                .AfterMap((src, dest) => dest.Password = PasswordEncryptHelper.EncryptPassword(src.Password, src.Email))
                .AfterMap((src, dest) => dest.RoleId = src.RoleId);

            CreateMap<User, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }

