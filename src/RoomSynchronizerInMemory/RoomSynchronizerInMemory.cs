using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using GREhigh.DomainBase;
using GREhigh.Infrastructure.Interfaces;
using GREhigh.Utility;

namespace GREhigh.Infrastructure.RoomSynchronizerInMemory {
    public class RoomSynchronizerInMemory : IRoomSynchronizer {
        private static readonly ConcurrentDictionary<Room, bool> s_lockDict = new();
        private static readonly object s_locker = new object();
        public void Free(Room room) {
            lock (s_locker) {
                s_lockDict[room] = false;
            }
        }

        public bool TryLock(Room room) {
            bool success;//true - succesfully locked, false - already was locked
            lock (s_locker) {
                if (!s_lockDict.ContainsKey(room)) {
                    s_lockDict[room] = true;
                    success = true;
                } else if (s_lockDict[room] == true)
                    success = false;
                else {
                    success = true;
                    s_lockDict[room] = true;
                }
            }
            return success;
        }

        private RoomSynchronizerInMemory() { }
        public static RoomSynchronizerInMemory Instance {
            get { return Singleton<RoomSynchronizerInMemory>.Instance; }
            private set { }
        }
    }
}
