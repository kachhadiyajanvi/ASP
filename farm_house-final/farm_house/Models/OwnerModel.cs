using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Xml.Linq;

namespace farm_house.Models
{
    public class OwnerModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string category { get; set; }
        public IFormFile image { get; set; }
        public string status { get; set; }

        public string f_name { get; set; }
        public string wd_rate { get; set; }
        public string bedrooms { get; set; }
        public string bathrooms { get; set; }
        public string space { get; set; }
        public string rules { get; set; }
        public string l_link { get; set; }
        public string O_id { get; set; }

        public string facilities { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  farm_House_booking; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string name, string email, string password, string contact, string address, string filename, string status)
        {
            SqlCommand cmd = new SqlCommand("insert into owner(name,email,password,contact,address,image,status)values('" + name + "','" + email + "','" + password + "','" + contact + "','" + address + "','" + filename + "','" + status + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[owner] where  email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[owner]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet View_Owner()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[owner]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        /*---V I E W ------P R O P E R T Y -----------*/

        public int insert_property(string f_name,string city,string category,string wd_rate,string bedrooms,string bathrooms,string space,string rules,string l_link,string address,string facilities, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into property(name,rate,bedrooms,bathrooms,location_link,category,city,image,rules,space,facilities,address)values('" + f_name + "','"+wd_rate+"','"+bedrooms+"','"+bathrooms+"','"+l_link+"','"+category+"','"+city+"','"+filename+ "','"+rules+"','" + space+"', '"+ facilities + "' ,'" + address + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }   

        public DataSet select_property(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[property] where id = '"+id+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet View_Propertys()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[property]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet View_single_Propertys(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[property] where id=" + id, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[owner] where id = '" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[owner] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_user(int id, string name)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[owner] set name = '" + name + "' where id = '" + id + "'", con);

            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet View_City()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[city]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet View_Category()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[category]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
