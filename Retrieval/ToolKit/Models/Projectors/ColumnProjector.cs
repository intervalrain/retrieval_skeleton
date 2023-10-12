using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Retrieval.ToolKit.Containers;
using Retrieval.ToolKit.Abstractions;

namespace Retrieval.ToolKit.Models.Projectors
{
	internal class ColumnProjector : ExpressionVisitor
	{
		StringBuilder sb;
		int iColumn;
		ParameterExpression row;
		static MethodInfo miGetValue;

		internal ColumnProjector()
		{
			if (miGetValue == null)
				miGetValue = typeof(ProjectionRow).GetMethod("GetValue");
		}

		internal ColumnProjection ProjectColumns(Expression expression, ParameterExpression row)
		{
			sb = new StringBuilder();
			this.row = row;
			Expression selector = this.Visit(expression);
			return new ColumnProjection
			{
				Columns = sb.ToString(),
				Selector = selector
			};
		}

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter)
			{
				if (sb.Length > 0)
				{
					sb.Append(", ");
				}
				sb.Append(m.Member.Name);

				return Expression.Convert(Expression.Call(row, miGetValue, Expression.Constant(iColumn++)), m.Type);
			}
			return base.VisitMemberAccess(m);
        }
    }
}

