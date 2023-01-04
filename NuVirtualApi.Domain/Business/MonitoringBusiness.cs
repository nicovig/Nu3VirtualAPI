using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Monitoring;
using NuVirtualApi.Domain.Models.Response.Monitoring;

namespace NuVirtualApi.Domain.Business
{
    public class MonitoringBusiness : IMonitoringBusiness
    {
        public IMonitoringManager _monitoringManager;

        public MonitoringBusiness(IMonitoringManager monitoringManager)
        {
            _monitoringManager = monitoringManager;
        }

        public MonitoringViewModel GetMonitoringByUserIdAndDate(GetMonitoringByUserIdAndDateRequest request)
        {
            return _monitoringManager.GetMonitoringByUserIdAndDate(request);
        }
    }
}