using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinusNyata.Domain.Users
{
  [Table("User")]
  public partial class User : BaseEntity<int>
  {
    [Column("FirstName")]
    public String FirstName { get; set; }

    [Column("LastName")]
    public String LastName { get; set; }

    public virtual Account Account { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
    public virtual Profile Profile { get; set; }
  }
  public class UserModelBuilder : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> entity)
    { }
  }
}