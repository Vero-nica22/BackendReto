namespace ExtraHours.Core.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public bool ViewExtraHours { get; set; }
        public bool UpdateExtraHours { get; set; }
        public bool CreateExtraHours { get; set; }
        public bool ApproveExtraHours { get; set; }
        public string StatusExtraHours { get; set; } = string.Empty;
        public bool IsActivePermission { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}