using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRTOnlineTicketingSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Web;


namespace MRTOnlineTicketingSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        public UserController(IConfiguration config)
        {
            this.configuration = config;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                IList<User> emailList = new List<User>();
                SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));
                string findUserSQL = @"SELECT * FROM MrtUser";
                SqlCommand runFindUser = new SqlCommand(findUserSQL, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = runFindUser.ExecuteReader();
                    while (reader.Read())
                    {
                        emailList.Add(new User()
                        {
                            Uid = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            Usertype = reader.GetInt32(5)
                        });
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("ini error : " + e);
                }
                finally
                {
                    conn.Close();
                }

                var emailResult = emailList.Where(x => x.Email == user.Email).FirstOrDefault();
                ViewBag.UserID = emailResult.Uid;


                if (emailResult != null)
                {
                    Console.WriteLine("email exist");
                }
                else
                {
                    Console.WriteLine("email tak exist");
                    SqlCommand createUser = new SqlCommand("CreateUser", conn);
                    createUser.CommandType = CommandType.StoredProcedure;

                    createUser.Parameters.AddWithValue("@uname", user.Name);
                    createUser.Parameters.AddWithValue("@udob", user.DateOfBirth);
                    createUser.Parameters.AddWithValue("@uemail", user.Email);
                    createUser.Parameters.AddWithValue("@upass", user.Password);
                    createUser.Parameters.AddWithValue("@utype", "2");

                    try
                    {
                        conn.Open();
                        createUser.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                    return View("Login");
                }

            }
            else
            {
                return View(user);
            }

            return View(user);

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            Console.WriteLine("masuk:");
            IList<User> UserList = new List<User>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));
            string findUserSQL = @"SELECT * FROM MrtUser";
            SqlCommand runFindUser = new SqlCommand(findUserSQL, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = runFindUser.ExecuteReader();
                while (reader.Read())
                {
                    UserList.Add(new User()
                    {
                        Uid = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        Usertype = reader.GetInt32(5)

                    });
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            var UserResult = UserList.Where(x => x.Email == user.Email).FirstOrDefault();


            if (UserResult != null)
            {
                if (UserResult.Password == user.Password)
                {
                    HttpContext.Session.SetInt32("UserID", UserResult.Uid);
                    if (HttpContext.Session.GetInt32("error")==1)
                    {
                        HttpContext.Session.Remove("error");
                        return View("TicketForm");
                    }
                    else
                    {
                        return View("UserDashboard");
                    }
                  
                }
                else
                {
                    ViewBag.error = 1;

                    return View("Login");
                    //return login page with error wrong password
                }
            }
            else
            {
                ViewBag.error = 2;
                return View("Login");
                //return to login with error email not exist

            }
        }
        [HttpGet]
        public IActionResult TicketForm()
        {
            MRTTicket mrt = new MRTTicket();
            mrt.rdirect = false;


            if (HttpContext.Session.GetInt32("UserID") == null)
            {
             
                ViewBag.error = 3;
                mrt.rdirect = true;
                Console.WriteLine("wehh"+ mrt.rdirect);
                TempData["error1"] = 1;
                HttpContext.Session.SetInt32("error", 1);
                return Redirect("Login");
            }
            else
            {

         
                mrt.currentLocationIndex = -1;
                mrt.destinationLocationIndex = -1;
                mrt.TicketIndex = -1;

                return View(mrt);
            }
       
        }
       
        [HttpPost]
        public IActionResult TicketForm(MRTTicket mrt)
        {
            Console.WriteLine("val" + mrt.rdirect);
            if (mrt.rdirect)
            {
                mrt.currentLocationIndex = -1;
                mrt.destinationLocationIndex = -1;
                mrt.TicketIndex = -1;
                mrt.rdirect = false;
                return View(mrt);
            }
            else
            {
                return View("ConfirmationTicket", mrt);
            }
            
  
        }



    }


}
