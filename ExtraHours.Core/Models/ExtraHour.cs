public class ExtraHour
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public DateTime WorkStartTime { get; set; } = DateTime.Now;
    public DateTime WorkEndTime { get; set; } = DateTime.Now;
    public int TypeExtraHourId { get; set; }
    public int ApprovedBy { get; set; }
    public int StatusId { get; set; }
    public string CommentExtraHours { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
