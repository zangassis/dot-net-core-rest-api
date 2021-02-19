using System;

namespace SensorApi.Domain
{
    public sealed class Sensor
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public long Step { get; set; }
    }
}
