using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RLPortalBackend.Entities;

namespace RLPortalBackend.Models;

public class AplicationDBContext : IdentityDbContext<User>
{
    public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}


public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(o => o.FirstName).HasMaxLength(255);
        builder.Property(o => o.LastName).HasMaxLength(255);

    }
}