using System.Linq;
using Firefly.Domain;
using Microsoft.EntityFrameworkCore;
namespace Firefly.Data {

  public class CharacterContext : DbContext {
    public DbSet<Character> Characters { get; set; }
   
    public CharacterContext (DbContextOptions<CharacterContext> options) : base (options) { }
    public CharacterContext () { }

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Entity<Character> ()
        .HasOne (typeof (Entrance), "Entrance")
        .WithOne ().HasForeignKey (typeof (Entrance), "CharacterId");
      modelBuilder.Entity<Character> ()
        .HasMany (typeof (Quote), "Quotes")
        .WithOne ().HasForeignKey ("CharacterId");

      var navigation = modelBuilder.Entity<Character> ()
        .Metadata.FindNavigation (nameof (Character.Quotes));
      navigation.SetPropertyAccessMode (PropertyAccessMode.Field);

      foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
        modelBuilder.Entity (entityType.Name).Property<System.DateTime> ("LastModified");
        modelBuilder.Entity (entityType.Name).Ignore ("IsDirty");
      }
    }

    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ()
          .Where (e => e.State == EntityState.Added ||
            e.State == EntityState.Modified)) {
        entry.Property ("LastModified").CurrentValue = System.DateTime.Now;
      }
      return base.SaveChanges ();
    }
  }
}