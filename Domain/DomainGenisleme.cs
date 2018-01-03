using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Domain
{
    public static class DomainGenisleme
    {
        public static IQueryable<TDomain> ListeyiSirala<TDomain>(this IQueryable<TDomain> list, bool orderAscending,
               string propName)
        {
            /*
             Kodun adresi burada 
             http://stackoverflow.com/questions/41244/dynamic-linq-orderby-on-ienumerablet
            */

            Type tip = typeof(TDomain);
            ParameterExpression arg = Expression.Parameter(tip, "x");
            Expression expr = arg;

            PropertyInfo pi = propName.Contains(".")
                ? tip.GetProperty(propName.Split('.')[0])
                : tip.GetProperty(propName);
            expr = Expression.Property(expr, pi);
            tip = pi.PropertyType;

            if (propName.Contains("."))
            {
                pi = tip.GetProperty(propName.Split('.')[1]);
                expr = Expression.Property(expr, pi);
                tip = pi.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(TDomain), tip);

            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            string methodName = orderAscending ? "OrderBy" : "OrderByDescending";


            object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                          && method.IsGenericMethodDefinition
                          && method.GetGenericArguments().Length == 2
                          && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(TDomain), tip)
                .Invoke(null, new object[] { list, lambda });
            return (IOrderedQueryable<TDomain>)result;
        }
    }
}