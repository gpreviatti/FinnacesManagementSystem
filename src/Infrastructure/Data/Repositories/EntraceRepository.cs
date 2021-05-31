using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EntranceRepository : BaseRepository<Entrance>, IEntranceRepository
    {
        public EntranceRepository(MyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Entrance>> FindAllAsyncWithWallet()
        {
            return await _dataset
                .Include(e => e.Wallet)
                .ToListAsync();
        }

        public async Task<IEnumerable<Entrance>> FindAllAsyncWithCategory(List<Guid> userWallets)
        {
            return await _dataset
                .Include(e => e.Category)
                .Where(e => userWallets.Contains(e.WalletId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Entrance>> FindAsyncLastFiveEntrancesWithCategories(List<Guid> userWalletsId)
        {
            return await _dataset
                .Include(e => e.Category)
                .OrderByDescending(e => e.CreatedAt)
                .Where(e => userWalletsId.Contains(e.WalletId))
                .Take(5)
                .ToListAsync();
        }

        public async Task<double> TotalEntrancesByCategory(Guid categoryId)
        {
            return await _dataset
                .Where(e => e.CategoryId.Equals(categoryId))
                .Select(e => e.Value)
                .SumAsync();
        }

        public async Task<double> TotalEntrancesByWallet(Guid walletId)
        {
            return await _dataset
                .Where(e => e.WalletId.Equals(walletId))
                .Select(e => e.Value)
                .SumAsync();
        }
    }
}
