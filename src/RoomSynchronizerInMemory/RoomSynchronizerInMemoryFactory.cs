using GREhigh.Infrastructure.Interfaces;

namespace RoomSynchronizerInMemory {
    public class RoomSynchronizerInMemoryFactory :
        IInfrastructureFactory<RoomSynchronizerInMemory> {
        public RoomSynchronizerInMemory GetInfrastructure() {
            return RoomSynchronizerInMemory.Instance;
        }
    }
}
