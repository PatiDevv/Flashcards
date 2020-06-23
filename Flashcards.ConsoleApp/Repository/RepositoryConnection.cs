using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.ConsoleApp.Repository
{
    public class RepositoryConnection
    {
        protected readonly string ConnectionString;
        public RepositoryConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
