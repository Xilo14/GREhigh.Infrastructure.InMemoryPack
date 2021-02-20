using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;

namespace GREhigh.Infrastructure.DataStorageInMemory {
    public class RoomRepositoryInMemory<T> : RepositoryInMemory<Room>, IRoomRepository where T : Room {
        public IEnumerable<Room> GetForParty(Party party) {
            throw new NotImplementedException();
        }

        public void Insert(T entity) {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => (ulong)s.RoomId);
                entity.RoomId = maxId + 1;
                s_list.Add(entity);
            }
        }

        public void Insert(IEnumerable<T> entityList) {
            lock (s_list) {
                ulong maxId;
                if (s_list.Count == 0)
                    maxId = 0;
                else
                    maxId = s_list.Max(s => (ulong)s.RoomId);
                foreach (var entity in entityList)
                    entity.RoomId = ++maxId;
                s_list.AddRange(entityList);
            }
        }
    }
}
