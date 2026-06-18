using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericReposotiry<PortfolioItem> PortfolioItems { get; }
        IOwnerReposotiry SpecificOwners { get; }
        Task SaveAsync();
    }
}
