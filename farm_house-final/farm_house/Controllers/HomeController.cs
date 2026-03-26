using System.Data;
using System.Diagnostics;
using farm_house.Models;
using Microsoft.AspNetCore.Mvc;

namespace farm_house.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(AdminModel am, OwnerModel om)
        {
            DataSet ds = am.View_Slider();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = om.View_Propertys();
            ViewBag.ds2 = ds2.Tables[0];

            return View();
        }

        

        [HttpGet]
        public IActionResult Propertis(OwnerModel om , AdminModel am)
        {

            DataSet ds = om.View_Propertys();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = am.View_Category();
            ViewBag.ds2 = ds2.Tables[0];

            return View();
        }

        public IActionResult About(AboutTeamModel tm , AdminModel am)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = am.View_About();
            ViewBag.ds2 = ds2.Tables[0];

            return View();
        }

        public IActionResult Blog(AdminModel am)
        {
            DataSet ds = am.View_Blog();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(UserModel um)
        {
           

            return View();
        }

        [HttpGet]
        public IActionResult Property_details(OwnerModel om , int id)
        {
            DataSet ds = om.select_property(id);
            ViewBag.ds = ds.Tables[0];
            ViewBag.farm_id = id;

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                var rate = dr["rate"].ToString();
                TempData["rate"] = rate;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel um)
        {
            DataSet ds = um.select_user(um.email, um.password);

            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["user_login_id"] = id;


                var name = dr["name"].ToString();
                TempData["name"] = name;
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Privacy(UserModel um)
        {
            string name = um.name;
            string email = um.email;
            string password = um.password;
            string contact = um.contact;

            um.insert_user(name, email, password, contact);

            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Booking(OwnerModel om,int id)
        {
            DataSet ds = om.select_property(id);
            ViewBag.ds = ds.Tables[0];

            

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows) 
            {
                ViewBag.farm_name = dr["name"];
                ViewBag.contact = dr["category"];
                ViewBag.price = dr["rate"];
            }

            return View();
        }

        [HttpPost]
        public IActionResult Booking(UserModel um ,int id)
        {
            int user_id = 1;

            int farmhouse_id = id;
            string checkin_date = um.checkin_date;
            string checkout_date = um.checkout_date;
            string daytime_slot = um.daytime_slot;
           

            um.Insert_Booking(id, user_id, farmhouse_id, checkin_date, checkout_date, daytime_slot, "0", "NO");

          

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }

    }
}
