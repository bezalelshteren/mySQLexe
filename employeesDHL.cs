using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mySQLexe
{
    internal class employeesDHL
    {
        //crub operation


        public string strcon = "server=localhost;username=root;password=;database=murder;";

        //private MySqlConnection _conn;

        public MySqlConnection connactionToDatabase(string strcon)
        {
            MySqlConnection sqlcon = new MySqlConnection(strcon);
            sqlcon.Open();
            return sqlcon;
        }

        public MySqlCommand commonToSql(string query, MySqlConnection sqlcon)
        {
            MySqlCommand common = new MySqlCommand(query, sqlcon);
            return common;
        }

        public void MySqlClose(MySqlConnection sqlcon)
        {
            sqlcon.Close();
        }

        public List<agants> getAgant()
        {
            List<agants> allAgants = new List<agants>();
            MySqlConnection sqlcon = connactionToDatabase(strcon);
            try
            {

                string query = "SELECT * FROM agants;";
                MySqlCommand common = commonToSql(query, sqlcon);
                var reader = common.ExecuteReader();
                while (reader.Read())
                {
                    agants aga = new agants
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        CodeName = reader.GetString(reader.GetOrdinal("CodeName")),
                        RealName = reader.GetString(reader.GetOrdinal("RealName")),
                        Location = reader.GetString(reader.GetOrdinal("Location")),
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        MissionsCompleted = reader.GetInt32(reader.GetOrdinal("MissionsCompleted"))
                    };
                    allAgants.Add(aga);
                }
            }
            catch (Exception e) { }
            
            

            MySqlClose(sqlcon);

            return allAgants;
        }

        public void addAgant(agants agants)
        {
            MySqlConnection sqlcon = connactionToDatabase(strcon);
            try
            {
                string query = "INSERT INTO agants(Id,CodeName,RealName,Location,Status,MissionsCompleted) VALUE(@Id,@CodeName,@RealName,@Location,@Status,@MissionsCompleted ) ";
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue("@Id",agants.Id);
                common.Parameters.AddWithValue("@CodeName", agants.CodeName);
                common.Parameters.AddWithValue("@RealName", agants.RealName);
                common.Parameters.AddWithValue("@Location", agants.Location);
                common.Parameters.AddWithValue("@Status", agants.Status);
                common.Parameters.AddWithValue("@MissionsCompleted", agants.MissionsCompleted);
                common.ExecuteNonQuery();
            }
            catch(Exception e) { }
        }


        public void update(int id,string ColumtoSet,Object value)
        {
            MySqlConnection sqlcon = connactionToDatabase(strcon);
            try
            {
                string query = $"UPDATE agants SET {ColumtoSet}=@value WHERE id = @id";
                MySqlCommand common = commonToSql(query,sqlcon);
                common.Parameters.AddWithValue("@id",id);
                common.Parameters.AddWithValue("@value", value);
            }
            catch(Exception e) { }
        }

        public void dalete(int id)
        {
            MySqlConnection sqlcon = connactionToDatabase(strcon);
            try
            {
                string query =$"DELETE FROM agants EHERE id = @id";
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue("@id", id);
            }
            catch (Exception e) { }
        }
    }
    }

   
    
     



    



    public class agants
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int MissionsCompleted { get; set; }

        public agants() { }

        public agants(int id ,string codename,string realname, string location,string status,int missionscompleted)
        {
            this.Id = id;
            this.CodeName = codename;
            this.RealName = realname;
            this.Location = location;
            this.Status = status;
            this.MissionsCompleted = missionscompleted;
        }
    } 

