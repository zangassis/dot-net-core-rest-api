using Dapper;
using Microsoft.Extensions.Configuration;
using SensorApi.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SensorApi.Repository
{
    public sealed class SensorRepository : ISensorRepository
    {

        private readonly string _connectionString;

        public SensorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SensorDataServer");
        }

        public IEnumerable<Sensor> ListAlll()
        {
            using var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Sensor>("SELECT Id, CreatedAt, Step FROM Sensor");

            return sensorData;
        }

        public int Insert(long step)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Sensor (step)values (@step)";

            var result = connection.Execute(query, new { step = step });

            return result;
        }

    }
}
 