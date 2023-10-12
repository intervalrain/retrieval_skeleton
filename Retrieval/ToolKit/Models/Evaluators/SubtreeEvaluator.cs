using System;
using System.Linq.Expressions;
namespace Retrieval.ToolKit.Models.Evaluators
{
	internal class SubtreeEvaluator : ExpressionVisitor
	{
		HashSet<Expression> candidates;

		internal SubtreeEvaluator(HashSet<Expression> candidates)
		{
			this.candidates = candidates;
		}

		internal Expression Eval(Expression expression)
		{
			return Visit(expression);
		}

        public override Expression Visit(Expression exp)
        {
			if (exp == null)
				return null;
			if (candidates.Contains(exp))
				return this.Evaluate(exp);
			return Visit(exp);
        }

		private Expression Evaluate(Expression e)
		{
			if (e.NodeType == ExpressionType.Constant)
				return e;
			LambdaExpression lambda = Expression.Lambda(e);
			Delegate fn = lambda.Compile();
			return Expression.Constant(fn.DynamicInvoke(null), e.Type);
		}
    }
}

