using System;
using FakeItEasy;
using Retrieval.ToolKit;
using System.Data.Common;
using Retrieval.Test.TestUtility;

namespace Retrieval.Test.ToolKit
{
	[TestClass]
	public class ToolKitTest
	{
        //private DbConnection conn;

        //internal ToolKitTest()
        //{

        //}

		[TestMethod]
		public void WhereClauseTest()
		{
            var conn = A.Fake<DbConnectionFactory>().Create();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            InlineDb db = new InlineDb(conn);

            string Customer = "NVT";
            IQueryable<Products> products = db.Products.Where(p => p.Customer == Customer);
        }

		[TestMethod]
		public void SelectClauseTest()
		{

		}
	}

    public class Products
    {
        public string Product;
        public string Customer;
        public string Process;
        public string Generation;
        public string Technology;
    }

    public class Orders
    {
        public int OrderId;
        public string CustomerId;
        public DateTime OrderDate;
    }

    public class InlineDb
    {
        public Query<Products> Products;

        public InlineDb(DbConnection connection)
        {
            QueryProvider provider = new DbQueryProvider(connection);
            Products = new Query<Products>(provider);
        }
    }
}