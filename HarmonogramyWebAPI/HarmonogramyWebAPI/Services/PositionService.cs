using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class PositionService(IContext dbContext, IMapper mapper)
    : GenericCrudService<Position, PositionDto>(dbContext, mapper);