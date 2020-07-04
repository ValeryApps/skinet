using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.specification
{
   public class Basespecification<T> : ISpecification<T>
   {
      public Basespecification()
      {
      }

      public Basespecification(Expression<Func<T, bool>> criteria)
      {
         Criteria = criteria;
      }

      public Expression<Func<T, bool>> Criteria { get; }

      public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

      protected void AddInclude(Expression<Func<T, object>> includeExpression)
      {
         Includes.Add(includeExpression);
      }
   }
}