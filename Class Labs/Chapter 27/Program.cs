using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ch27Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Database databaseObject = new Database();

            /*
            // * INSERT INTO DATABASE
            // 
            */

            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                    [Mytable] (
                                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Name] NVARCHAR(2048) NULL,
                                    [Gender] NVARCHAR(2048) NULL)";

            System.Data.SQLite.SQLiteConnection.CreateFile("sample.db3");
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=sample.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = createQuery;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Mytable (Name,Gender) values('Kenneth', 'Male')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Mytable (Name,Gender) values('Monique', 'Female')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Mytable (Name,Gender) values('Jimmy-Crack-Corn', 'Bird')";
                    cmd.ExecuteNonQuery();


                    /* 
                    // * SELECT FROM DATABASE
                    //
                    */

                    cmd.CommandText = "SELECT * from Mytable";
                    using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Name"] + " : " + reader["Gender"]);
                        }
                        conn.Close();
                    }
                }

                /*
                   * DELETE FROM DATABASE
                   * 
                   */
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    SQLiteTransaction trans;
                    
                    conn.ConnectionString = @"data source = C:\Users\Kenneth D Clark\Documents\Visual Studio 2017\Projects\Ch27Lab\Ch27Lab\bin\Debug\sample.db3";
                    conn.Open();

                    trans = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Mytable WHERE name = @Name";
                    cmd.Parameters.AddWithValue("@Name", "Jimmy-Crack-Corn");
                    cmd.ExecuteNonQuery();
                    trans.Commit();

                }

            }
            Console.ReadLine();

           
        }
    }
}


/* The following code shows how to create a SQLite database.
              The code was retrieved from a video that was watched on the following
              link: https://www.youtube.com/watch?v=APVit-pynwQ
            

            

 * 
 *  string query = "INSERT INTO albums('title', 'artist') VALUES (@title, @artist)";
        SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
        databaseObject.OpenConnection(); //open connection
        myCommand.Parameters.AddWithValue("@title", "Trapsoul");
        myCommand.Parameters.AddWithValue("@artist", "Bryson Tiller");
        var result = myCommand.ExecuteNonQuery();
        databaseObject.CloseCOnnection(); //close connection

        Console.WriteLine("Rows Added : (0)", result);
        Console.ReadKey();
 */
