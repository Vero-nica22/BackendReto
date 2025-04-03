public class TypeExtraHours
{
    public int Id { get; set; }
    public string TypeExtraHourName { get; set; } = string.Empty;
    public decimal RateMultiplier { get; set; }
    public bool IsActiveTypeExtraHour { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}