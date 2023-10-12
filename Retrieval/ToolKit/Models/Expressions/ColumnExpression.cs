using System.Linq.Expressions;
using Retrieval.ToolKit.Enums;

namespace Retrieval.ToolKit.Models.Expressions
{
	internal class ColumnExpression : Expression
	{
		string alias;
		string name;
		int ordinal;

		internal ColumnExpression(Type type, string alias, string name, int ordinal)
			: base((ExpressionType)DbExpressionType.Column, type)
		{
			this.alias = alias;
			this.name = name;
			this.ordinal = ordinal;
		}

		internal string Alias => alias;
		internal string Name => name;
		internal int Ordinal => ordinal;
	}
}

