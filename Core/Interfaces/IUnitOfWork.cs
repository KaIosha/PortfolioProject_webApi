using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericReposotiry<Owner> Owners { get; }
        IGenericReposotiry<PortfolioItem> PortfolioItems { get; }  
        Task SaveAsync();
    }
}
