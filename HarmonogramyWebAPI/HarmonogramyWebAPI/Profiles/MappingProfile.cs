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
    }
}