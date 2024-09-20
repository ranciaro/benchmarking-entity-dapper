using Microsoft.AspNetCore.Mvc;


namespace PersistencePoc.Api.Concessionaria
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcessionariaController : ControllerBase
    {
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
        public IEnumerable<string> GetLevelThree()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("LevelFour")]
        public IEnumerable<string> GetLevelFour()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
