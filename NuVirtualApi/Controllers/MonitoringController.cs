using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Monitoring;
using NuVirtualApi.Domain.Models.Response.Monitoring;

[ApiController]
[Route("[controller]")]
public class MonitoringController : Controller
{
    private static IMonitoringBusiness _monitoringBusiness;

    public MonitoringController(IMonitoringBusiness monitoringBusiness)
    {
        _monitoringBusiness = monitoringBusiness;
    }

    [HttpGet]
    public ActionResult<MonitoringViewModel> GetMonitoringByUserIdAndDate([FromHeader] int userId, [FromHeader] DateTime date)
    {
        var request = new GetMonitoringByUserIdAndDateRequest()
        {
            Date = date,
            UserId = userId
        };

        return _monitoringBusiness.GetMonitoringByUserIdAndDate(request);
    }
}
