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
using X.PagedList;
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

                    return View("AdminLogin");

                }
            }
            else
            {
                ViewBag.error = 2;
                return View("AdminLogin");

            }
        }

        public IActionResult Visitor()
        {

            IList<MRTTicket> DetailList = GetList();
            //count visitor
            DateTime date = DateTime.Today;

            var test = DetailList.Where(x => (x.PurchaseDateTime.Month == date.Month) && (x.PurchaseDateTime.Year == date.Year))
                .GroupBy(x => x.CurrentLocationIndex)
                .Select(x => new { CurrentLocationIndex = x.Key, TotalVisitor = x.Select(c => c.Adult + c.SeniorCitizen + c.Student + c.Disable).Sum() });

            foreach (var x in test)
            {
                Console.WriteLine($"CurrentLocationIndex: {x.CurrentLocationIndex} TotalVisitor: {x.TotalVisitor}");

                switch (x.CurrentLocationIndex)
                {
                    case 0:
                        ViewBag.SgBuloh = x.TotalVisitor;
                        break;
                    case 1:
                        ViewBag.KampungSelamat = x.TotalVisitor;
                        break;
                    case 2:
                        ViewBag.KwasaDamansara = x.TotalVisitor;
                        break;
                    case 3:
                        ViewBag.KwasaSentral = x.TotalVisitor;
                        break;
                    case 4:
                        ViewBag.KotaDamansara = x.TotalVisitor;
                        break;
                    case 5:
                        ViewBag.Surian = x.TotalVisitor;
                        break;
                    case 6:
                        ViewBag.MutiaraDamansara = x.TotalVisitor;
                        break;
                    case 7:
                        ViewBag.BandarUtama = x.TotalVisitor;
                        break;
                    case 8:
                        ViewBag.TamanTunDrIsmail = x.TotalVisitor;
                        break;
                    case 9:
                        ViewBag.PhileoDamansara = x.TotalVisitor;
                        break;
                    case 10:
                        ViewBag.PusatBandarRayaDamansara = x.TotalVisitor;
                        break;
                    case 11:
                        ViewBag.Semantan = x.TotalVisitor;
                        break;
                    case 12:
                        ViewBag.MuziumNegara = x.TotalVisitor;
                        break;
                    case 13:
                        ViewBag.PasarSeni = x.TotalVisitor;
                        break;
                    case 14:
                        ViewBag.Merdeka = x.TotalVisitor;
                        break;
                    case 15:
                        ViewBag.BukitBintang = x.TotalVisitor;
                        break;
                    case 16:
                        ViewBag.TunRazakExchange = x.TotalVisitor;
                        break;
                    case 17:
                        ViewBag.Cochrane = x.TotalVisitor;
                        break;
                    case 18:
                        ViewBag.Maluri = x.TotalVisitor;
                        break;
                    case 19:
                        ViewBag.TamanPertama = x.TotalVisitor;
                        break;
                    case 20:
                        ViewBag.TamanMidah = x.TotalVisitor;
                        break;
                    case 21:
                        ViewBag.TamanMutiara = x.TotalVisitor;
                        break;
                    case 22:
                        ViewBag.TamanConnaught = x.TotalVisitor;
                        break;
                    case 23:
                        ViewBag.TamanSuntex = x.TotalVisitor;
                        break;
                    case 24:
                        ViewBag.SriJaya = x.TotalVisitor;
                        break;
                    case 25:
                        ViewBag.BandarTunHusseinOnn = x.TotalVisitor;
                        break;
                    case 26:
                        ViewBag.BatuSebelasCheras = x.TotalVisitor;
                        break;
                    case 27:
                        ViewBag.BukitDukung = x.TotalVisitor;
                        break;
                    case 28:
                        ViewBag.SungaiJernih = x.TotalVisitor;
                        break;
                    case 29:
                        ViewBag.StadiumKajang = x.TotalVisitor;
                        break;
                    case 30:
                        ViewBag.Kajang = x.TotalVisitor;
                        break;

                }

            }
            return View();
        }
        public IActionResult AdminDashboard(string SearchString = "", int page = 1)
        {
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");
            ViewBag.Search = SearchString;

            IList<MRTTicket> DetailList = GetList();
            int pageSize = 10;


            var searchResult = DetailList.Where(x => x.CustomerEmail.ToLower().Contains(SearchString.ToLower())||
                                x.CustomerName.Contains(SearchString.ToLower())).OrderByDescending(x=>x.PurchaseDateTime);
            var onePageList = searchResult.ToPagedList(page, pageSize);
            return View(onePageList);

        }

        public IActionResult Details(int id)
        {
            IList<MRTTicket> DetailList = GetList();
            var result = DetailList.First(x => x.Invoiceid == id);
            return View(result);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserEmail");
            HttpContext.Session.Remove("UserName");

            return View("AdminLogin");
        }

    }
}
