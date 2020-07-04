using System.Collections.Generic;
using System;
using System.Linq.Expressions;
namespace Core.specification
{
   public interface ISpecification<T>
   {
      Expression<Func<T, bool>> Criteria { get; }
      List<Expression<Func<T, object>>> Includes { get; }
   }
}