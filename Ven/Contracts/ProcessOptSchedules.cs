using Oadr.Library;
using Oadr.Library.Profile2B;
using System.Collections.Generic;

namespace Oadr.Ven
{
    internal class ProcessOptSchedules
    {
        private readonly Queue<OptSchedule> _queuedOptSchedules = new Queue<OptSchedule>();

        public CreateOpt ProcessOptSchedule(Ven2B ven)
        {
            OptSchedule optSchedule;
            lock (_queuedOptSchedules)
            {
                if (_queuedOptSchedules.Count == 0)
                {
                    return null;
                }

                optSchedule = _queuedOptSchedules.Dequeue();
            }
            return ven.CreateOptSchedule(RandomHex.Instance().GenerateRandomHex(10), optSchedule);

        }

        public void QueueOptSchedule(OptSchedule optSchedule)
        {
            lock (_queuedOptSchedules)
            {
                _queuedOptSchedules.Enqueue(optSchedule);
            }
        }
    }
}
