using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class HomeController : Controller  
    {
        OrderingSystemContext _context;
        
        public HomeController(OrderingSystemContext context)
        {
            _context = context;
        }
      

        public IActionResult LoginValidate(IFormCollection keyValues)
        {
            var email = keyValues["email-id"][0];
            var userpass = keyValues["password"][0];
            User_Registration user_Registration = new User_Registration();
            user_Registration.Email_ID = email;
            user_Registration.User_Password = userpass;
            var IsUserValidate = true;
            IsUserValidate = _context.User_Registration.Where(x => x.Email_ID.ToLower() == email.ToLower() && x.User_Password == userpass).Any();
            if (IsUserValidate == false)
            {
                TempData["Error"] = "Password or email wrong";
                TempData.Keep("Error");
                return RedirectToAction("Login");
            }

            return RedirectToAction("About");
        }

        [HttpPost]
        public IActionResult Save(IFormCollection keyValues)
        {
            var firstname = keyValues["firstname"][0];
            var lastname = keyValues["lastname"][0];
            var useradd = keyValues["useradd"][0];
            var email = keyValues["email-id"][0];
            var userpass = keyValues["userpass"][0];
           // var dob = keyValues["dob"][5];
            DateTime dob = Convert.ToDateTime(keyValues["dob"][0]);//use jquery to do validations
            var city = keyValues["city"][0];
            var zipcode = keyValues["zipcode"][0];
            var state = keyValues["state"][0];
            

            var isUserAlreadyInDB = false;
            isUserAlreadyInDB = _context.User_Registration.Where(x => x.Email_ID.ToLower() == email.ToLower()).Any();//Any()--property of the LinQ
                                                                       //put "." and learn all properties          //&& x.User_Password == password) 
            if(isUserAlreadyInDB)
            {
                TempData["Error"] = "User already in the system";
                TempData.Keep("Error");
                return RedirectToAction("Signup");
            }

            User_Registration user_Registration = new User_Registration();
           
            user_Registration.First_Name = firstname;
            user_Registration.Last_Name = lastname;
            user_Registration.User_Address = useradd;
            user_Registration.Email_ID = email;
            user_Registration.User_Password = userpass;
            user_Registration.Date_Of_Birth = dob;
            user_Registration.City_Name = city;
            user_Registration.Zip_Code = zipcode;
            user_Registration.State_Name = state;
            user_Registration.User_Status = true;
            

            // _context.User_Registrations.Add(user_Registration);//used LinQ to insert data in DB instead Query
            //basically save syntext
            _context.User_Registration.Add(user_Registration);//OrderingSystem.Models.User_Registration
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
       
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Signup()
        {
            if (TempData.Peek("Error") != null)
            {
                ViewData["Error"] = TempData["Error"];
            }
            return View();
        }
        public IActionResult Login()
        {
            if (TempData.Peek("Error") != null)
            {
                ViewData["Error"] = TempData["Error"];
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
