using Microsoft.EntityFrameworkCore;
using Perez_T3.DB.Mapping;
using Perez_T3.Models;

namespace Perez_T3.DB;

public class DBEntities : DbContext
{
    //public static List<Nota> Notas { get; set; }
    public virtual  DbSet <Veterinaria> Veterinarias { get; set; }

    public DBEntities() { }
    public DBEntities(DbContextOptions<DBEntities> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new VeterinariaMapping());
    }
}