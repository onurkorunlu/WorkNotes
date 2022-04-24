using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WorkNotes.DataAccess.Base
{
    public interface IBaseDataAccess<TEntity> where TEntity : class, new()
    {
        List<TEntity> GetAll();
        List<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(string id, string type = "object");
        TEntity InsertOne(TEntity entity);
        List<TEntity> InsertMany(ICollection<TEntity> entities);
        TEntity ReplaceOne(TEntity entity, string id, string type = "object");
        TEntity DeleteById(string id, string type = "object");

    }
}
