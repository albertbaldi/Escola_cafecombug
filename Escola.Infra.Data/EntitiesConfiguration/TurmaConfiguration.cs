using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.CursoId).IsRequired();
        builder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
        builder.Property(t => t.Descricao).IsRequired().HasMaxLength(150);

        builder.HasOne(t => t.Curso)
               .WithMany(c => c.Turmas)
               .HasForeignKey(t => t.CursoId)
               .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(t => t.Matriculas)
               .WithOne(m => m.Turma)
               .HasForeignKey(m => m.TurmaId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
