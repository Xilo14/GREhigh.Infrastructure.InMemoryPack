using GREhigh.Infrastructure.Interfaces;

namespace UpdateRoomQueueInMemory {
    public class UpdateRoomQueueInMemoryFactory : IInfrastructureFactory<UpdateRoomQueueInMemory> {
        public UpdateRoomQueueInMemory GetInfrastructure() {
            return UpdateRoomQueueInMemory.Instance;
        }
    }
}
