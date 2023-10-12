using System;
using System.Linq.Expressions;
using Retrieval.ToolKit.Utils;


namespace Retrieval.ToolKit.Models.Providers
{
	public abstract class QueryProvider : IQueryProvider
	{
		public QueryProvider()
		{
		}

        IQueryable<S> IQueryProvider.CreateQuery<S>(Expression expression)
		{
			return new Query<S>(this, expression);
		}
		IQueryable IQueryProvider.CreateQuery(Expression expression)
		{
			Type elementType = TypeManager.GetElementType(expression.Type);

			try
			{
				return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
			}
			catch (Exception tie)
			{
				throw tie.InnerException;
			}
		}

		S IQueryProvider.Execute<S>(Expression expression)
		{
			return (S)this.Execute(expression);
		}

		object IQueryProvider.Execute(Expression expression)
		{
			return this.Execute(expression);
		}

		public abstract string GetQueryText(Expression expression);

		public abstract object Execute(Expression expression);
    }
}

