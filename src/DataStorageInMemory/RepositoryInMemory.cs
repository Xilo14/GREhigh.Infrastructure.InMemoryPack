using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Linq.Expressions;
using System.Collections;

namespace GREhigh.Infrastructure.DataStorageInMemory {
    public class RepositoryInMemory<T> : IRepository<T>
            where T : class, IHaveId<ulong> {
        protected static readonly List<T> s_list = new();

        public void Delete(object id) {
            throw new NotImplementedException();
        }

        public void Delete(T entityToDelete) {
            lock (s_list) {
                s_list.Remove(entityToDelete);
            }
        }

        public void Delete<T1>(T1 entityToDelete)
        where T1 : class, IHaveId<ulong> {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") {
            // lock (s_list) {
            //     IEnumerable<T> query = s_list.ToList();
            //     if (filter != null) {
            //         query = s_list.Where(filter.);
            //     }

            //     // foreach (var includeProperty in includeProperties.Split
            //     //     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
            //     //     query = query.Include(includeProperty);
            //     // }

            //     // if (orderBy != null) {
            //     //     return orderBy(query).ToList();
            //     // } else {
            //     //     return query.ToList();
            //     // }
            //     return query;
            // }
            throw new NotImplementedException();
        }

        public IEnumerable<T1> Get<T1>(
            Expression<Func<T1, bool>> filter = default, Func<IQueryable<T1>,
             IOrderedQueryable<T1>> orderBy = default, string includeProperties = "") {
            throw new NotImplementedException();
        }

        public T GetByID(ulong id) {
            return s_list
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerator<T> GetEnumerator() {
            return s_list.GetEnumerator();
        }

        public void Insert(T entity) {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => s.Id);
                entity.Id = maxId + 1;
                s_list.Add(entity);
            }
        }

        public void Insert(IEnumerable<T> entityList) {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => s.Id);
                foreach (var entity in entityList)
                    entity.Id = ++maxId;
                s_list.AddRange(entityList);
            }
        }

        public void Insert<T1>(T1 entity)
        where T1 : class, IHaveId<ulong> {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => s.Id);
                entity.Id = maxId + 1;
                s_list.Add(entity as T);
            }
        }

        public void Insert<T1>(IEnumerable<T1> entityList)
        where T1 : class, IHaveId<ulong> {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => s.Id);
                foreach (var entity in entityList)
                    entity.Id = ++maxId;
                s_list.AddRange(entityList as IEnumerable<T>);
            }
        }


        public void Update<T1>(T1 entityToUpdate)
        where T1 : class, IHaveId<ulong> {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}
