using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyDto, Company>();
        CreateMap<Employment, EmploymentDto>();
        CreateMap<EmploymentDto, Employment>();
        CreateMap<Position, PositionDto>();
        CreateMap<PositionDto, Position>();
        CreateMap<ScheduleUser, ScheduleUserDto>();
        CreateMap<ScheduleUserDto, ScheduleUser>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}