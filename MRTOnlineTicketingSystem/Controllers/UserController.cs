using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRTOnlineTicketingSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


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

            if (ModelState.IsValid) {
                IList<User> emailList = new List<User>();
                SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));
                string findUserSQL = @"SELECT UEmail FROM MrtUser";
                SqlCommand runFindUser = new SqlCommand(findUserSQL, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = runFindUser.ExecuteReader();
                    while (reader.Read())
                    {
                        emailList.Add(new User()
                        {
                            Email = reader.GetString(0)
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
            if (ModelState.IsValid) {
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
                            Name= reader.GetString(1),
                            Email= reader.GetString(3),
                            Password= reader.GetString(4),
                            Usertype=reader.GetInt32(5)

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
                    if(UserResult.Password== user.Password)
                    {
                        return View("UserDashboard");
                    }
                    else
                    {
                        //return login page with error wrong password
                    }
                }
                else
                {
                    //return to login with error email not exist
                }
            }
            else
            {
                return View(user);
            }
           
            return View(user);
        }


    }
}
