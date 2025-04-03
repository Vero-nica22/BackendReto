namespace ExtraHours.Core.Services
{
    public interface IExtraHourService
    {
        Task<IEnumerable<ExtraHour>> GetAllExtraHoursAsync();
        Task<ExtraHour?> GetExtraHourByIdAsync(int id);
        Task AddExtraHourAsync(ExtraHour extraHour);
        Task UpdateExtraHourAsync(ExtraHour extraHour);
        Task DeleteExtraHourAsync(int id);
    }
}