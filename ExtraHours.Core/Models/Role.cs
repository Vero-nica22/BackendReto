namespace ExtraHours.Core.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string NameRol { get; set; } = string.Empty;
        public bool IsActiveRol { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}