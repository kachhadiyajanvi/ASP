using System.Data;
using System.Data.SqlClient;

namespace farm_house.Models
{
    public class AdminModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public IFormFile image { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string icon { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  farm_House_booking; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string name, string email, string password, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into admin(name,email,password,image)values('" + name + "','" + email + "','" + password + "','"+filename+"')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[admin] where  email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet View_Admin()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[admin]",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }





        public int Add_slider(string title, string description, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into slider(title,description,image)values('" + title + "','" + description + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet View_Slider()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[slider]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete_Admin(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[admin] where id = '" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete_Owner(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[owner] where id = '" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int Delete_Slider(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[slider] where id = '" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }


        public DataSet update_slider(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[slider] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_slider(int id, string title, string description, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[slider] set title = '" + title + "', description = '" + description + "', image = '" + filename + "'  where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }



        public int Add_city(string city)
        {
            SqlCommand cmd = new SqlCommand("insert into city(city_name)values('"+city+"')", con);
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

        public int Add_Category(string category)
        {
            SqlCommand cmd = new SqlCommand("insert into category(category)values('"+category+"')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet View_Category()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[category]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet update_admin(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[admin] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_admin_1(int id, string name, string email, string password, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[admin] set name = '" + name + "',email = '" + email + "', password = '"+ password +"', image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public int Add_Blog(string filename, string title, string description)
        {
            SqlCommand cmd = new SqlCommand("insert into blog(image,title,description)values('" + filename + "','" + title + "','" + description + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet View_Blog()
        {
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[blog]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int delete_b(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[blog] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet Update_Blog(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[blog] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Update_Blog(int id, string title , string description , string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[blog] set  title = '" + title + "', description = '" + description + "' , image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }



        public int delete_c(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[category] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_category(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[category] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id, string category)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[category] set category = '" + category + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }





        public int Add_About(string icon , string title , string description)
        {
            SqlCommand cmd = new SqlCommand("insert into about_offer(icon,title,description)values('" + icon + "' , ' " + title + " ', ' " + description + " ')", con);
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
        public int delete_ab(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[about_offer] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_About_Us(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[about_offer] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_About_Us(int id, string icon , string title , string description)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[about_offer] set icon = '" + icon + "' , title = ' " + title + " ' , description = '" + description + " '  where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
