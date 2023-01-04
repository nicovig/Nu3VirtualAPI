using NuVirtualApi.Domain.Models.Request.Monitoring;
using NuVirtualApi.Domain.Models.Response.Monitoring;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IMonitoringManager
    {
        MonitoringViewModel GetMonitoringByUserIdAndDate(GetMonitoringByUserIdAndDateRequest request);
    }
}
