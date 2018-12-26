using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallEshop.Web.Models
{
    public static class LinqExpressions
    {
        public static Expression<Func<Item, bool>> PrepareListItemsFilter(int? brandId = null, int? categoryId = null)
        {
            return x =>
                brandId != null ? x.BrandId == brandId : true
                && categoryId != null ? x.CategoryId == categoryId : true;
            
        }

        public static Expression<Func<Item, bool>> GetAnItemById(int itemId)
        {
            return x => x.ItemId == itemId;

        }
    }
}
