using System;
using AutoMapper;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Extensions;
using tesisCdagAsobiguaApi.Resources;

namespace tesisCdagAsobiguaApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>()
                .ForMember(src => src.UserType,
                            opt => opt.MapFrom(src => src.UserType.ToDescriptionString()));

            CreateMap<Shot, ShotResource>();

            CreateMap<XyzShot, XyzShotResource>()
                .ForMember(src => src.XyzShotPosition,
                            opt => opt.MapFrom(src => src.XyzShotPosition.ToDescriptionString()));

            CreateMap<Login, LoginResource>();
            CreateMap<Shot, ShotsByPlayerResource>();
        }
    }
}
