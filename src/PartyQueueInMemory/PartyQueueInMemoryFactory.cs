using GREhigh.Infrastructure.Interfaces;

namespace PartyQueueInMemory {
    public class PartyQueueInMemoryFactory : IInfrastructureFactory<PartyQueueInMemory> {
        public PartyQueueInMemory GetInfrastructure() {
            return PartyQueueInMemory.Instance;
        }
    }
}
