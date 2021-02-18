using GREhigh.Infrastructure.Interfaces;

namespace DataStorageInMemory {
    public class UnitOfWorkInMemoryFactory : IInfrastructureFactory<IUnitOfWorkGREhigh> {
        public IUnitOfWorkGREhigh GetInfrastructure() {
            return new UnitOfWorkInMemory();
        }
    }
}
