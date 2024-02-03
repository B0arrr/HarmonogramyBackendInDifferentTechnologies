using System.Linq.Expressions;
using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HarmonogramyWebAPI.Services;

public class CompanyService(IContext dbContext, IMapper mapper)
    : GenericCrudService<Company, CompanyDto>(dbContext, mapper)
{
    public async Task<CompanyDto?> GetByCompanyName(Expression<Func<Company, bool>> predicateToGetName, params string[] includes)
    {
        var query = ApplyIncludes(dbContext.Set<Company>(), includes);

        var entity = await query.FirstOrDefaultAsync(predicateToGetName);
        return entity == null ? null : mapper.Map<CompanyDto>(entity);
    }
}