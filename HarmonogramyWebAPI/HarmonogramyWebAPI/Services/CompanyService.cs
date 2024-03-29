﻿using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class CompanyService(IContext dbContext, IMapper mapper)
    : GenericCrudService<Company, CompanyDto>(dbContext, mapper);