using System;
using TodoApp.Console.Domain;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.NamingConventions;

namespace TodoApp.Console.Data;

public class TodoDbContext : DbContext
{
    public DbSet<TodoTask> Tasks
    {
        get { return Set<TodoTask>(); }
    }

    public DbSet<TodoList> List
    {
        get { return Set<TodoList>(); }
    }

    public DbSet<Tag> Tag
    {
        get { return Set<Tag>(); }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host=localhost;Port=5435;Database=todo_db;Username=todo_user;Password=todo_password")
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoTask>().ToTable("tasks");
        modelBuilder.Entity<TodoList>().ToTable("list");
        modelBuilder.Entity<Tag>().ToTable("tag");

        var utcConverter = new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
            v => ToUtcForWrite(v),
            v => ToUtcForRead(v));

        modelBuilder.Entity<TodoTask>()
            .Property(t => t.CreatedAt)
            .HasConversion(utcConverter);

        modelBuilder.Entity<TodoList>()
            .Property(l => l.CreatedAt)
            .HasConversion(utcConverter);

        modelBuilder.Entity<TodoTask>()
            .HasMany("Tags")
            .WithMany("Tasks")
            .UsingEntity(ConfigureJoinTable);
    }

    private static DateTime ToUtcForWrite(DateTime v) =>
        v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc);

    private static DateTime ToUtcForRead(DateTime v) =>
        DateTime.SpecifyKind(v, DateTimeKind.Utc);

    // M-N relations --> Junction tables:
    private static void ConfigureJoinTable(EntityTypeBuilder joinBuilder)
    {
        joinBuilder.ToTable("task_tag");
    }
}