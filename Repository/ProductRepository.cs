using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebAppy.Data;
using WebAppy.Models;

namespace WebAppy.Repository
{
    public class ProductRepository:IProductRepository
    {
        private IDbConnection db;

        public ProductRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        Product IProductRepository.Add(Product product)
        {
            var sql = "INSERT INTO Products(Description,DisplayOrder,Price) VALUES(@Description,@DisplayOrder,@Price);" +
                "SELECT CAST (SCOPE_IDENTITY() as int);";
            var id=db.Query<int>(sql,
              product).Single();
            product.Id = id;
            return product;
        }

        void IProductRepository.Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id=@Id";
            db.Execute(sql, new { id });
        }

        Product IProductRepository.Find(int Id) 
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            return db.Query<Product>(sql, new {@Id=Id}).Single();
        }

        List<Product> IProductRepository.GetAll()
        {
            var sql = "SELECT * FROM Products";
            return db.Query<Product>(sql).ToList();
        }

        Product IProductRepository.Update(Product product)
        {
            var sql = "UPDATE Products SET Price=@Price,Description=@Description,DisplayOrder=@DisplayOrder WHERE Id=@Id";
            db.Execute(sql,product);
            return product;
        }
    }
}
