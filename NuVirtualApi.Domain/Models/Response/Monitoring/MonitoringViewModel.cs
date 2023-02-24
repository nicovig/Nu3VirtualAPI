using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Domain.Models.Response.Monitoring
{
    public class MonitoringViewModel
    {
        public List<NutritionGoalMonitoringViewModel> NutritionGoalsMonitoring { get; set; }
    }

    public class NutritionGoalMonitoringViewModel
    {
        public MonitoringInformationTypeEnum Type { get; set; }
        public int Value { get; set; }
    }

    public enum MonitoringInformationTypeEnum
    {
        CaloriesBurned,
        CaloriesConsumed,
        Carbohydrate,
        Lipid,
        Protein
    }
}

