using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class OriginPurchaseRepository : IOriginPurchaseRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<OriginPurchase> _dbSet;

        public OriginPurchaseRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.OriginPurchase;
        }

        public OriginPurchase Add(OriginPurchase originPurchase)
        {
            _dbSet.Add(originPurchase);
            _dataContext.SaveChanges();

            return originPurchase;
        }

        public OriginPurchase? Get(int originPurchaseId)
        {
            return _dbSet.Find(originPurchaseId);
        }

        public async Task<IEnumerable<OriginPurchase>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Remove(int originPurchaseId)
        {
            var originPurchase = Get(originPurchaseId);

            if (originPurchase != null)
            {
                _dbSet.Remove(originPurchase);
                _dataContext.SaveChanges();
            }
        }

        public OriginPurchase Update(OriginPurchase originPurchase)
        {
            _dbSet.Update(originPurchase);
            _dataContext.SaveChanges();

            return originPurchase;
        }
    }
}
