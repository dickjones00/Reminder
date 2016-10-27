using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Reminder
{
    internal class AlarmInfo
    {
        private static int m_Counter = 0;
        public AlarmInfo()
        {
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
        }
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; private set; }
        [JsonProperty(PropertyName = "Active")]
        public bool Active { get; set; }
        [JsonProperty(PropertyName = "Note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "TimeAt")]
        public DateTime TimeAt { get; set; }
        [JsonProperty(PropertyName = "PlaySound")]
        public string PlaySound { get; set; }
        [JsonProperty(PropertyName = "Fired")]
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