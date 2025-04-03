public class Request
{
    public int Id { get; set; }
    public int ExtraHoursId { get; set; }
    public int UserId { get; set; }
    public DateTime ApprovalDate { get; set; }
    public int StatusId { get; set; }
    public string Comment { get; set; } = string.Empty;
}