using Ispit.Todo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
