using Expenses.Core;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsServices _statisticsServices;
        public StatisticsController(IStatisticsServices statisticsServices)
        {
            _statisticsServices = statisticsServices;
        }
        [HttpGet]
        public IActionResult GetExpenseAmountPerCategory()
        {
            return Ok(_statisticsServices.GetExpenseAmountPerCategory());
        }
    }
}
