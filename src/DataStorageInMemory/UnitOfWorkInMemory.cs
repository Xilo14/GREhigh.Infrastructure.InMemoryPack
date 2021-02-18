using System;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.RoomRegistries;
using GREhigh.RoomStaffBase.Interfaces;

namespace DataStorageInMemory {
    public class UnitOfWorkInMemory : IUnitOfWorkGREhigh {
        private RepositoriesRegistry _repositoriesRegistry;
        private RepositoryInMemory<Player> _playersRepository = new();
        private RepositoryInMemory<Transaction> _transactionsRepository = new();

        public void Dispose() {
            throw new NotImplementedException();
        }

        public IRepository<Player> GetPlayerRepository() {
            return _playersRepository;
        }

        public IRepository<Transaction> GetTransactionsRepository() {
            return _transactionsRepository;
        }

        public void Save() {

        }

        public bool SetRepositoryRegistry(RepositoriesRegistry repositoryRegistry) {
            _repositoriesRegistry = repositoryRegistry;
            return true;
        }

        public bool TryGetRoomRepository<T>(Type typeRoom, out T repository)
            where T : IRepository<Room> {
            if (_repositoriesRegistry != null) {
                repository = (T)_repositoriesRegistry.GetForRoom(typeRoom).GetInfrastructure();
                return true;
            }
            repository = default;
            return false;
        }

        bool IUnitOfWorkGREhigh.SetRepositoryRegistry<T>(T repositoryRegistry) {
            throw new NotImplementedException();
        }
    }
}
