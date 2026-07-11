using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC_Database_Backup.Entities;

namespace SGC_Database_Backup.Data.Seeds;

public class UserSeedConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasData(
    // Provincia 010000 - DISTRITO NACIONAL
    new User
    {
        Id = 1,
        Username = "admin",
        Email = "admin@example.com",
        PasswordHash = "HASH_DE_LA_CONTRASEÑA_AQUÍ", // Reemplaza con un hash real si usas una librería de seguridad
        IsActive = true,
        CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0),
    },
    new User
    {
        Id = 2,
        Username = "usuario1",
        Email = "usuario1@example.com",
        PasswordHash = "HASH_DE_LA_CONTRASEÑA_AQUÍ",
        IsActive = true,
        CreatedAt = new DateTime(2026, 7, 11, 0, 0, 0),
    });
    }
}
