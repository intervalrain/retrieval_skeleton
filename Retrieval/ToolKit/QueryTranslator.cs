using System;
using System.Text;
using System.Linq.Expressions;

namespace Retrieval.ToolKit
{
	internal class QueryTranslator : ExpressionVisitor
	{
		StringBuilder sb;

		internal QueryTranslator()
		{
		}

		internal string Translate(Expression expression)
		{
			sb = new StringBuilder();
			Visit(expression);
			return sb.ToString();
		}

		private static Expression StripQuotes(Expression e)
		{
			while (e.NodeType == ExpressionType.Quote)
			{
				e = ((UnaryExpression)e).Operand;
			}
			return e;
		}

		protected override Expression VisitMethodCall(MethodCallExpression m)
		{
			if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
			{
				sb.Append("Select * From (");
				Visit(m.Arguments[0]);
				sb.Append(") As T Where ");
				LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
				Visit(lambda.Body);
				return m;
			}
			throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
		}

        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
			{
				case ExpressionType.Not:
					sb.Append(" Not ");
					Visit(u.Operand);
					break;
				default:
					throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
			}
			return u;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
			sb.Append("(");
			Visit(b.Left);
			switch (b.NodeType)
			{
				case ExpressionType.Add:
					sb.Append(" And ");
					break;
				case ExpressionType.Or:
					sb.Append(" Or ");
					break;
				case ExpressionType.Equal:
					sb.Append(" = ");
					break;
				case ExpressionType.NotEqual:
					sb.Append(" <> ");
					break;
				case ExpressionType.LessThan:
					sb.Append(" < ");
					break;
				case ExpressionType.LessThanOrEqual:
					sb.Append(" <= ");
					break;
				case ExpressionType.GreaterThan:
					sb.Append(" > ");
					break;
				case ExpressionType.GreaterThanOrEqual:
					sb.Append(" >= ");
					break;
				default:
					throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
			}
			Visit(b.Right);
			sb.Append(")");
			return b;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
			IQueryable? q = c.Value as IQueryable;

			if (q != null)
			{
				sb.Append("Select * From ");
				sb.Append(q.ElementType.Name);
			}
			else if (c.Value == null)
			{
				sb.Append("Null");
			}
			else
			{
				switch (Type.GetTypeCode(c.Value.GetType()))
				{
					case TypeCode.Boolean:
						sb.Append(((bool)c.Value) ? 1 : 0);
						break;
					case TypeCode.String:
						sb.Append("'");
						sb.Append(c.Value);
						sb.Append("'");
						break;
					case TypeCode.Object:
						throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
					default:
						sb.Append(c.Value);
						break;
				}
			}
			return c;
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter)
			{
				sb.Append(m.Member.Name);
				return m;
			}

			throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
        }
    }
}

