using GREhigh.Infrastructure.Interfaces;

namespace GREhigh.Infrastructure.DataStorageInMemory {
    public class UnitOfWorkInMemoryFactory : IInfrastructureFactory<IUnitOfWorkGREhigh> {
        public virtual IUnitOfWorkGREhigh GetInfrastructure() {
            return new UnitOfWorkInMemory();
        }
    }
}
