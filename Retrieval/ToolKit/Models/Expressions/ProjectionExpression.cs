using System;
using System.Linq.Expressions;
using Retrieval.ToolKit.Enums;

namespace Retrieval.ToolKit.Models.Expressions
{
	internal class ProjectionExpression :Expression
	{
		SelectExpression source;
		Expression projector;

		internal ProjectionExpression(SelectExpression source, Expression projector)
			: base((ExpressionType)DbExpressionType.Projection, projector.Type)
		{
			this.source = source;
			this.projector = projector; 
		}

		internal SelectExpression Source => source;
		internal Expression Projector => projector; 
	}
}

