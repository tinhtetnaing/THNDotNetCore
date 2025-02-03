using Microsoft.AspNetCore.Mvc;

namespace THNDotNetCore.ChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
