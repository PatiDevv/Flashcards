using Dapper;
using Flashcards.ConsoleApp.Repository;
using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;

namespace Flashcards.ConsoleApp
{
    public class DapperUserRepository : RepositoryConnection, IDapperUserRepository
    {
        public DapperUserRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<User> GetUsers()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<User>("SELECT * FROM [Flashcards].[dbo].[Users]");
            }
        }

        public User GetUser(string email)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirst<User>($"SELECT * FROM Users WHERE Email = '{email}';");
            }
        }

        public int AddUser(string name, string email, string password)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string insertQuery = $"INSERT INTO dbo.[Users] (Id, Name, Email, Points, Password, CreateAt) VALUES (NEWID(), '{name}', '{email}', 0, '{password}', GETDATE())";
                return connection.Execute(insertQuery);
            }
        }

        public int DeleteUser(string email)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"DELETE FROM dbo.[Users] WHERE Email = '{email}'");
            }
        }


        public int EditUserName(string email)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"UPDATE dbo.[Users] SET Name = 'Karmelowy' WHERE Email = '{email}'");
            }
        }

        public int UpdateUser(Guid id, string name, string email, string password, int points)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"UPDATE [dbo].[Users] SET ([Name] ,[Email] ,[Password] ,[CreateAt] ,[Points]) VALUES ('{name}', '{email}','{password}','{points}') WHERE [Id] = '{id}'");
            }
        }

        public int UpdateUser(User user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"UPDATE [dbo].[Users] SET [Name] = '{user.Name}' ,[Email] = '{user.Email}' ,[Password] = '{user.Password}' ,[Points] = '{user.Points}' WHERE [Id] = '{user.Id}'");
            }
        }
    }
}
