using System;
using System.ComponentModel.DataAnnotations.Schema;
using BinusNyata.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinusNyata.Domain.Accounts
{
  [Table("Account")]
  public partial class Account : BaseEntity<int>
  {
    [Column("Email")]
    public String Email { get; set; }

    [Column("Password")]
    public String Password { get; set; }

    public virtual AccountType Type { get; set; }
  }
  public class AccountModelBuilder : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> entity)
    { }
  }
}