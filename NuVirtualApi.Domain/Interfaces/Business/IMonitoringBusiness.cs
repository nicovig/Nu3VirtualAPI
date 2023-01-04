using NuVirtualApi.Domain.Models.Request.Monitoring;
using NuVirtualApi.Domain.Models.Response.Monitoring;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IMonitoringBusiness
    {
        MonitoringViewModel GetMonitoringByUserIdAndDate(GetMonitoringByUserIdAndDateRequest request);
    }
}
