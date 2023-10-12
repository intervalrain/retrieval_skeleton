using System;
using System.Data.Common;

namespace Retrieval.Test.TestUtility
{
	public interface DbConnectionFactory
	{
		public DbConnection Create();		
	}
}

