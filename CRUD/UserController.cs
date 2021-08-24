using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User.Models;
using System.Security.Cryptography;
namespace Singularity.Controllers
{
    public class UserController : Controller
    {
        private DB_Entities _context = new DB_Entities();
		User us;
        // GET: List data
        public ActionResult Index()
        {
            var listofData = _context.User.ToList();  
			return View(listofData);  
        }


       [HttpGet]
	   public ActionResult Create()
	   {
		 return View();   
	   }
	   [HttpGet]
	   public ActionResult Create(User model)
	   {
		   _context.User.Add(model);
		   _context.SaveChanges();
		   ViewBag.Message = "Data Insert Successfully";  
			return View();  
	   }
	   
	   [HttpGet]  
		public ActionResult Edit(int id)  
		{               
			var data = _context.User.Where(x => x.UserId == id).FirstOrDefault();  
			return View(data);  
		}  
		[HttpPost]  
		public ActionResult Edit(User Model)  
		{  
			var data = _context.User.Where(x => x.UserId == Model.UserId).FirstOrDefault();  
			if (data != null)  
			{  
				data.UserCity = Model.UserCity;  
				data.UserName = Model.UserName;  
				data.UserSalary = Model.UserSalary;  
				_context.SaveChanges();  
			}  
		  
			return RedirectToAction("index");  
		}
		
		[HttpGet]
		public ActionResult View(int id)  
		{  
			var data = _context.User.Where(x => x.UserId == id).FirstOrDefault();  
			return View(data);  
		} 
		
		[HttpGet]
		
		public ActionResult Delete (int id)
		{
			var data =ontext.User.Where(x => x.UserId == id).FirstOrDefault();  
			_context.User.Remove(data);  
			_context.SaveChanges();  
			ViewBag.Messsage = "Delete Successfully";  
			return RedirectToAction("index");
		}
    }
}
