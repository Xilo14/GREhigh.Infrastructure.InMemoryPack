using GREhigh.Infrastructure.Interfaces;

namespace GREhigh.Infrastructure.RoomSynchronizerInMemory {
    public class RoomSynchronizerInMemoryFactory :
        IInfrastructureFactory<IRoomSynchronizer> {
        public IRoomSynchronizer GetInfrastructure() {
            return RoomSynchronizerInMemory.Instance;
        }
    }
}
