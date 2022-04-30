using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace WorkNotes.Core
{
    public class AppServiceProvider
    {
        private static AppServiceProvider _instance = new AppServiceProvider();
        private readonly ConcurrentDictionary<RuntimeTypeHandle, EntityMeta> serviceDictionary;

        public static AppServiceProvider Instance { get => _instance; }

        private AppServiceProvider()
        {
            serviceDictionary = new ConcurrentDictionary<RuntimeTypeHandle, EntityMeta>();
        }


        public void Register(Type type, object instance)
        {
            serviceDictionary.TryAdd(type.TypeHandle, new EntityMeta(instance.GetType(), null));
        }

        public void RegisterAsSingleton(Type type, object singletonInstance)
        {
            serviceDictionary.TryAdd(type.TypeHandle, new EntityMeta(singletonInstance.GetType(), singletonInstance));
        }

        public T Get<T>()
        {

            if (!serviceDictionary.TryGetValue(typeof(T).TypeHandle, out var instanceMeta))
                throw new Exception(string.Format("ServiceRegistry key is not found in dictionary {0} ", typeof(T).ToString()));

            return instanceMeta.CreateInstance<T>();
        }

        internal class EntityMeta
        {
            private readonly Func<object> constructor = null;
            private readonly object singletonInstance = null;
            private readonly Type instanceType = null;
            private readonly bool isTransactional = false;

            public EntityMeta(Type instanceType, object singletonInstance)
            {
                this.instanceType = instanceType;
                this.singletonInstance = singletonInstance;
                if (singletonInstance == null || this.isTransactional)
                    this.constructor = Expression.Lambda<Func<object>>(Expression.New(instanceType)).Compile();
            }

            internal T CreateInstance<T>()
            {
                if (singletonInstance == null)
                {
                    var instance = constructor();
                    return (T)instance;
                }
                else
                {
                    //Singleton olarak kaydedilen instance transactional değilse aynısını geri çevir.
                    return (T)singletonInstance;
                }
            }
        }
    }
}
