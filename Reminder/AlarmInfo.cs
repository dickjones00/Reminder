using System;

namespace Reminder
{
    internal class AlarmInfo
    {
        private static int m_Counter = 0;
        public AlarmInfo()
        {
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
        }
        public int Id { get; private set; }
        public bool Active { get; set; }
        public string Note { get; set; }
        public DateTime TimeAt { get; set; }
        public string PlaySound { get; set; }
        public bool Fired { get; set; }
        public AlarmInfo(bool active, string note, DateTime timeAt, string playSound, bool fired)
        {
            Active = active;
            Note = note;
            TimeAt = timeAt;
            PlaySound = playSound;
            Fired = fired;
        }
    }
}