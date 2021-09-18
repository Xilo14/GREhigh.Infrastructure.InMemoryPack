using GREhigh.Infrastructure.DataStorageInMemory;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility.Interfaces;

namespace DataStorageInMemory {
    public class RepositoryInMemoryFactory<T> : IInfrastructureFactory<RepositoryInMemory<T>>
        where T : class, IHaveId<ulong> {
        // public IRepository<T> GetInfrastructure() {
        //     return new RepositoryInMemory<T>();
        // }
        public RepositoryInMemory<T> GetInfrastructure() {
            return new RepositoryInMemory<T>();
        }
    }
}
