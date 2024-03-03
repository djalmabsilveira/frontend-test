using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
        }
    }
}
