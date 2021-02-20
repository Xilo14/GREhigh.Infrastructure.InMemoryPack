using System;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.RoomRegistries;
using GREhigh.RoomStaffBase.Interfaces;

namespace GREhigh.Infrastructure.DataStorageInMemory {
    public class UnitOfWorkInMemory : IUnitOfWorkGREhigh {
        private RepositoriesRegistry _repositoriesRegistry;
        private RepositoryInMemory<Player> _playersRepository = new();
        private RepositoryInMemory<Transaction> _transactionsRepository = new();

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


        public bool SetRepositoryRegistry<T>(T repositoryRegistry) where T : AbstractRegistry<IInfrastructureFactory<IRoomRepository>> {
            _repositoriesRegistry = repositoryRegistry as RepositoriesRegistry;
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


    }
}
