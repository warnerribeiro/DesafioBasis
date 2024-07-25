using Domain.Model;

namespace Core.Repository
{
    public interface IOriginPurchaseRepository
    {
        OriginPurchase? Get(int originPurchaseId);

        OriginPurchase Add(OriginPurchase originPurchase);

        OriginPurchase Update(OriginPurchase originPurchase);

        void Remove(int originPurchaseId);

        Task<IEnumerable<OriginPurchase>> GetAsync();
    }
}
