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
    [Column("Name")]
    public String Name { get; set; }

    [Column("Birth")]
    public DateTime Birth { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }
  }
  public class UserModelBuilder : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> entity)
    { }
  }
}