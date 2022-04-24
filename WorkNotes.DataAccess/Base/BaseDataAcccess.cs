using WorkNotes.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using WorkNotes.Common;
using System.Collections.Generic;
using System;
using System.Linq;
using WorkNotes.Entities;

namespace WorkNotes.DataAccess.Base
{
    public abstract class BaseDataAcccess<TEntity> where TEntity : MongoBaseModel, new()
    {
        private readonly MongoClient MongoClient;
        private readonly IMongoDatabase MongoDatabase;
        IMongoCollection<TEntity> _collection;

        public BaseDataAcccess()
        {
            if (ConfigurationCache.Instance.TryGet("MongoDbConnectionString", out string connectionString))
            {
                MongoClient = new MongoClient(connectionString);
            }
            else
            {
                throw new AppException(ReturnMessages.MONGO_DB_CONN_NOT_FOUND_IN_CONFIGURATION);
            }

            if (ConfigurationCache.Instance.TryGet("MongoDbName", out string databaseName))
            {
                MongoDatabase = MongoClient.GetDatabase(databaseName);
            }
            else
            {
                throw new AppException(ReturnMessages.MONGO_DB_NAME_NOT_FOUND_IN_CONFIGURATION);
            }

            _collection = MongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> result = new List<TEntity>();
            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                    result = data;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex);
            }

            return result;
        }

        public TEntity DeleteById(string id, string type = "object")
        {
            var result = new TEntity();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var item = this.GetById(id, type);
                item.UpdateDate = DateTime.Now;
                item.RecordStatus = false;
                this.ReplaceOne(item, id, type);
                result = item;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { id = id});
            }
            return result;
        }

        public List<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new List<TEntity>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                    result = data;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { filter = filter });

            }
            return result;
        }

        public TEntity GetById(string id, string type = "object")
        {
            var result = new TEntity();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                    result = data;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { id = id });
            }
            return result;
        }

        public List<TEntity> InsertMany(ICollection<TEntity> entities)
        {
            var result = new List<TEntity>();
            try
            {
                _collection.InsertMany(entities);
                result = entities.ToList();
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { entities = entities });
            }
            return result;
        }

        public TEntity InsertOne(TEntity entity)
        {
            var result = new TEntity();
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.RecordStatus = true;
                _collection.InsertOne(entity);
                result = entity;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { entity = entity });
            }
            return result;
        }

        public TEntity ReplaceOne(TEntity entity, string id, string type = "object")
        {
            var result = new TEntity();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                entity.UpdateDate = DateTime.Now;
                var updatedDocument = _collection.ReplaceOne(filter, entity);
                result = entity;
            }
            catch (Exception ex)
            {
                throw new AppException(ReturnMessages.MONGO_DB_ERROR, ex, null, new { entity = entity, id = id });
            }
            return result;
        }

    }
}
