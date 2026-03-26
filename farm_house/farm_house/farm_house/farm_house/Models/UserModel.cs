using System.Data.SqlClient;
using System.Data;

namespace farm_house.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public IFormFile image { get; set; }
        public string password {  get; set; }
        public string contact { get; set; }

        public int user_id { get; set; }
        public int farmhouse_id { get; set; }
        public string checkin_date { get; set; }
        public string checkout_date { get; set; }
        public string daytime_slot { get; set; }
        public string status { get; set; }
        public string cancle { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  farm_House_booking; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string name, string email, string subject, string message)
        {
            SqlCommand cmd = new SqlCommand("insert into contact_us(name,email,subject,message)values('" + name + "','" + email + "','" + subject + "','" + message + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[contact_us]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet View_contact()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[contact_us]", con);
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

        public int Add_Blog(string title, string description, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into blog(title,description,image)values('" + title + "','" + description + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet View_About()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[about_offer]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int insert_user(string name, string email, string password, string contact)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[user](name,email,password,contact)values('" + name + "','" + email + "','" + password + "','" + contact + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select_user(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user] where  email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Insert_Booking(int id, int user_id, int farmhouse_id, string checkin_date , string checkout_date , string daytime_slot, string status , string cancle)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[farmhouse_bookings](id,user_id,farmhouse_id,checkin_date,checkout_date,daytime_slot,status,cancle)values('" + id + "','" + user_id + "','" + farmhouse_id + "','" + checkin_date + "','"+ checkout_date + "',' " + daytime_slot + " ',' " + status + " ',' " + cancle + " ')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet View_Booking()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[farmhouse_bookings]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
