using System;
using System.Data.Common;
namespace Retrieval.Infrastructure.Abstractions
{
	public interface DbConnectionFactory
	{
		public DbConnection Create();
	}
}

