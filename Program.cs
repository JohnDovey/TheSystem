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

            // Setup and open database. This is created as a file in the same folder as the program if it doesn't exist
            using SqliteConnection db = new SqliteConnection("Filename=TheSystem.db");
            db.Open();

            // Create a test table of it doesn't exist
            String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, Text_Entry NVARCHAR(2048) NULL)";
            SqliteCommand createTable = new SqliteCommand(tableCommand, db);
            createTable.ExecuteReader();

            // Create menu table if it doesn't already exist
            string menuTableCommand = "CREATE TABLE IF NOT EXISTS menu (menuid INTEGER PRIMARY KEY NOT NULL, parentid INTEGER NOT NULL default(0), sortid INTEGER NOT NULL default(0), url TEXT NOT NULL default('#'), name TEXT NOT NULL default('Unknown'), desc TEXT NOT NULL default('Unknown'), seclevel INTEGER NOT NULL default(0))";
            SqliteCommand createMenuTable = new SqliteCommand(menuTableCommand, db);
            createMenuTable.ExecuteReader();

            // Insert data into the test table
            SqliteCommand insertCommand = new SqliteCommand();
            insertCommand.Connection = db;

            insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, 'Here is a new entry in the Database...');";

            insertCommand.ExecuteReader();


            // Select text from the test table
            SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from MyTable", db);
            SqliteDataReader query;

            query = selectCommand.ExecuteReader();

            while (query.Read()) // Loop through the test tanle and write out text from the first field
            {
                Console.WriteLine(query.GetString(0));// First selected field is index 0
            }

            db.Close(); // Close the database connection. This cleans up all memory etc


            // Ascii Characters

            int topleft = 218;
            int hline = 196;
            int topright = 191;
            int vline = 179;
            int bottomleft = 192;
            int bottomright = 217;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

            //draw top left corner
            Write(topleft);
            //draw top horizontal line
            for (int i = 0; i < 10; i++)
                Write(hline);
            //draw top right corner
            Write(topright);
            Console.WriteLine();
            //draw left and right vertical lines
            for (int i = 0; i < 6; i++)
            {
                Write(vline);
                for (int k = 0; k < 10; k++)
                {
                    Console.Write(" ");
                }
                WriteLine(vline);
            }
            //draw bottom left coner
            Write(bottomleft);
            //draw bottom horizontal line
            for (int i = 0; i < 10; i++)
                Write(hline);
            //draw bottom right coner
            Write(bottomright);
            Console.ReadKey();
        }
        static void Write(int charcode)
        {
            Console.Write((char)charcode);
        }
        static void WriteLine(int charcode)
        {
            Console.WriteLine((char)charcode);
        }



        // End AScii

    }
}
