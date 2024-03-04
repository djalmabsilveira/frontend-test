using Microsoft.EntityFrameworkCore;
using WebApplication_Teste.Models;

namespace WebApplication_Teste.Dao.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
    }
}
