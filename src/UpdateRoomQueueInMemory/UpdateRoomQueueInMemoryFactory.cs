using GREhigh.Infrastructure.Interfaces;

namespace GREhigh.Infrastructure.UpdateRoomQueueInMemory {
    public class UpdateRoomQueueInMemoryFactory : IInfrastructureFactory<IUpdateRoomQueue> {
        public IUpdateRoomQueue GetInfrastructure() {
            return UpdateRoomQueueInMemory.Instance;
        }
    }
}
