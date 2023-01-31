using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoDBContext : DbContext
    {
        public EmpleadoDBContext(DbContextOptions<EmpleadoDBContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
