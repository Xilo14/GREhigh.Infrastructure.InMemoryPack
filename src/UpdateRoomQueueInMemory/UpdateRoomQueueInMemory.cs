using System;
using System.Collections.Concurrent;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility;

namespace UpdateRoomQueueInMemory {
    public class UpdateRoomQueueInMemory : IUpdateRoomQueue {
        private static readonly ConcurrentQueue<UpdateQueueRecord> s_queue = new();

        UpdateQueueRecord IUpdateRoomQueue.Dequeue() {
            s_queue.TryDequeue(out var update);
            if (update != null)
                return update;
            return null;
        }

        bool IUpdateRoomQueue.Enqueue(UpdateQueueRecord update) {
            s_queue.Enqueue(update);
            return true;
        }


        private UpdateRoomQueueInMemory() { }
        public static UpdateRoomQueueInMemory Instance {
            get { return Singleton<UpdateRoomQueueInMemory>.Instance; }
            private set { }
        }
    }
}
