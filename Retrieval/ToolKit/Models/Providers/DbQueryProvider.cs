using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using Retrieval.ToolKit.Utils;
using Retrieval.ToolKit.Containers;

namespace Retrieval.ToolKit.Models.Providers
{
	public class DbQueryProvider : QueryProvider
	{
		private readonly DbConnection connection; 

		public DbQueryProvider(DbConnection connection)
		{
			this.connection = connection;
		}

        public override string GetQueryText(Expression expression)
        {
			return Translate(expression).CommandText;
        }

        public override object Execute(Expression expression)
        {
            TranslateResult result = Translate(expression);
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = result.CommandText;
            DbDataReader reader = cmd.ExecuteReader();

            Type elementType = TypeManager.GetElementType(expression.Type);
            if (result.projector != null)
            {
                Delegate projector = result.projector.Compile();
                return Activator.CreateInstance(
                    typeof(ProjectionReader<>).MakeGenericType(elementType),
                    BindingFlags.Instance | BindingFlags.NonPublic, null,
                    new object[] { reader, projector },
                    null);
            }

            return Activator.CreateInstance(
                typeof(ObjectReader<>).MakeGenericType(elementType),
                BindingFlags.Instance | BindingFlags.NonPublic, null,
                new object[] { reader },
                null);
        }

        private TranslateResult Translate(Expression expression)
        {
            expression = Evaluator.PartialEval(expression);
            return new QueryTranslator().Translate(expression);
        }
    }
}

