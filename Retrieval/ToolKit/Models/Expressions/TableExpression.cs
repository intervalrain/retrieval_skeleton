using System.Linq.Expressions;
using Retrieval.ToolKit.Enums;

namespace Retrieval.ToolKit.Models.Expressions
{
	internal class TableExpression : Expression
	{
		string alias;
		string name;

		internal TableExpression(Type type, string alias, string name)
			: base((ExpressionType)DbExpressionType.Table, type)
		{
			this.alias = alias;
			this.name = name;
		}

		internal string Alias => alias;

		internal string Name => name;
	}
}

