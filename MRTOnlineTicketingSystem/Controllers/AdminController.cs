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

namespace MRTOnlineTicketingSystem.Controllers
{
    public class AdminController : Controller
    {


        private readonly IConfiguration configuration;
        public AdminController(IConfiguration config)
        {
            this.configuration = config;
        }
        IList<MRTTicket> GetList()
        {

            IList<MRTTicket> DetailList = new List<MRTTicket>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("MRTConn"));

            string sql = "SELECT * FROM PurchaseOrder INNER JOIN MrtUser ON PurchaseOrder.UserID=MrtUser.UID";

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
                        TicketIndex = reader.GetInt32(5),
                        Adult = reader.GetInt32(6),
                        SeniorCitizen = reader.GetInt32(7),
                        Disable = reader.GetInt32(8),
                        Student = reader.GetInt32(9),
                        TotalAmount = reader.GetString(10),
                        CustomerName = reader.GetString(12),
                        CustomerEmail = reader.GetString(14)

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


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(User user)
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

            var UserResult = UserList.Where(x => x.Email == user.Email && x.Usertype == 1).FirstOrDefault();


            if (UserResult != null)
            {
                if (UserResult.Password == user.Password)
                {
                    HttpContext.Session.SetInt32("UserID", UserResult.Uid);
                    HttpContext.Session.SetString("UserEmail", UserResult.Email);
                    HttpContext.Session.SetString("UserName", UserResult.Name);

                    return RedirectToAction("AdminDashboard");


                }
                else
                {
                    ViewBag.error = 1;

                    return View("Login");

                }
            }
            else
            {
                ViewBag.error = 2;
                return View("Login");

            }
        }

        public IActionResult AdminDashboard()
        {

            IList<MRTTicket> DetailList = GetList();
            //count visitor
            DateTime date = DateTime.Today;

            var count_sgbuloh1 = DetailList.Where(x => (x.PurchaseDateTime.Month == date.Month) && (x.PurchaseDateTime.Year == date.Year) && (x.CurrentLocationIndex == 0)).Count();
            var count_sgbuloh2 = DetailList.Where(x => (x.PurchaseDateTime.Month == date.Month) && (x.PurchaseDateTime.Year == date.Year) && (x.DestinationLocationIndex == 0)).Count();



            var test = DetailList.Where(x => (x.PurchaseDateTime.Month == date.Month) && (x.PurchaseDateTime.Year == date.Year)).GroupBy(x => x.CurrentLocationIndex) ;
           foreach(var x in test)
            {
                Console.WriteLine("x count= " + x.Count()) ;
            }

            return View(DetailList);
        }

    }
}
