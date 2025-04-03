namespace ExtraHours.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string NameDepartment { get; set; } = string.Empty;
        public bool IsActiveDepartment { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}