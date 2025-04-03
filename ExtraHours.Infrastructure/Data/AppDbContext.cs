// using ExtraHours.Core.Models;
// using Microsoft.EntityFrameworkCore;

// namespace ExtraHours.Infrastructure.Data {
//     public class AppDbContext: DbContext {
//         public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

//         public DbSet<User> Users {get; set;}
//         public DbSet<Role> Roles {get; set;}
//         public DbSet<Permission> Permissions {get; set;}

//     }
// }

using ExtraHours.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace ExtraHours.Infrastructure.Data


{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ExtraHour> ExtraHours { get; set; }

        public DbSet<TypeExtraHours> TypeExtraHours { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(u => u.DepartmentId);
        }
    }
}