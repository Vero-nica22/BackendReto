using ExtraHours.Core.Models;
using ExtraHours.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExtraHours.Core.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los departamentos
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        // Obtener un departamento por ID
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        // Agregar un nuevo departamento
        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        // Actualizar un departamento existente
        public async Task UpdateDepartmentAsync(Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(department.Id);
            if (existingDepartment != null)
            {
                _context.Entry(existingDepartment).CurrentValues.SetValues(department);
                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un departamento por ID
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}