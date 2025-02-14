using Microsoft.EntityFrameworkCore;

namespace SGRH.Persistence.Context
{
    public class DBHotelContext : DbContext
    {
        public DBHotelContext(DbContextOptions<DBHotelContext> opctions) : base(opctions);


        public DbSet<Departament> Departaments { get; set; } 
        
        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
