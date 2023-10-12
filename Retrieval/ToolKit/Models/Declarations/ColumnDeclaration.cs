using System;
using System.Linq.Expressions;

namespace Retrieval.ToolKit.Models.Declarations
{
	internal class ColumnDeclaration
	{
		string name;
		Expression expression;

		internal ColumnDeclaration(string name, Expression expression)
		{
			this.name = name;
			this.expression = expression;
		}

		internal string Name => name;
		internal Expression Expression => expression;
	}
}

