using GREhigh.Infrastructure.Interfaces;

namespace GREhigh.Infrastructure.PartyQueueInMemory {
    public class PartyQueueInMemoryFactory : IInfrastructureFactory<IPartyQueue> {
        public IPartyQueue GetInfrastructure() {
            return PartyQueueInMemory.Instance;
        }
    }
}
