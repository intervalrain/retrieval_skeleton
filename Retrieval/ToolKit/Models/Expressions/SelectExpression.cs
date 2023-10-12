using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Retrieval.ToolKit.Enums;
using Retrieval.ToolKit.Models.Declarations;

namespace Retrieval.ToolKit.Models.Expressions
{
	internal class SelectExpression : Expression
	{
		string alias;
		ReadOnlyCollection<ColumnDeclaration> columns;
		Expression from;
		Expression where;

		internal SelectExpression(Type type, string alias, IEnumerable<ColumnDeclaration> columns, Expression from, Expression where)
			: base((ExpressionType)DbExpressionType.Select, type)
		{
			this.alias = alias;
			this.columns = columns as ReadOnlyCollection<ColumnDeclaration>;

			if (this.columns == null)
			{
				this.columns = new List<ColumnDeclaration>(columns).AsReadOnly();
			}
			this.from = from;
			this.where = where;
		}

		internal string Alias => alias;
		internal ReadOnlyCollection<ColumnDeclaration> Columns => columns;
		internal Expression From => from;
		internal Expression Where => where; 
		
	}
}

