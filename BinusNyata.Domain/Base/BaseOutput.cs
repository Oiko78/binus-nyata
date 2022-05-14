using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;

namespace BinusNyata.Domain.Base
{
  public class BaseOutput
  {
    public Dictionary<string, List<string>> Errors { get; set; }
    public BaseOutput()
    {
      Errors = new Dictionary<string, List<string>>();
    }
    public BaseOutput(object obj) : this()
    {
      obj
        .GetType()
        .GetProperties()
        .Select(prop => prop.Name)
        .ToList()
        .ForEach(key => Errors.Add(key, new List<string>()));
    }
  }
}