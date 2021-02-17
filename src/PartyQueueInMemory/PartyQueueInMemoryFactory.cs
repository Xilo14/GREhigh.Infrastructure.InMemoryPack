using GREhigh.Infrastructure.Interfaces;

namespace PartyQueueInMemory {
    public class PartyQueueInMemoryFactory : IInfrastructureFactory<PartyQueueInMemory> {
        PartyQueueInMemory IInfrastructureFactory<PartyQueueInMemory>.GetInfrastructure() {
            return PartyQueueInMemory.Instance;
        }
    }
}
