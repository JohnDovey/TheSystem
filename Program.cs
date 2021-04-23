using System;
using System.IO;
using Crayon;
// Import Microsoft.Data.Sqlite namespaces
using Microsoft.Data.Sqlite;
using SQLite;
//////////////////////////////////////////////////////////////
//                 The System  Ver: 0.0.3 Alpha             //
//////////////////////////////////////////////////////////////
// Gaia Awakening :                                         //
// https://www.royalroad.com/fiction/28874/gaia-awakening   //
//////////////////////////////////////////////////////////////
//  Author: John Dovey (c) 2021                             //
//  Licence: GNU Affero General Public License v3.0         //
// https://github.com/JohnDovey/TheSystem/blob/main/LICENSE //
//  Email: dovey.john@gmail.com                             //
//  https://johndovey.github.io/TheSystem/                  //
//////////////////////////////////////////////////////////////

namespace TheSystemNet
{

    class Program
    {
        public class Menu
        {
            [PrimaryKey, AutoIncrement]
            public int menuid { get; set; } // NOT NULL
            public int parentid { get; set; } // NOT NULL default(0)
            public int sortid { get; set; } // NOT NULL default(0)
            public string url { get; set; } // NOT NULL default('#')
            public string name { get; set; } // NOT NULL default('Unknown')
            public string desc { get; set; } // NOT NULL default('Unknown')
            public int seclevel { get; set; } // NOT NULL default(0))

        }
        public static async System.Threading.Tasks.Task Main()
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
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TheSystem.db");
            var db = new SQLiteAsyncConnection(databasePath);
            // Setup and open database. This is created as a file in the same folder as the program if it doesn't exist
            await db.CreateTableAsync<Menu>();

            Console.WriteLine("Table created!");

            var menu = new Menu()
            {
                parentid = 0,
                sortid = 0,
                url = "http://gatofuego.com",
                name = "El Gato de Fuego",
                desc = "El Gato de Fuego Website",
                seclevel = 1
            };

            await db.InsertAsync(menu);

            Console.WriteLine("Menu ID: {0}", menu.menuid);
            var count = await db.ExecuteScalarAsync<int>("select count(*) from Menu");

            Console.WriteLine(string.Format("Found '{0}' menu items.", count));

            SqliteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            InsertData(sqlite_conn);
            ReadData(sqlite_conn);

            // Try to create a menu
            BuildMenu(sqlite_conn);
            // End Menu

            sqlite_conn.Close(); // Close the database connection. This cleans up all memory etc

        }
        static SqliteConnection CreateConnection()
        {

            SqliteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SqliteConnection("Data Source=TheSystem.db; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
        static void InsertData(SqliteConnection conn)
        {

            // Insert data into the Menu table

            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();


            sqlite_cmd.CommandText = "INSERT INTO menu (`menuid`, `parentid`, `sortid`, `url`, `name`, `desc`, `seclevel`) VALUES (1, 0, 0, 'index.php', 'Home', 'Return to the website''s home page', 0); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO menu (`menuid`, `parentid`, `sortid`, `url`, `name`, `desc`, `seclevel`) VALUES (2, 0, 1, 'Search.php', 'Search', 'Search for what you need', 0); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO menu (`menuid`, `parentid`, `sortid`, `url`, `name`, `desc`, `seclevel`) VALUES (3, 0, 2, '#', 'About This Site', 'All you ever wanted to know about this site', 0); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO menu (`menuid`, `parentid`, `sortid`, `url`, `name`, `desc`, `seclevel`) VALUES (4, 3, 1, '#', 'FAQs', 'Frequently Asked Questions (and Frequently Questioned Answers)', 0), (5, 4, 1, 'Advertising_FAQ.php', 'FAQ for advertisers', 'The Important Stuff for advertisers.', 0), (6, 4, 2, 'User_FAQ.php', 'FAQ for users', 'Frequently Asked Questions (and Frequently Questioned Answers) for Users', 0), (7, 3, 3, 'Add_Stuff.php', 'Add Stuff', 'Add Some Stuff', 0), (8, 3, 4, 'Costs.php', 'Costs', 'What part of FREE didn''t you understand?', 0), (9, 8, 2, 'test1.php', 'Test 1', 'This is the first test', 0), (10, 8, 1, 'test2.php', 'Test 2', 'This is the second Test', 0), (11, 0, 10, '#', 'Admin', 'The Admin Area', 10),(12, 11, 1, '#', 'Reports', 'Various reports', 10), (13, 16, 2, '#', 'Edit a Record', 'Admin can edit a record''s content here', 10), (14, 12, 1, 'Admin_listall.php', 'List All ', 'List every little record that there is', 10), (15, 16, 2, 'Admin_Delete.php', 'Delete a Record', 'Be Careful. Once it''s gone, it''s gone!', 1), (16, 11, 2, '#', 'Manage Stuff', '', 10), (17, 11, 5, '#', 'Edit Menu', 'Edit the Actual menu Items', 0), (18, 17, 1, 'Admin_Edit_Menu.php', 'Edit Menu', 'Edit the Actual menu Items', 10), (19, 0, 0, 'https://sourceforge.net/projects/dynamicjqueryme/', 'SourceForge Project', 'Source Forge Project Page', 0), (20, 19, 1, 'https://sourceforge.net/projects/dynamicjqueryme/files/', 'Project Files', 'Project Files', 0), (21, 19, 2, 'https://sourceforge.net/projects/dynamicjqueryme/support', 'Support', 'Support Page', 0); ";
            sqlite_cmd.ExecuteNonQuery();

        }
        static void CreateTable(SqliteConnection conn)
        {


            // Create menu table if it doesn't already exist
            SqliteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS menu (menuid INTEGER PRIMARY KEY NOT NULL, parentid INTEGER NOT NULL default(0), sortid INTEGER NOT NULL default(0), url TEXT NOT NULL default('#'), name TEXT NOT NULL default('Unknown'), desc TEXT NOT NULL default('Unknown'), seclevel INTEGER NOT NULL default(0))";
            // string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
            sqlite_cmd = conn.CreateCommand();

            //'sqlite_cmd.CommandText = "Drop Table menu;";
            //'sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            // sqlite_cmd.CommandText = Createsql1;
            // sqlite_cmd.ExecuteNonQuery();

        }
        static void ReadData(SqliteConnection conn)
        {

            // Select text from the Menu table

            // while (query.Read()) // Loop through the menu data and write out text from the fields
            // {
            //     Console.WriteLine(query.GetString(0) + " = " + query.GetString(1) + " = " + query.GetString(2) + " = " + query.GetString(3) + " = " + query.GetString(4) + " = " + query.GetString(5));// First selected field is index 0


            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM menu";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(sqlite_datareader.GetString(0) + " = " + sqlite_datareader.GetString(1) + " = " + sqlite_datareader.GetString(2) + " = " + sqlite_datareader.GetString(3) + " = " + sqlite_datareader.GetString(4) + " = " + sqlite_datareader.GetString(5));// First selected field is index 0

                // Console.WriteLine(myreader);
            }

        }

        static void BuildMenu(SqliteConnection conn)
        {
            int SecLevel = 10;
            if (SecLevel < 10)
            {
                Console.WriteLine("Security Level: " + SecLevel);
            }
            else
            {
                SecLevel = 10;
            }

            // Read menu data
            // @Param $mylevel = Menu level
            // @Param $myseclevel = Security Level 0=lowest (guest), 10=Highest (admin)
            int TmpMySecLevel = 0;
            int MySecLevel = 0;
            TmpMySecLevel = MySecLevel + 1;
            int ParentID = 0;
            int RowCount = 0;
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "Select * from menu where parentid=" + ParentID + " and seclevel < " + TmpMySecLevel + " order by sortid ASC ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                //RowCount = sqlite_datareader.HasRows();
                const int myUrl = 3;
                const int myName = 4;
                const int myDesc = 5;

                Console.WriteLine(sqlite_datareader.GetString(myUrl) + " title=" + sqlite_datareader.GetString(myDesc) + " Name : " + sqlite_datareader.GetString(myName));
                // $tmpparentid = $row["menuid"];
                //     getmenu($tmpparentid, $myseclevel);
            }

            // End Read Menu data
        } // End BuildMenu
    } // End Program
} // End NameSpace TheSystemNet
