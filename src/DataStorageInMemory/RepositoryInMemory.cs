using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GREhigh.Infrastructure.Interfaces;

namespace DataStorageInMemory {
    public class RepositoryInMemory<T> : IRepository<T> {
        private static readonly List<T> s_list = new();

        public void Delete(object id) {
            throw new NotImplementedException();
        }

        public void Delete(T entityToDelete) {
            lock (s_list) {
                s_list.Remove(entityToDelete);
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") {
            throw new NotImplementedException();
        }

        public T GetByID(object id) {
            throw new NotImplementedException();
        }

        public void Insert(T entity) {
            lock (s_list) {
                s_list.Add(entity);
            }
        }

        public void Insert(IEnumerable<T> entityList) {
            lock (s_list) {
                s_list.AddRange(entityList);
            }
        }

        public void Update(T entityToUpdate) {

        }
    }
}
