using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericReposotiry<Owner> Owners { get; }
        IGenericReposotiry<PortfolioItem> PortfolioItems { get; }
        public IOwnerReposotiry SpecificOwners { get; }
        Task SaveAsync();
    }
}
