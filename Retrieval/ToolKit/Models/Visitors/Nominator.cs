using System;
using System.Linq.Expressions;
namespace Retrieval.ToolKit.Models.Visitors
{
	internal class Nominator : ExpressionVisitor
	{
		Func<Expression, bool> fnCanBeEvaluated;
		HashSet<Expression> candidates;
		bool cannotBeEvaluated;

		internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
		{
			this.fnCanBeEvaluated = fnCanBeEvaluated;
		}

		internal HashSet<Expression> Nominate(Expression expression)
		{
			candidates = new HashSet<Expression>();
			Visit(expression);
			return candidates;
		}

        protected override Expression Visit(Expression exp)
        {
            if (exp != null)
			{
				bool saveCannotBeEvaluated = cannotBeEvaluated;
				cannotBeEvaluated = false;
				base.Visit(exp);
				if (!cannotBeEvaluated)
				{
					if (fnCanBeEvaluated(exp))
					{
						candidates.Add(exp);
					}
					else
					{
						cannotBeEvaluated = true;
					}
				}
				cannotBeEvaluated |= saveCannotBeEvaluated;
			}
			return exp;
        }
    }
}

