using Microsoft.EntityFrameworkCore;

namespace HelloAngular.Models
{
    /// <summary>
    /// TodoContext
    /// </summary>
    public class TodoContext : DbContext
    {
        /// <summary>
        /// TodoContext
        /// </summary>
        /// <param name="options"></param>
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// TodoItems
        /// </summary>
        /// <returns></returns>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
