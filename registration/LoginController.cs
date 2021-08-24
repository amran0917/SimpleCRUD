using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
using MvcApplication.Models;  
using System.Data.SqlClient;  
using System.Configuration;  
using System.Data;  
using System.Web.Security;  
  
namespace MvcApplication.Controllers  
{  
    public class LoginController : Controller  
    {   
        // GET: /UserLogin/  
          
        public ActionResult Index()  
        {  
            return View();  
        }  
		
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data =_db.Registration.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Name"] = data.FirstOrDefault().Name;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["ID"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
     
  
    }  
} 