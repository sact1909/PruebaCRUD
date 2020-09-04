using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.DTO;
using AutoMapper;

namespace CRUDExam.Repo.AutoMapper
{
    public class AutoMapProfile : Profile
    {

        public AutoMapProfile()
        {
            CreateMap<Permission, PermissionDTO>()
                .ForMember(des=> des.perDescription, mf=>mf.MapFrom(src=>src.PermissionType.Description));
            CreateMap<PermissionDTO, Permission>()
                .ForMember(des => des.PermissionType, mf => mf.Ignore());
            CreateMap<PermissionType, PermissionTypeDTO>().ReverseMap();
            CreateMap<PermissionTypeDTO, PermissionType>().ReverseMap();

        }

    }
}
