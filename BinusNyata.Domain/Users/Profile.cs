using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using BinusNyata.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinusNyata.Domain.Accounts
{
  [Table("Profile")]
  public class Profile : BaseEntity<int>
  {
    [Column("Picture")]
    public String Picture { get; set; }

    [Column("Birthday")]
    public DateTime? Birthday { get; set; }
  }

  public class ProfileModelBuilder : IEntityTypeConfiguration<Profile>
  {
    public void Configure(EntityTypeBuilder<Profile> entity)
    {
      // entity.Property(profile => profile.BirthDate).HasDefaultValue(DateTime.Now);
    }
  }
}