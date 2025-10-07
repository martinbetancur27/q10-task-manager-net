using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q10.TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        public IConfig Config { get; set; }
        public ConfigController(IEnumerable<IConfig> configs)
        {
            Config = configs.OfType<EnvironmentRepository>().FirstOrDefault();
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(Config.GetValue("ASPNETCORE_ENVIRONMENT"));
        }
    }
}