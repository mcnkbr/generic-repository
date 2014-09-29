using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TM> OrderBy<TM>(this IQueryable<TM> source, string orderByProperty,
                      bool asc) where TM : class
        {
            var command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TM);
            PropertyInfo property;
            if (!orderByProperty.Contains('.'))
                property = type.GetProperties().FirstOrDefault(w => w.Name == orderByProperty);
            else
            {
                var arrg = orderByProperty.Split('.');
                property = type.GetProperty(arrg[0]).GetType().GetProperty(arrg[1]);
            }
            var parameter = Expression.Parameter(type, "p");
            if (property == null) return null;
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof (Queryable), command, new[] {type, property.PropertyType},
                source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TM>(resultExpression);
        }
    }
}