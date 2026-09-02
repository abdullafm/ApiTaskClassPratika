using ApiPratica.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = ApiPratica.Models.Group;

namespace ApiPratica.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
