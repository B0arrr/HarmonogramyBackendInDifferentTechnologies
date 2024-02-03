using System.Linq.Expressions;
using AutoMapper;
using HarmonogramyWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarmonogramyWebAPI.Generic;

public class GenericCrudService<TModel, TDto>(IContext dbContext, IMapper mapper) : IGenericCrudService<TModel, TDto>
    where TModel : class
    where TDto : class
{
    public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TModel, bool>>? where = null, params string[] includes)
    {
        var query = ApplyIncludes(dbContext.Set<TModel>(), includes);
        
        if (where != null)
        {
            query = query.Where(where);
        }

        var entities = await query.ToListAsync();
        return mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetById(Expression<Func<TModel, bool>> predicateToGetId, params string[] includes)
    {
        var query = ApplyIncludes(dbContext.Set<TModel>(), includes);

        var entity = await dbContext.Set<TModel>().FirstOrDefaultAsync(predicateToGetId);
        return entity == null ? null : mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Add(TDto dto, params Expression<Func<TModel, object>>[] references)
    {
        var entity = mapper.Map<TModel>(dto);
        dbContext.Set<TModel>().Add(entity);

        await LoadReferences(entity, references);
        await dbContext.SaveChangesAsync();

        return mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Update(TDto dto, Expression<Func<TModel, bool>>? where = null, params Expression<Func<TModel, object>>[] references)
    {
        var query = dbContext.Set<TModel>().AsQueryable();

        if (where != null)
        {
            query = query.Where(where);
        }

        var entity = await query.FirstOrDefaultAsync();
        if (entity == null) throw new Exception("Entity not found");
        await LoadReferences(entity, references);
        await dbContext.SaveChangesAsync();
        return mapper.Map<TDto>(entity);
    }

    public async Task<TDto?> Delete(int id)
    {
        var entity = await dbContext.Set<TModel>().FindAsync(id);
        if (entity == null) return null;

        dbContext.Set<TModel>().Remove(entity);
        await dbContext.SaveChangesAsync();

        return mapper.Map<TDto>(entity);
    }

    protected IQueryable<TModel> ApplyIncludes(IQueryable<TModel> query, params string[] includes)
    {
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }

    private async Task LoadReferences(TModel entity, IEnumerable<Expression<Func<TModel, object>>> references)
    {
        foreach (var reference in references)
        {
            await dbContext.Entry(entity).Reference(reference!).LoadAsync();
        }
    }
}