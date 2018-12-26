using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmallEshop.Core.Models;

namespace SmallEshop.Core.Repositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Item GetItem(int itemId);
        int GetCountAllItemsWhere(Expression<Func<Item, bool>> expression);
        int GetCountAllItems();
        List<Item> GetAllItemsWhere(Expression<Func<Item, bool>> expression, int? skip = null, int? take = null);
        Task<List<Item>> GetAllItemsWhereAsync(Expression<Func<Item, bool>> expression, int? skip = null, int? take = null);
        List<Item> GetAllItems(int? skip = null, int? take = null);
        Task<List<Item>> GetAllItemsAsync(int? skip = null, int? take = null);
    }
}