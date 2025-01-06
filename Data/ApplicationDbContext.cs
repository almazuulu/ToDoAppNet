using Microsoft.EntityFrameworkCore;
using TodoApp.Models;  // Добавляем ссылку на пространство имен моделей

namespace TodoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;  // Добавляем null! для избежания предупреждений nullable
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Дополнительная конфигурация модели, если необходима
            modelBuilder.Entity<TodoItem>()
                .Property(t => t.Title)
                .IsRequired()  // Делаем поле Title обязательным
                .HasMaxLength(100);  // Ограничиваем длину строки
        }
    }
}