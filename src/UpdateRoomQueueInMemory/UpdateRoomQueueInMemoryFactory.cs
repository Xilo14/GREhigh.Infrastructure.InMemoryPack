using GREhigh.Infrastructure.Interfaces;

namespace UpdateRoomQueueInMemory {
    public class UpdateRoomQueueInMemoryFactory : IInfrastructureFactory<UpdateRoomQueueInMemory> {
        UpdateRoomQueueInMemory IInfrastructureFactory<UpdateRoomQueueInMemory>.GetInfrastructure() {
            return UpdateRoomQueueInMemory.Instance;
        }
    }
}
