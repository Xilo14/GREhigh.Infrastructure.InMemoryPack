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
    }
}
