using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 
 
namespace dotnetapp.Managers
{
    public class PlayerManager
    {
         public string ConnectionString{get;set;}= "User ID=sa;password=examlyMssql@123; server=localhost;Database=PlayerDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        // Write your fuctions here...
        // DisplayAllPlayers
        // AddPlayer
        // EditPlayer
        // DeletePlayer
        // ListPlayers
        // FindPlayer
        // DisplayAllPlayers
 
//Connected Database
 
 
    public void DisplayAllPlayers(){
 
        string cmdtext = "select * from PlayerTab";
        SqlConnection conn = null;
        try{
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            Console.WriteLine("Connection opened successfully");
            SqlCommand command = new SqlCommand(cmdtext,conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
        {  
          Console.WriteLine($"{reader["Id"]}-----{reader["Name"]}---{reader["Age"]}---{reader["Category"]}---{reader["BidingPrice"]}");  
        }
            conn.Close();
 
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
       
        }
 
        public void AddPlayerToDatabase(Player p){
 
            Console.WriteLine("-----------------ADD-----------------------");
 
            int id = p.Id;
            string name = p.Name;
            int age = p.Age;
            string category = p.Category;
            decimal biddingPrice = p.BiddingPrice;
 
 
        SqlConnection conn = null;
        try
        {
 
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            string qureryStr="insert into PlayerTab values(@id,@name,@age,@category,@bidding)";
            SqlCommand cmd=new SqlCommand(qureryStr,conn);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@category",category);
            cmd.Parameters.AddWithValue("@bidding",biddingPrice);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
 
        }
 
         public void AddPlayer(Player p){
            SqlConnection con= null;
            SqlDataAdapter adapter = null;
            DataSet ds = null;
            try{
                con = new SqlConnection(ConnectionString);
                adapter = new SqlDataAdapter("Select * from PlayerTab",con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                ds = new DataSet();
                adapter.Fill(ds,"PlayerTable");
                DataRow dr = ds.Tables["PlayerTable"].NewRow();
                dr[0]= p.Id;
                dr[1]=p.Name;
                dr[2]=p.Age;
                dr[3]=p.Category;
                dr[4]=p.BiddingPrice;
                ds.Tables["PlayerTable"].Rows.Add(dr);
                adapter.Update(ds,"PlayerTable");
            }
            catch(Exception ex){
                Console.WriteLine("Failed to connect to database");
            }

 
 
        }
        public void EditPlayer(Player p){
            // SqlConnection conn = null;
            // try{
            // conn = new SqlConnection(ConnectionString); 
            // conn.Open();
            // string query = "update Players Set id = @id, name = @name, age = @age, category = @category, bidding = @bidding";
            // SqlCommand cmd = new SqlCommand(query,conn);
            // cmd.Parameters.AddWithValue("@id",id);
            // cmd.Parameters.AddWithValue("@name",name);
            // cmd.Parameters.AddWithValue("@age",age);
            // cmd.Parameters.AddWithValue("@category",category);
            // cmd.Parameters.AddWithValue("@bidding",bidding);
            // cmd.ExecuteNonQuery();
            // conn.Close();
            // }
            // catch(Exception e){
            //     Console.WriteLine(e.Message);
            // }
            SqlConnection con= null;
            SqlDataAdapter adapter = null;
            DataSet ds = null;
            try{
                con = new SqlConnection(ConnectionString);
                adapter = new SqlDataAdapter("Select * from PlayerTab",con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                ds = new DataSet();
                adapter.Fill(ds,"PlayerTable");
                foreach(DataRow dr in ds.Tables["PlayerTable"].Rows){
                        if(Convert.ToInt32(dr[0])==p.Id){
                            dr[1]=p.Name;
                            dr[2]=p.Age;
                            dr[3]=p.Category;
                            dr[4]=p.BiddingPrice;
                            break;
                        }
                }
                adapter.Update(ds,"PlayerTable");
            }
            catch(Exception ex){
                Console.WriteLine("Failed to connect to database.Error Message :"+ ex);
            }

            
 
        }
        public void DeletePlayer(int id){
 
 
        Console.WriteLine("DELETE--------------------------");

        SqlConnection con = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        try{
            con = new SqlConnection(ConnectionString);
            adapter = new SqlDataAdapter("select * from PlayerTab",con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds,"PlayerTable");
            foreach(DataRow dr in ds.Tables["PlayerTable"].Rows){
                if(Convert.ToInt32(dr[0])==id){
                    dr.Delete();
                    adapter.Update(ds,"PlayerTable");
                    Console.WriteLine("Deleted");
                    break;
                }
            }

        }
        catch(Exception ex){
            Console.WriteLine("Record cannot be deleted.Error :"+ex);
        }
    }
 
        public void FindPlayer(string name){
            Player p = new Player();
            SqlConnection con = null;
            SqlDataAdapter adapter = null;
            DataSet ds = null;
            try{
                con = new SqlConnection(ConnectionString);
                adapter = new SqlDataAdapter("select * from PlayerTab",con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                ds = new DataSet();
                adapter.Fill(ds,"PlayerTable");
                foreach(DataRow dr in ds.Tables["PlayerTable"].Rows){
                    if(Convert.ToString(dr[1]) == name){
                        Console.WriteLine("Player Details for Name : "+ name);

                        Console.WriteLine("Id: "+dr[0]+"\nName: "+dr[1]+"\nAge: "+dr[2]+"\nCategory: "+dr[3]+"\nBiddingPrice: "+dr[4]);
                    }
                }
            }
            catch(Exception ex){

            }
            
        }
        public void ListPlayers(){
            SqlConnection con=null;
            SqlDataAdapter adapter=null; 
            DataSet ds=null;
            try{
                con=new SqlConnection(ConnectionString);
                adapter=new SqlDataAdapter("select * from Players",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"PlayerTable");
                foreach(DataRow dr in ds.Tables["PlayerTable"].Rows)
                {
                    Console.WriteLine("Id: "+dr[0]+"\nName: "+dr[1]+"\nAge: "+dr[2]+"\nCategory: "+dr[3]+"\nBiddingPrice: "+dr[4]);
                }
            }catch(Exception ex)
                {
                    Console.WriteLine("Failed to connect to the database. Error message: " + ex);
                }

        }
    }
}