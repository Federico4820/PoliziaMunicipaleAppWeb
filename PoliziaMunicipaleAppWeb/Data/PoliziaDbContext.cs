using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleAppWeb.Models;

public class ContravvenzioniContext : DbContext
{
    public ContravvenzioniContext(DbContextOptions<ContravvenzioniContext> options) : base(options) 
    { 
    }

    public DbSet<Anagrafica> Anagrafiche { get; set; }
    public DbSet<TipoViolazione> TipiViolazione { get; set; }
    public DbSet<Verbale> Verbali { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Anagrafica>().ToTable("ANAGRAFICA");
        modelBuilder.Entity<TipoViolazione>().ToTable("TIPO_VIOLAZIONE");
        modelBuilder.Entity<Verbale>().ToTable("VERBALE");
    }
}
