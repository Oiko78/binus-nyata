using System;
using System.ComponentModel.DataAnnotations.Schema;
using BinusNyata.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinusNyata.Domain.Accounts
{
  [Table("AccountType")]
  public class AccountType : BaseEntity<int>
  {
    [Column("Name")]
    public String Name { get; set; }
  }

  public class AccountTypeModelBuilder : IEntityTypeConfiguration<AccountType>
  {
    public void Configure(EntityTypeBuilder<AccountType> entity)
    {
      entity.HasData(
        new AccountType() { Id = 1, Name = "Student" },
        new AccountType() { Id = 2, Name = "Lecturer" },
        new AccountType() { Id = 3, Name = "Staff" }
      );
    }
  }
}