using BinusNyata.Domain.Interfaces;

namespace BinusNyata.Application.Services
{
  public class BaseService
  {
    protected internal IUnitOfWork UnitOfWork { get; set; }

    public BaseService(IUnitOfWork unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }
  }
}