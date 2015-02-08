using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CSharpTest
{
    class DatabaseHandler
    {
        private string connectionStr;

        public DatabaseHandler(string path)
        {
            connectionStr = "Data Source=\"" + path + "\";Version=3;";
            
        }
        
        private string PrepareTextWithComma(string text)
        {
            return "'" + text.Replace("\"", "") + "', ";
        }
        private string PrepareText(string text)
        {
            return "'" + text.Replace("\"", "") + "'";
        }
        private string PrepareNumberWithComma(int num)
        {
            return num.ToString().Replace("\"", "") + ", ";
        }
        private string PrepareNumber(int num)
        {
            return num.ToString().Replace("\"", "");
        }

        private bool ExecuteNonQuery(string sql)
        {
            bool status = false;
            
            try
            {
                SQLiteConnection dbConnection = new SQLiteConnection(connectionStr);
                dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
                status = true;
            }
            catch(Exception)
            {
            }


            return status;
        }
        

        public List<string> GetPathsFromDB()
        {
            List<string> paths = new List<string>();
            string sql = "select full_path from Folders;";

            SQLiteConnection dbConnection = new SQLiteConnection(connectionStr);
            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                paths.Add(reader["full_path"].ToString());
            }


            dbConnection.Close();
            return paths;
        }

        public bool InsertPathIntoDB(string path)
        {
            string sql = "insert into Folders (full_path, visited_count) values (" +
                PrepareTextWithComma(path) +
                PrepareNumber(1) + ");";
            return ExecuteNonQuery(sql);
            
        }

        
    }
}
