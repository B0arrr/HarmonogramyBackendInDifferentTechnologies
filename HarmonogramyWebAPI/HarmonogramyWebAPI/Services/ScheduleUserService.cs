using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class ScheduleUserService(IContext dbContext, IMapper mapper)
    : GenericCrudService<ScheduleUser, ScheduleUserDto>(dbContext, mapper);