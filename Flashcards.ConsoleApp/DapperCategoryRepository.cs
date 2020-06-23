using Dapper;
using Flashcards.ConsoleApp.Repository;
using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flashcards.ConsoleApp
{
    public class DapperCategoryRepository : RepositoryConnection, IDapperCategoryRepository
    {
        public DapperCategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Category> GetCategories(Guid userId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Category>($"SELECT * FROM Categories WHERE UserId = '{userId}';");
            }
        }

        public Category GetCategory(string name, Guid userId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirst<Category>($"SELECT * FROM Categories WHERE Name = '{name}' AND UserId = '{userId}';");
            }
        }

        public int DeleteCategory(string name, Guid userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"DELETE FROM dbo.[Categories] WHERE UserId = '{userId}' AND Name = '{name}'");
            }
        }
    }
}
