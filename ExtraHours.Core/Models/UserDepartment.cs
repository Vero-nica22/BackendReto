public class UserDepartment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.Now;
}