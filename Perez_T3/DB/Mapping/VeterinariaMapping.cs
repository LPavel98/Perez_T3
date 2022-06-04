using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Perez_T3.Models;

namespace Perez_T3.DB.Mapping;

public class VeterinariaMapping : IEntityTypeConfiguration<Veterinaria>
{
    public void Configure(EntityTypeBuilder<Veterinaria> builder)
    {
        builder.ToTable("Veterinaria", "dbo");
        builder.HasKey(o => o.Id);
    }
}

