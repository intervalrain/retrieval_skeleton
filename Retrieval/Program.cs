using System.Data.Common;
using Retrieval.ToolKit;
using Microsoft.Data.SqlClient;
using FakeItEasy;

namespace Retrieval
{
    public class Program
    {
        public interface IDbConnectionFactory
        {
            DbConnection Create();
        }

        public static void Main(string[] args)
        {
            var _factory = A.Fake<IDbConnectionFactory>();
            using (var conn = _factory.Create())
            {
                conn.Open();
                InlineDb db = new InlineDb(conn);

                string Customer = "NVT";
                IQueryable<Products> products = db.Products.Where(p => p.Customer == Customer);
            }
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