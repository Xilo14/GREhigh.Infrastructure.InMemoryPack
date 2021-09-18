using System;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.RoomRegistries;
using GREhigh.RoomStaffBase.Interfaces;

namespace GREhigh.Infrastructure.DataStorageInMemory {
    public class UnitOfWorkInMemory : IUnitOfWorkGREhigh {
        protected RepositoriesRegistry _repositoriesRegistry;
        protected RepositoryInMemory<Player> _playersRepository = new();
        protected RepositoryInMemory<Transaction> _transactionsRepository = new();

        public void Dispose() {

        }

        public IRepository<Player> GetPlayerRepository() {
            return _playersRepository;
        }

        public IRepository<Transaction> GetTransactionsRepository() {
            return _transactionsRepository;
        }

        public void Save() {

        }


        public bool SetRepositoryRegistry<T>(T repositoryRegistry) where T : AbstractRegistry<IInfrastructureFactory<IRepository<Room>>> {
            _repositoriesRegistry = repositoryRegistry as RepositoriesRegistry;
            return true;
        }

        public bool TryGetRoomRepository<T1, T2>(Type typeRoom, out T1 repository)
            where T1 : IRepository<T2>
            where T2 : Room {
            if (_repositoriesRegistry != null) {
                repository = (T1)_repositoriesRegistry.GetForRoom(typeRoom).GetInfrastructure();
                return true;
            }
            repository = default;
            return false;
        }
    }
}
