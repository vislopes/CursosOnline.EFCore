using CursosOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursosOnline.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=CursosOnlineDb;Trusted_Connection=True;");
    }
}

