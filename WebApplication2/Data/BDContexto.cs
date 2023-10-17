
using MeuTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Data;

public class BDContexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
            var conectionString = "Server=localhost;Database=Todo;User=root;Password=mariogui123";

            options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
        
    }
    public DbSet<TodoModel> Todos { get; set; } 
}
