using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> UseOrdering<T, TResultSelector>(this IQueryable<T> query,
            Pagination pagination,
                 Expression<Func<T, TResultSelector>> field)
        {
            if (string.IsNullOrWhiteSpace(pagination.SortBy)
                || string.IsNullOrEmpty(pagination.SortBy))
                return query;

            return pagination.IsSortAscending ?
                query.OrderBy(field) :
                query.OrderByDescending(field);
        }

        public static IQueryable<T> UsePagination<T>(this IQueryable<T> query,
            Pagination pagination)
        {
            if (pagination.Page <= 0)
                pagination.Page = 1;

            if (pagination.PageSize <= 0)
                pagination.PageSize = 10;

            return query.Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }
    }

}