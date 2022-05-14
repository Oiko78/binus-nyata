using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BinusNyata.Domain.Base;
using BinusNyata.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinusNyata.Domain.Accounts
{
  [Table("Role")]
  public class Role : BaseEntity<int>
  {
    public const int Student = 1;
    public const int Lecturer = 2;
    public const int Staff = 3;


    [Column("Name")]
    public String Name { get; set; }
  }

  public class RoleModelBuilder : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> entity)
    {
      entity.HasData(
        new Role() { Id = 1, Name = "Student" },
        new Role() { Id = 2, Name = "Lecturer" },
        new Role() { Id = 3, Name = "Staff" }
      );
    }
  }
}