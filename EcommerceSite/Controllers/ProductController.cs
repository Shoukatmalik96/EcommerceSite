using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EcommerceSite.Models;

namespace EcommerceSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchProduct()
        {
            return View();
        }
        public void getCategory()
        {
            // Creating CatwiseProductList
            List<CatWiseProduct> items = new List<CatWiseProduct>();
            // Creating Sql connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            conn.Open();
            // Creating SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM CatWiseProduct";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CatWiseProduct a = new CatWiseProduct();
                a.CategoryName = reader["CategoryName"].ToString();
                a.noofproduct = int.Parse(reader["noofproduct"].ToString());

                items.Add(a);
            }

            ViewBag.Cat = items;
        }
    }
}
    
