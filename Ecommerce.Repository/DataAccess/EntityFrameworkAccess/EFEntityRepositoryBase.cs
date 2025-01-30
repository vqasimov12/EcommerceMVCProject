﻿using Ecommerce.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Repository.DataAccess.EntityFrameworkAccess;

public abstract class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new() where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using var context = new TContext();
        //
        var newEntity = context.Entry(entity);
        newEntity.State = EntityState.Added;
        //
        //context.Add(newEntity);

        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var context = new TContext();
        //
        var newEntity = context.Entry(entity);
        newEntity.State = EntityState.Deleted;
        //

        //context.Remove(newEntity);

        context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter)!;
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using var context = new TContext();
        return filter == null ?
            [.. context.Set<TEntity>()] :
            [.. context.Set<TEntity>().Where(filter)];
    }

    public void Update(TEntity entity)
    {

        using var context = new TContext();
        //
        var newEntity = context.Entry(entity);
        newEntity.State = EntityState.Modified;
        //
        //context.Update(newEntity);

        context.SaveChanges();
    }
}