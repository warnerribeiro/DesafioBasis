using Domain.Model;

namespace Core.Repository
{
    public interface IOriginPurchaseRepository
    {
        OriginPurchase? Get(int originPurchaseId);

        Task<OriginPurchase> Add(OriginPurchase originPurchase);

        Task<OriginPurchase> Update(OriginPurchase originPurchase);

        Task Remove(int originPurchaseId);

        Task<IEnumerable<OriginPurchase>> GetAsync();
    }
}
