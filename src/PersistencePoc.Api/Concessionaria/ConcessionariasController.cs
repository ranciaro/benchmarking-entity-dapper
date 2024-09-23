using Microsoft.AspNetCore.Mvc;
using PersistencePoc.Infra.Dapper.Interfaces;
using PersistencePoc.Infra.EntityFrameworkSix.Interfaces;
using System.Diagnostics;
using System.Globalization;

namespace PersistencePoc.Api.Concessionaria
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcessionariasController : ControllerBase
    {
        private readonly IConcessionariaEntityRepository _concessionariaEntityRepository;
        private readonly IConcessionariaDapperRepository _concessionariaDapperRepository;
        private static readonly Dictionary<int, string> _executionTimes = new Dictionary<int, string>();
        private static int _executionCounter = 0;
        private static double? _firstExecutionTime = null;

        public ConcessionariasController(IConcessionariaEntityRepository concessionariaEntityRepository, IConcessionariaDapperRepository concessionariaDapperRepository)
        {
            _concessionariaEntityRepository = concessionariaEntityRepository;
            _concessionariaDapperRepository = concessionariaDapperRepository;
        }

        [HttpGet("EntityFramework-Without-Optimizations")]
        public async Task<IActionResult> GetLevelOne()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await _concessionariaEntityRepository.GetAllAsync();
            stopwatch.Stop();
            var totalTime = stopwatch.Elapsed.TotalMilliseconds;

            _executionCounter++;

            if (!_firstExecutionTime.HasValue)
            {
                _firstExecutionTime = totalTime;
                _executionTimes.Add(_executionCounter, $"Entity Framework sem otimizações, TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds");
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

                _executionTimes.Add(_executionCounter, $"Entity Framework sem otimizações, TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds, {performance}");
            }

            return Ok(_executionTimes);
        }

        [HttpGet("EntityFramework-With-Optimizations")]
        public async Task<IActionResult> GetLevelTwo()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await _concessionariaEntityRepository.GetAsync();
            stopwatch.Stop();
            var totalTime = stopwatch.Elapsed.TotalMilliseconds;

            _executionCounter++;

            if (!_firstExecutionTime.HasValue)
            {
                _firstExecutionTime = totalTime;
                _executionTimes.Add(_executionCounter, $"Entity Framework com otimizações. TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds");
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

                _executionTimes.Add(_executionCounter, $"Entity Framework com otimizações. TotalTime: {totalTime.ToString(CultureInfo.InvariantCulture)} milliseconds, {performance}");
            }

            return Ok(_executionTimes);
        }

        [HttpGet("Dapper-Without-Cache")]
        public async Task<IActionResult> GetLevelThree()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await _concessionariaDapperRepository.GetAllAsync();
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

        [HttpGet("Dapper-With-Cache")]
        public async Task<IActionResult> GetLevelFour(int pageNumber = 1, int pageSize = 10)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await _concessionariaDapperRepository.GetAsync(pageNumber, pageSize);
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
