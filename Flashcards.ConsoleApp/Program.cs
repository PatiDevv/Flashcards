using Flashcards.Infrastructure.Repositories;
using System;
using System.Data;
using System.Linq;

namespace Flashcards.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var items = new List<Flashcard>();
            //using (var conn = new SqlConnection("Data Source=DESKTOP-4ULT7VC\\SQLEXPRESS;Initial Catalog=Flashcards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            //{

            //    items = conn.Query<Flashcard>("select * from flashcards").ToList();

            //}

            //var _flashcardRepo = new FlashcardRepository();

            //await _flashcardRepo.AddAsync(items.First());

            const string ConnectionString = "Data Source=DESKTOP-4ULT7VC\\SQLEXPRESS;Initial Catalog=Flashcards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";


            //var insertSql = "INSERT INTO dbo.[Users] (Id, Name, Email, Password, CreateAt, Points) Values (NewId(), 'user5', 'user5@mail.com', 'wauser5iii1', getdate(), 0)" +
            //                "INSERT INTO dbo.[Users] (Id, Name, Email, Password, CreateAt, Points) Values (NewId(), 'user6', 'user6@mail.com', 'user6dsdsds', getdate(), 0)" +
            //                "INSERT INTO dbo.[Users] (Id, Name, Email, Password, CreateAt, Points) Values (NewId(), 'user7', 'user7@mail.com', 'waldiuser7iiii1', getdate(), 100)";

            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    var affectedRow = connection.Execute(insertSql);
            //    Console.WriteLine("Affected Row: " + affectedRow);
            //}


            //var querySql = $@"SELECT Id, Name, Email, Password, CreateAt, Points FROM dbo.[Users]";

            //using (var conn = new SqlConnection(ConnectionString))
            //{
            //    var users = conn.Query<User>(querySql);
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine($"{user.Id} {user.Name} {user.Email} {user.Password} {user.CreateAt} {user.Points}");
            //    }
            //}

       
            //var updateSql = "UPDATE dbo.[Users] SET Name='Karmelowy' WHERE Id = '71B9A04F-7807-423D-9CA4-EF01BA787976'";

            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    var affectedRow = connection.Execute(updateSql);
            //    Console.WriteLine("Affected Row: " + affectedRow);

            //    var users = connection.Query<User>(querySql);
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine($"{user.Id} {user.Name} {user.Email} {user.Password} {user.CreateAt} {user.Points}");
            //    }
            //}

            //string deleteSql = "DELETE FROM dbo.[Users] WHERE Id = '71B9A04F-7807-423D-9CA4-EF01BA787976'";
            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    var affectedRow = connection.Execute(deleteSql);
            //    Console.WriteLine("Affected Row: " + affectedRow);
            //    var users = connection.Query<User>(querySql);
            //    Console.WriteLine("Liczba uzytkowników: " + users.Count());
            //}


            var _userService = new DapperUserRepository(ConnectionString);

            var users = _userService.GetUsers();


            //foreach (var user in users)
            //{
            //    Console.WriteLine($"{user.Id} {user.Name} {user.Email} {user.Password} {user.CreateAt} {user.Points}");
            //}

            var user = _userService.GetUser("user@mail.com");

            user.SetName("Patrycja");


            _userService.UpdateUser(user);

        }
    }
}
