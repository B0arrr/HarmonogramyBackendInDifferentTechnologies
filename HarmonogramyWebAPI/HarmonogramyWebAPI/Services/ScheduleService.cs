using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class ScheduleService(IContext dbContext, IMapper mapper)
    : GenericCrudService<Schedule, ScheduleDto>(dbContext, mapper);