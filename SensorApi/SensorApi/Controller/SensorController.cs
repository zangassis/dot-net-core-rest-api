using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SensorApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ILogger<SensorController> _logger;
        private readonly ISensorRepository _sensorRepository;

        public SensorController(ILogger<SensorController> logger, ISensorRepository sensorRepository)
        {
            this._logger = logger;
            this._sensorRepository = sensorRepository;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            try
            {
                var data = _sensorRepository.ListAlll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on get data");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody] long step)
        {
            try
            {
                var result = _sensorRepository.Insert(step);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on get data");
                return new StatusCodeResult(500);
            }
        }
    }
}
