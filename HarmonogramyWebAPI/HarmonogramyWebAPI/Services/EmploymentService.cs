using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class EmploymentService(IContext dbContext, IMapper mapper)
    : GenericCrudService<Employment, EmploymentDto>(dbContext, mapper);