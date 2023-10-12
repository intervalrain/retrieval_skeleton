
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Retrieval.ToolKit.Enums;
using Retrieval.ToolKit.Models.Expressions;
using Retrieval.ToolKit.Models.Declarations;

namespace Retrieval.ToolKit.Models.Visitors
{
    internal class DbExpressionVisitor : ExpressionVisitor
    {
        public override Expression Visit(Expression exp)
        {
            if (exp == null)
                return exp;

            switch ((DbExpressionType)exp.NodeType)
            {
                case DbExpressionType.Table:
                    return VisitTable((TableExpression)exp);
                case DbExpressionType.Column:
                    return VisitColumn((ColumnExpression)exp);
                case DbExpressionType.Select:
                    return VisitSelect((SelectExpression)exp);
                case DbExpressionType.Projection:
                    return VisitProjection((ProjectionExpression)exp);
                default:
                    return base.Visit(exp);
            }
        }

        protected virtual Expression VisitTable(TableExpression table)
        {
            return table;
        }

        protected virtual Expression VisitColumn(ColumnExpression column)
        {
            return column;
        }

        protected virtual Expression VisitSelect(SelectExpression select)
        {
            Expression from = VisitSource(select.From);
            Expression where = Visit(select.Where);
            ReadOnlyCollection<ColumnDeclaration> columns = this.VisitColumnDeclaration(select.Columns);

            if (from != select.From || where != select.Where || columns != select.Columns)
            {
                return new SelectExpression(select.Type, select.Alias, columns, from, where);
            }

            return select;
        }

        protected virtual Expression VisitSource(Expression source)
        {
            return this.Visit(source);
        }

        protected virtual Expression VisitProjection(ProjectionExpression projection)
        {
            SelectExpression source = (SelectExpression)this.Visit(projection.Source);
            Expression projector = this.Visit(projection.Projector);

            if (source != projection.Source || projector != projection.Projector)
            {
                return new ProjectionExpression(source, projector);
            }
            return projection;
        }

        protected ReadOnlyCollection<ColumnDeclaration> VisitColumnDeclarations(ReadOnlyCollection<ColumnDeclaration> columns)
        {
            List<ColumnDeclaration> alternate = null;
            for (int i = 0; i < columns.Count; i++)
            {
                ColumnDeclaration column = columns[i]; 
                Expression e = this.Visit(column.Expression);
                if (alternate == null && e != column.Expression)
                {
                    alternate = columns.Take(i).ToList();
                }

                if (alternate != null)
                {
                    alternate.Add(new ColumnDeclaration(column.Name, e));
                }
            }

            return alternate?.AsReadOnly() ?? columns;
        }
    }
}

