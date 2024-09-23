using Microsoft.AspNetCore.Mvc;
using PersistencePoc.Infra.Dapper.Interfaces;
using PersistencePoc.Infra.Dapper.Repositories;
using System.Diagnostics;
using System.Globalization;

namespace PersistencePoc.Api.Concessionaria
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcessionariaController : ControllerBase
    {
        private readonly IConcessionariaDapperRepository _concessionariaRepository;
        private static readonly Dictionary<int, string> _executionTimes = new Dictionary<int, string>();
        private static int _executionCounter = 0;
        private static double? _firstExecutionTime = null;

        public ConcessionariaController(IConcessionariaDapperRepository concessionariaRepository)
        {
            _concessionariaRepository = concessionariaRepository;
        }

        [HttpGet("LevelOne")]
        public IEnumerable<string> GetLevelOne()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("LevelTwo")]
        public IEnumerable<string> GetLevelTwo()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("LevelThree")]
        public async Task<IActionResult> GetLevelThree()
        {
            var stopwatch = Stopwatch.StartNew();
            await _concessionariaRepository.GetAllAsync();
            stopwatch.Stop();
            var totalTime = stopwatch.Elapsed.TotalMilliseconds;

            _executionCounter++;

            if (!_firstExecutionTime.HasValue)
            {
                _firstExecutionTime = totalTime;
                _executionTimes.Add(_executionCounter, $"Dapper sem otimizações e sem Cache, TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds");
            }
            else
            {
                double difference = totalTime / _firstExecutionTime.Value;
                string performance;

                if (totalTime < _firstExecutionTime.Value)
                {
                    performance = $"{(_firstExecutionTime.Value / totalTime).ToString("F2", CultureInfo.InvariantCulture)}x mais rápido do que a primeira execução";
                }
                else
                {
                    performance = $"{difference.ToString("F2", CultureInfo.InvariantCulture)}x mais lento do que a primeira execução";
                }

                _executionTimes.Add(_executionCounter, $"Dapper sem otimizações e sem Cache, TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds, {performance}");
            }

            return Ok(_executionTimes);
        }

        [HttpGet("LevelFour")]
        public async Task<IActionResult> GetLevelFour(int pageNumber = 1, int pageSize = 10)
        {
            var stopwatch = Stopwatch.StartNew();
            await _concessionariaRepository.GetAsync(pageNumber, pageSize);
            stopwatch.Stop();
            var totalTime = stopwatch.Elapsed.TotalMilliseconds;

            _executionCounter++;

            if (!_firstExecutionTime.HasValue)
            {
                _firstExecutionTime = totalTime;
                _executionTimes.Add(_executionCounter, $"Dapper com otimizações e com Cache. TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds");
            }
            else
            {
                double difference = totalTime / _firstExecutionTime.Value;
                string performance;

                if (totalTime < _firstExecutionTime.Value)
                {
                    performance = $"{(_firstExecutionTime.Value / totalTime).ToString("F2", CultureInfo.InvariantCulture)}x mais rápido do que a primeira execução";
                }
                else
                {
                    performance = $"{difference.ToString("F2", CultureInfo.InvariantCulture)}x mais lento do que a primeira execução";
                }

                _executionTimes.Add(_executionCounter, $"Dapper com otimizações e com Cache. TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds, {performance}");
            }

            return Ok(_executionTimes);
        }
    }
}
