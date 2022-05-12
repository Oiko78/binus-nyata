using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinusNyata.Domain.Base
{
  public abstract class BaseEntity { }
  public abstract class BaseEntity<TKey> : BaseEntity
  {
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }
  }
}