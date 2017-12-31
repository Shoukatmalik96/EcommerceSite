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
            getCategory();
            FillBySup();
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

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                CatWiseProduct a = new CatWiseProduct();
                a.CategoryName = re["CategoryName"].ToString();
                a.noofproduct = int.Parse(re["noofproduct"].ToString());

                items.Add(a);

            }
            re.Close();
            conn.Close();
            ViewBag.Cat = items;

        }
        public void FillBySup()
        {

            // Creating Supplier List
            List<Supplier> items = new List<Supplier>();
            // Creating Sql connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            conn.Open();
            // Creating SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM Suppliers";

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Supplier  a    = new  Supplier();
                a.CompanyName = re["CompanyName"].ToString();
                a.SupplierID  = int.Parse(re["SupplierID"].ToString());

                items.Add(a);

            }
            re.Close();
            conn.Close();
            ViewBag.SupRec = items;
        }
        public void FillbYProduct()
        {

            // Creating ProductView List
            List<ProductView> items = new List<ProductView>();
            // Creating Sql connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            conn.Open();
            // Creating SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM ProductView";

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                ProductView a     = new ProductView();
                a.ProductID       = int.Parse(re["ProductId"].ToString());
                a.ProductName     = re["ProductName"].ToString();
                a.CategoryName    = re["CategoryName"].ToString();
                a.CompanyName     = re["CompanyName"].ToString();
                a.QuantityPerUnit = re["QuantityPerUnit"].ToString();
                a.UnitPrice       = decimal.Parse(re["UnitPrice"].ToString());
                a.image           = re["image"].ToString();
                a.ProductName     = re["ProductName"].ToString();

                items.Add(a);

            }
            re.Close();
            conn.Close();
            ViewBag.SupRec = items;
        }
        
    }
}
    
