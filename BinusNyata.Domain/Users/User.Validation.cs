using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BinusNyata.Domain.Users
{
  public partial class User : IValidatableObject
  {
    // Used for advanced validation for field in model
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (false)
        yield return new ValidationResult("FieldName is required", new[] { "FieldName" });
    }
  }
}