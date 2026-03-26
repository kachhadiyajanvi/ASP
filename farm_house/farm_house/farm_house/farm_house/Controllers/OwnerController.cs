using farm_house.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.Security.Policy;
using System.Xml.Linq;

namespace farm_house.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public IConfiguration Configuration { get; set; }

        public OwnerController(IWebHostEnvironment environment, IConfiguration _configuration)
        {
            _environment = environment;
            this.Configuration = _configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OwnerModel om)
        {
            DataSet ds = om.select(om.email, om.password);
            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;

                return RedirectToAction("Dashboard");
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(OwnerModel om)
        {
            string name = om.name;
            string email = om.email;
            string password = om.password;
            string contact = om.contact;
            string address = om.address;
            string status = om.status;
            

            if (om.image != null && om.image.Length > 0)
            {
                string filename = Path.GetFileName(om.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await om.image.CopyToAsync(str);
                }
             
            om.insert(name, email, password, contact, address , filename , status);
            }


            return RedirectToAction("Register");
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add_Propertys(OwnerModel om)
        {
            DataSet ds2 = om.View_City();
            ViewBag.data = ds2.Tables[0];

            DataSet ds3 = om.View_Category();
            ViewBag.ds3 = ds3.Tables[0];

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add_Propertys(OwnerModel om , int a)
        {
            string f_name = om.f_name;
            string city = om.city;
            string category = om.category;
            string wd_rate = om.wd_rate;
            string bedrooms = om.bedrooms;
            string bathrooms = om.bathrooms;
            string space = om.space;
            string rules =  om.rules;
            string l_link = om.l_link;
            string address = om.address;
            string facilities = om.facilities;
            //string O_id = TempData.Peek("id").ToString();

            if (om.image != null && om.image.Length > 0)
            {
                string filename = Path.GetFileName(om.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                 using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await om.image.CopyToAsync(str);
                }

                om.insert_property(f_name, city, category,wd_rate,bedrooms,bathrooms,space,rules,l_link,address,facilities,filename);
            }

            return RedirectToAction("Add_Propertys");
        }


        public IActionResult View_Propertys(OwnerModel om)
        {
            DataSet ds2 = om.View_Propertys();
            ViewBag.data = ds2.Tables[0];

            return View();
        }

        
        public IActionResult View_Booking(UserModel um) 
        {
            DataSet ds = um.View_Booking();
            ViewBag.data = ds.Tables[0];

            return View();
        }

        //[HttpPost]
        //public IActionResult View_Booking(UserModel um, int id)
        //{
        //    int user_id = um.user_id;
        //    int farmhouse_id = um.farmhouse_id;
        //    string checkin_date = um.checkin_date;
        //    string checkout_date = um.checkout_date;
        //    string daytime_slot = um.daytime_slot;
        //    string status = um.status;
        //    string cancle = um.cancle;

        //    um.Insert_Booking(id,user_id, farmhouse_id,checkin_date, checkout_date, daytime_slot,status,cancle);

        //    return RedirectToAction("View_Booking");

        //}

        public IActionResult View_Details(OwnerModel om)
        {

            DataSet ds2 = om.View_Propertys();
            ViewBag.data = ds2.Tables[0];

            return View();
        }
    }
}
