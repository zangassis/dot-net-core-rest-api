using SensorApi.Domain;
using System.Collections.Generic;

namespace SensorApi.Repository
{
   public interface ISensorRepository
    {
        public IEnumerable<Sensor> ListAlll();

        public int Insert(long step);
    }
}
