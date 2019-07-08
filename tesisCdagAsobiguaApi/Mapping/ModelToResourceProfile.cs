using System;
using AutoMapper;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Resources;

namespace tesisCdagAsobiguaApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>()
                .ForMember(src => src.UserType,
                            opt => opt.MapFrom(src => src.UserType.ToString()));

            CreateMap<Shot, ShotResource>();
            CreateMap<XyzShot, XyzShotResource>();
            CreateMap<Login, LoginResource>();
        }
    }
}
