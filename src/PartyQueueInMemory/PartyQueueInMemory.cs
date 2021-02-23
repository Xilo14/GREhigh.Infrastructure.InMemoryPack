using System;
using System.Collections.Concurrent;
using System.Linq;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility;

namespace GREhigh.Infrastructure.PartyQueueInMemory {
    public class PartyQueueInMemory : IPartyQueue {
        private static readonly ConcurrentQueue<Party> s_queue = new();

        public Party Dequeue() {
            s_queue.TryDequeue(out var party);
            if (party != null)
                return party;
            return null;
        }

        public bool Enqueue<TEntity>(TEntity party) where TEntity : Party {
            s_queue.Enqueue(party);
            return true;
        }

        public bool IsPartyUniq<TEntity>(TEntity party) where TEntity : Party {
            return !s_queue
                        .SelectMany(x => x.Players)
                        .Any(x => party.Players.Contains(x));
        }

        private PartyQueueInMemory() { }
        public static PartyQueueInMemory Instance {
            get { return Singleton<PartyQueueInMemory>.Instance; }
            private set { }
        }
    }
}
