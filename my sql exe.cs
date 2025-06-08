using MySql.Data.MySqlClient;
using System;

public class mySql
{
    public void sql() { 

    string strcon = "server=localhost;username=root;password=;database=murder;";
    MySqlConnection sqlconnaction = new MySqlConnection(strcon);
            try
            {
                sqlconnaction.Open();
                Console.WriteLine("get query");
                string query = Console.ReadLine();

    MySqlCommand sqlCommand = new MySqlCommand(query, sqlconnaction);

    var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                string firstName = reader.GetString("firstName");
                }

            }
            catch (Exception e) { Console.WriteLine($"nih: {e.Message}"); }
        finally { sqlconnaction.Close(); }
        }
    }
}