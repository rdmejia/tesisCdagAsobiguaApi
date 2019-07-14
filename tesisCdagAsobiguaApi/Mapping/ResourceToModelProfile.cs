using System;
using AutoMapper;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Resources;
using tesisCdagAsobiguaApi.Extensions;

namespace tesisCdagAsobiguaApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();

            CreateMap<SaveShotResource, Shot>();
            CreateMap<SaveXyzShotResource, XyzShot>();
            CreateMap<SaveUserShotResource, User>();
        }
    }
}
