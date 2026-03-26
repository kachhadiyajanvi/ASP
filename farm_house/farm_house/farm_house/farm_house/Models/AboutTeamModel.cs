using System.Data.SqlClient;
using System.Data;

namespace farm_house.Models
{
    public class AboutTeamModel
    {
        public string name { get; set; }

        public string position { get; set; }

        public string descriptions { get; set; }

        public IFormFile image { get; set; }


        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  farm_House_booking; User Id=sa; password=123;TrustServerCertificate=True");



        public int insert(string name, string position, string descriptions, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into about_our_team(name , position, descriptions ,image)values('" + name + "','" + position + "', '" + descriptions + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[about_our_team]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[about_our_team] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[about_our_team] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id, string name, string position, string descriptions, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[about_our_team] set name = '" + name + "', position = '" + position + "' , descriptions = '" + descriptions + "', image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
