using System;
using System.Collections.Concurrent;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility;

namespace PartyQueueInMemory {
    public class PartyQueueInMemory : IPartyQueue {
        private static readonly ConcurrentQueue<Party<Room>> s_queue = new();

        Party<Room> IPartyQueue.Dequeue() {
            s_queue.TryDequeue(out var party);
            if (party != null)
                return party;
            return null;
        }

        bool IPartyQueue.Enqueue<TEntity>(TEntity party) {
            s_queue.Enqueue(party);
            return true;
        }


        private PartyQueueInMemory() { }
        public static PartyQueueInMemory Instance {
            get { return Singleton<PartyQueueInMemory>.Instance; }
            private set { }
        }
    }
}
