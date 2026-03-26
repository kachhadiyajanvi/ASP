using farm_house.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.ContentModel;
using System.Data;
using System.Xml.Linq;

namespace farm_house.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult index(AdminModel am)
        {
            DataSet ds = am.select(am.email, am.password);

            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;

                return RedirectToAction("Deshboard");
            }
            return RedirectToAction("index");
        }


        public IActionResult Deshboard()
        {
            return View();
        }

        public async Task<ActionResult> Add_Admin(AdminModel am)
        {
            string name = am.name;
            string email = am.email;
            string password = am.password;

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
                am.insert(name, email, password,  filename);
            }
            return View();
        }
        public IActionResult View_Admin(AdminModel am)
        {
            DataSet ds = am.View_Admin();
            ViewBag.data = ds.Tables[0];
            return View();
        }

        [HttpGet]
        public IActionResult Update_Admin(AdminModel am, int id)
        {
            DataSet ds = am.update_admin(id);
            ViewBag.data = ds.Tables[0];
            foreach (System.Data.DataRow dr in ViewBag.data.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }
        public IActionResult Delete_Admin(AdminModel am, int id)
        {
            am.Delete_Admin(id);

            return RedirectToAction("View_Admin");
        }

        [HttpPost]
        public async Task<ActionResult> Update_Admin(AdminModel am , int id , int a = 0)
        {
            string name = am.name;
            string email = am.email;
            string password = am.password;

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
            }
            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            am.update_admin_1(id, name,email,password, filename);
    
            return RedirectToAction("View_Admin");
        }

        public IActionResult View_Owner(OwnerModel om)
        {
            DataSet ds = om.View_Owner();
            ViewBag.data = ds.Tables[0];

            return View();
        }

        public IActionResult Delete_Owner(AdminModel am, int id)
        {
            am.Delete_Owner(id);

            return RedirectToAction("View_Owner");
        }


        public IActionResult View_Property(OwnerModel om)
        {
            DataSet ds = om.View_Propertys();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        public IActionResult View_Booking(UserModel um)
        {
           DataSet ds =  um.View_Booking();
            ViewBag.data = ds.Tables[0];
;
            return View();
        }

        public IActionResult Add_Slider()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add_Slider(AdminModel am)
        {
            string title = am.title;
            string description = am.description;

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
                am.Add_slider(title, description, filename);
            }
            return View();
        }


        public IActionResult View_Slider(AdminModel am)
        {
            DataSet ds = am.View_Slider();
            ViewBag.data = ds.Tables[0];

            return View();
        }


        public IActionResult Delete_Slider(AdminModel am, int id)
        {
            am.Delete_Slider(id);

            return RedirectToAction("View_Slider");
        }

        [HttpGet]
        public IActionResult update_slider(AdminModel am, int id)
        {
            DataSet ds = am.update_slider(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_slider(AdminModel am, int id, int a = 0)
        {
            string title = am.title;
            string descriptions = am.description;

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            am.update_slider(id, title, descriptions, filename);

            return RedirectToAction("View_Slider");
        }




       
        [HttpGet]
        public IActionResult Add_City(AdminModel am)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_City(AdminModel am,int a=0) {

            string city = am.city;

            am.Add_city(city);

            return RedirectToAction("Add_City");

        }


        public IActionResult View_City(AdminModel aam)
        {
            DataSet ds = aam.View_City();
            ViewBag.data = ds.Tables[0];


            return View();
        }



        [HttpGet]
        public IActionResult Add_Category(AdminModel amm)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Category(AdminModel amm, int a = 0)
        {
            string category = amm.category;

            amm.Add_Category(category);

            return RedirectToAction("Add_Category");
        }

        public IActionResult View_Category(AdminModel am, UserModel um)
        {
            DataSet ds = am.View_Category();
            ViewBag.data = ds.Tables[0];

            DataSet ds2 = um.View_Category();
            ViewBag.data = ds2.Tables[0];

            return View();
        }


        public IActionResult delete_c(AdminModel am, int id)
        {
            am.delete_c(id);
            return RedirectToAction("View_Category");
        }


        [HttpGet]
        public IActionResult update_category(AdminModel am , int id)
        {
            DataSet ds = am.update_category(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["category"] = dr["category"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_category(AdminModel am, int id, int a = 0)
        {
            string category = am.category;

            am.update_data(id, category);

            return RedirectToAction("View_Category");
        }



        [HttpGet]
        public IActionResult Add_Blog()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add_Blog(AdminModel am)
        {
            string title = am.title;
            string description = am.description;

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
                am.Add_Blog(filename,title,description);
            }
            return RedirectToAction("Add_Blog");
        }

        public IActionResult View_Blog(AdminModel am)
        {
            DataSet ds = am.View_Blog();
            ViewBag.ds = ds.Tables[0];
         
            return View();

        }

        public IActionResult delete_b(AdminModel am, int id)
        {
            am.delete_b(id);
            return RedirectToAction("View_Blog");
        }


        [HttpGet]
        public IActionResult Update_Blog(AdminModel am, int id)
        {
            DataSet ds = am.Update_Blog(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update_Blog(AdminModel am, int id, int a = 0)
        {
            string title = am.title;
            string descriptions = am.description;


            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            am.Update_Blog(id, title, descriptions, filename);

            return RedirectToAction("View_Blog");
        }









        public IActionResult View_contact(UserModel um)
        {
            DataSet ds = um.View_contact();
            ViewBag.data = ds.Tables[0];

            return View();

        }

       

        [HttpGet]
        public IActionResult Add_Team()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Add_Team(AboutTeamModel tm)
        {
            string name = tm.name;
            string position = tm.position;
            string descriptions = tm.descriptions;

            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }

                tm.insert(name, position, descriptions, filename);
            }

            return RedirectToAction("add_team");
        }



        public IActionResult View_Team(AboutTeamModel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_t(AboutTeamModel tm, int id)
        {
            tm.Delete(id);
            return RedirectToAction("view_team");
        }


        [HttpGet]
        public IActionResult update_team(AboutTeamModel tm, int id)
        {
            DataSet ds = tm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_team(AboutTeamModel tm, int id, int a = 0)
        {
            string name = tm.name;
            string position = tm.position;
            string descriptions = tm.descriptions;


            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, name, position, descriptions, filename);

            return RedirectToAction("view_team");
        }





        //[HttpGet]
        //public IActionResult up_main_cat(main_cat mc, int id)
        //{
        //    DataSet ds = mc.up_main_cat(id);
        //    ViewBag.ds = ds.Tables[0];

        //    foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
        //    {
        //        TempData["old_image_name"] = dr["image"].ToString();
        //    }

        //    return View();
        //}

        //[HttpPost]
        //public  up_main_cat(main_cat mc, int id, int a = 0)
        //{


        //    if (filename == "")
        //    {
        //        filename = TempData.Peek("old_image_name").ToString();
        //    }

        //    mc.up_main_data(id, name, filename);

        //    return RedirectToAction("ma_view_cat");
        //}


        [HttpGet]
        public IActionResult Add_About()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Add_About(AdminModel am)
        {
            string icon = am.icon;
            string title = am.title;
            string description = am.description;

            
            am.Add_About(icon,title, description);
            
            return View();
        }


        public IActionResult View_About(AdminModel am)
        {
            DataSet ds = am.View_About();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        public IActionResult Delete_ab(AdminModel am, int id)
        {
            am.delete_ab(id);

            return RedirectToAction("View_About");
        }

        [HttpGet]
        public IActionResult update_About_Us(AdminModel am, int id)
        {
            DataSet ds = am.update_About_Us(id);
            ViewBag.ds = ds.Tables[0];

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_About_Us(AdminModel am, int id, int a = 0)
        {
            string icon = am.icon;
            string title = am.title;
            string descriptions = am.description;

            am.update_About_Us(id , icon, title, descriptions);

            return RedirectToAction("View_About");
        }



    }
}
