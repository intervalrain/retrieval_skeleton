using System;
using System.Data.Common;
using Retrieval.Infrastructure.DAL.Form.Models;
using Retrieval.Infrastructure.DAL.Form.Models.Abstractions;
using Retrieval.Infrastructure.DAL.Form.Repositories.Abstractions;

namespace Retrieval.Infrastructure.DAL.Form.Repositories
{
	public class InlineRepository
    {
		private readonly DbConnection _connection;

		public InlineRepository(DbConnection connection)
		{
			_connection = connection;
		}


    }
}

