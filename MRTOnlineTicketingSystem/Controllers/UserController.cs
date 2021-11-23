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
using MRTOnlineTicketingSystem.MailSettings;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace MRTOnlineTicketingSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        public UserController(IConfiguration config)
        {
            this.configuration = config;
        }
        IList<MRTTicket> GetList()
        {
     
            IList<MRTTicket> DetailList = new List<MRTTicket>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));

            string sql = "SELECT * FROM PurchaseOrder";

            SqlCommand getList = new SqlCommand(sql, conn);

            try
            {

                conn.Open();
                SqlDataReader reader = getList.ExecuteReader();

                while (reader.Read())
                {
                    DetailList.Add(new MRTTicket()
                    {
                        Invoiceid = reader.GetInt32(0),
                        Userid = reader.GetInt32(1),
                        PurchaseDateTime = reader.GetDateTime(2),
                        CurrentLocationIndex = reader.GetInt32(3),
                        DestinationLocationIndex = reader.GetInt32(4),
                        TicketIndex= reader.GetInt32(5),
                        Adult = reader.GetInt32(6),
                        SeniorCitizen = reader.GetInt32(7),
                        Disable = reader.GetInt32(8),
                        Student = reader.GetInt32(9),
                        TotalAmount = reader.GetString(10)

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

            return DetailList;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
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
               


                if (emailResult != null)
                {
                    Console.WriteLine("email exist");
                    ViewBag.UserExist = true;
                    return View(user);
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
                    createUser.Parameters.AddWithValue("@icnumber", user.ICNumber);
                    createUser.Parameters.Add("@uid", SqlDbType.Int).Direction = ParameterDirection.Output;
                   
                    try
                    {
                        conn.Open();
                        createUser.ExecuteNonQuery();
                        string id = createUser.Parameters["@uid"].Value.ToString();

                        if (id != null)
                        {
                            return RedirectToAction("Login");
                        }
                        Console.WriteLine("id" + id);
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
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
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

                //ok dah kot aku try sat
                Console.WriteLine("AFter login" + HttpContext.Session.GetString("redirect"));
            if (UserResult != null)
            {
                if (UserResult.Password == user.Password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserResult.Name, ClaimValueTypes.String, "adminportal"),
                    new Claim("UserEmail", UserResult.Email),
                    new Claim("UserID", UserResult.Uid.ToString()),
                    new Claim("UserName", UserResult.Name),
                    new Claim("UserEmail", UserResult.Email)
                };

                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                        IsPersistent = true,
                        AllowRefresh = true
                    });

                    HttpContext.Session.SetInt32("UserID", UserResult.Uid);
                    HttpContext.Session.SetString("UserEmail", UserResult.Email);
                    HttpContext.Session.SetString("UserName", UserResult.Name);
               
                    Console.WriteLine("redirect val ="+ HttpContext.Session.GetString("redirect"));
                    if (HttpContext.Session.GetString("redirect") == "true")
                    {

                        return RedirectToAction("TicketForm");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard");
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
      
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult TicketForm()
        {
            MRTTicket mrt = new MRTTicket();
          
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
     
                TempData["error1"] = 1;
                HttpContext.Session.SetString("redirect", "true"); 

                Console.WriteLine("before login= " + HttpContext.Session.GetString("redirect"));
                return RedirectToAction("Login"); 
            }
            else
            {

         
                mrt.CurrentLocationIndex = -1;
                mrt.DestinationLocationIndex = -1;
                mrt.TicketIndex = -1;

                return View(mrt);
            }
       
        }
       
        [HttpPost]
        public IActionResult TicketForm(MRTTicket mrt)
        {
            Console.WriteLine("run  from val="+ mrt.DictStation[mrt.CurrentLocationIndex]);
            if (ModelState.IsValid)
            {
                
               
               if(mrt.TotalAmount!="RM 0")
                {
                    Console.WriteLine("run1");
                    SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));
                    SqlCommand createPurchase = new SqlCommand("InsertPurchase", conn);
                    createPurchase.CommandType = CommandType.StoredProcedure;


                    createPurchase.Parameters.AddWithValue("@uid", HttpContext.Session.GetInt32("UserID"));
                    createPurchase.Parameters.AddWithValue("@purchasedate", mrt.PurchaseDateTime);
                    createPurchase.Parameters.AddWithValue("@from", mrt.CurrentLocationIndex);
                    createPurchase.Parameters.AddWithValue("@to", mrt.DestinationLocationIndex);
                    createPurchase.Parameters.AddWithValue("@ticketway", mrt.TicketIndex);
                    createPurchase.Parameters.AddWithValue("@adult", mrt.Adult);
                    createPurchase.Parameters.AddWithValue("@seniorcitizen", mrt.SeniorCitizen);
                    createPurchase.Parameters.AddWithValue("@disable", mrt.Disable);
                    createPurchase.Parameters.AddWithValue("@student", mrt.Student);
                    createPurchase.Parameters.AddWithValue("@totalamount", mrt.TotalAmount);


                    try
                    {
                        Console.WriteLine("run2");
                        conn.Open();

                        if (createPurchase.ExecuteNonQuery() > 0)
                        {

                            conn.Close();

                            var UserEmail = HttpContext.Session.GetString("UserEmail");
                            var UserName = HttpContext.Session.GetString("UserName");
                            var subject = "MRT Ticket receipt";
                            var body = "Customer Name  :" + UserName + "<br>" +
                                        "Date and time  :" + mrt.PurchaseDateTime + "<br>" +
                                        "TICKET INFORMATION <br>" +
                                        "From           :" + mrt.DictStation[mrt.CurrentLocationIndex] + "<br>" +
                                        "To             :" + mrt.DictStation[mrt.DestinationLocationIndex] + "<br>" +
                                        "Trip type      :" + mrt.DictTicketType[mrt.TicketIndex] + "<br>" +
                                        "TICKET QUANTITY <br>" +
                                        "Adult          :" + mrt.Adult + "<br>" +
                                        "Student        :" + mrt.Student + "<br>" +
                                        "Senior Citizen :" + mrt.SeniorCitizen + "<br>" +
                                        "Disable        :" + mrt.Disable + "<br>" +

                                        "<br>" +
                                        "Total          :" + mrt.TotalAmount;

                            var mail = new Mail(configuration);

                            if (mail.Send(configuration["Gmail:Username"], UserEmail, subject, body))
                            {
                                ViewBag.Message = "Receipt successfully sent to " + UserEmail;
                                return View("SummaryTicket", mrt);
                            }
                            else
                            {
                                Console.WriteLine("Sent mail failed" + UserEmail);
                            }



                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("e= " + e);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    {
                        ViewBag.Choose = "no ticket";
                        return View(mrt);
                    }
                }
       
            }
            else
            {
                return View(mrt);
            }

            return View(mrt);
        }
        
        [HttpGet]
        public IActionResult UserDashboard()
        {
            
            ViewBag.Name = HttpContext.Session.GetString("UserName");
            IList<MRTTicket> DetailList = GetList();
            Console.WriteLine(HttpContext.Session.GetInt32("UserID"));
            var result = DetailList.Where(x => x.Userid == HttpContext.Session.GetInt32("UserID")).OrderByDescending(x=>x._PurchaseDateTime);

            return View(result);
        }

        public IActionResult Details(int id)
        {
            IList<MRTTicket> DetailList = GetList();
            var result = DetailList.First(x => x.Invoiceid == id);
            return View(result); 
        }

        public IActionResult SearchIndex(string searchString)
        {
            IList<MRTTicket> DetailList = GetList();
            DateTime date = Convert.ToDateTime(searchString);
            Console.WriteLine("date va;=" +date);
            var result = DetailList.Where(x => x._PurchaseDateTime.Date ==date.Date && x.Userid == HttpContext.Session.GetInt32("UserID")).OrderByDescending(x=>x._PurchaseDateTime) ;
            foreach(var x in result)
            {
                Console.WriteLine("ini result" + x._PurchaseDateTime.Date);
            }

            return View("UserDashboard", result);
        }

    }


}
