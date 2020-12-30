using System;
using Crayon;
// Import Microsoft.Data.Sqlite namespaces
using Microsoft.Data.Sqlite;

namespace TheSystemNet
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();
            Console.WriteLine(" ... Startup Sequence ...");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to The System");
            Console.ResetColor();


            Console.WriteLine(Output.Red("System Initialisation in progress ..."));
            Console.ResetColor();

            Console.WriteLine(Output.BrightBlue("Accessing Database ..."));


            using SqliteConnection db = new SqliteConnection("Filename=TheSystem.db");
            db.Open();

            String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, Text_Entry NVARCHAR(2048) NULL)";
            SqliteCommand createTable = new SqliteCommand(tableCommand, db);
            createTable.ExecuteReader();

            SqliteCommand insertCommand = new SqliteCommand();
            insertCommand.Connection = db;

            insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, 'Here is a new entry in the Database...');";

            insertCommand.ExecuteReader();

            SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from MyTable", db);
            SqliteDataReader query;

            query = selectCommand.ExecuteReader();

            while (query.Read())
            {


                Console.WriteLine(query.GetString(0));
            }

            db.Close();
        }
    }
}
