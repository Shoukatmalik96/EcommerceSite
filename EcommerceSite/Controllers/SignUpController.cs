using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EcommerceSite.Models;
using System.Net.Mail;
using System.Web.Security;

namespace EcommerceSite.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            FillByCountry();
            FillByCity();
            return View();
        }
        public void FillByCountry()
        {

            // Creating Country List
            List<COUNTRY> items = new List<COUNTRY>();
            // Creating Sql connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            conn.Open();
            // Creating SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM COUNTRY";

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                COUNTRY a = new COUNTRY();
                a.COUNTRY_NAME = re["COUNTRY_NAME"].ToString();
                a.COUNTRY_ID = int.Parse(re["COUNTRY_ID"].ToString());

                items.Add(a);

            }
            re.Close();
            conn.Close();
            ViewBag.Country = items;
        }
        public void FillByCity()
        {

            // Creating Country List
            List<CITY> items = new List<CITY>();
            // Creating Sql connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            conn.Open();
            // Creating SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM CITY";

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                CITY a = new CITY();
                a.CITY_NAME = re["CITY_NAME"].ToString();
                a.CITY_ID = int.Parse(re["CITY_ID"].ToString());

                items.Add(a);

            }
            re.Close();
            conn.Close();
            ViewBag.CITY = items;
        }
    //    [HttpPost]
    //    public ActionResult SignUp(Registration model, string country, string city)
    //    {
    //        getCountry();
    //        getCity();

    //        if (ModelState.IsValid)
    //        {
    //            SqlConnection con = new SqlConnection();
    //            con.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
    //            con.Open();

    //            SqlCommand cmd = new SqlCommand();
    //            cmd.Connection = con;
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.CommandText = "usp_Insert_CUSTOMER";
    //            // Add the input parameter and set its value 

    //            SqlParameter param_CUSTOMER_NAME = new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar, 100);
    //            SqlParameter param_EMAIL_ID = new SqlParameter("@EMAIL_ID", SqlDbType.VarChar, 50);
    //            SqlParameter param_COUNTRY_ID = new SqlParameter("@COUNTRY_ID", SqlDbType.Int, 10);
    //            SqlParameter param_CITY_ID = new SqlParameter("@CITY_ID", SqlDbType.Int, 10);
    //            SqlParameter param_PIN_CODE = new SqlParameter("@PIN_CODE", SqlDbType.VarChar, 50);
    //            SqlParameter param_KEYWORD = new SqlParameter("@KEYWORD", SqlDbType.VarChar, 50);
    //            SqlParameter param_ADDRESS = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 10);
    //            SqlParameter param_USER_NAME = new SqlParameter("@USER_NAME", SqlDbType.VarChar, 50);
    //            SqlParameter param_PASSWORD = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50);
    //            SqlParameter param_MEM_TYPE = new SqlParameter("@MEM_TYPE", SqlDbType.VarChar, 50);
    //            SqlParameter param_ACTIVE = new SqlParameter("@ACTIVE", SqlDbType.VarChar, 50);
    //            SqlParameter param_CUSTOMER_ID = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int, 10);
    //            SqlParameter param_UNEMAIL_ID = new SqlParameter("@UNEMAIL_ID", SqlDbType.VarChar, 100);

    //            param_CUSTOMER_NAME.Value = model.UserName;
    //            param_EMAIL_ID.Value = model.EMAIL_ID;
    //            param_COUNTRY_ID.Value = country;
    //            param_CITY_ID.Value = city;
    //            param_PIN_CODE.Value = model.PIN_CODE;
    //            param_KEYWORD.Value = model.KEYWORD;
    //            param_ADDRESS.Value = model.ADDRESS;
    //            param_USER_NAME.Value = model.EMAIL_ID;

    //            string Hashpass = FormsAuthentication.HashPasswordForStoringInConfigFile(
    //                               model.PASSWORD, "sha1");

    //            param_PASSWORD.Value = Hashpass;

    //            param_MEM_TYPE.Value = "M".ToString();
    //            param_ACTIVE.Value = "Inactive".ToString();
    //            //param_DOB.Value = this.txtDOB.Text + " 00:00:00 AM".ToString();
    //            // Add the output parameter and set its direction 
    //            param_CUSTOMER_ID.Direction = ParameterDirection.Output;
    //            param_UNEMAIL_ID.Direction = ParameterDirection.Output;

    //            //add paramaemter in command
    //            cmd.Parameters.Add(param_CUSTOMER_NAME);
    //            cmd.Parameters.Add(param_EMAIL_ID);
    //            cmd.Parameters.Add(param_COUNTRY_ID);
    //            cmd.Parameters.Add(param_CITY_ID);
    //            cmd.Parameters.Add(param_PIN_CODE);
    //            cmd.Parameters.Add(param_KEYWORD);
    //            cmd.Parameters.Add(param_ADDRESS);
    //            cmd.Parameters.Add(param_USER_NAME);
    //            cmd.Parameters.Add(param_PASSWORD);

    //            cmd.Parameters.Add(param_MEM_TYPE);
    //            cmd.Parameters.Add(param_ACTIVE);
    //            cmd.Parameters.Add(param_CUSTOMER_ID);
    //            cmd.Parameters.Add(param_UNEMAIL_ID);

    //            int noofrec;

    //            noofrec = cmd.ExecuteNonQuery();

    //            if (noofrec > 0)
    //            {
    //                SendEmail(model.KEYWORD, model.EMAIL_ID, model.UserName, model.ADDRESS, model.ADDRESS);
    //                ViewBag.Msg = "Record has been saved";
    //            }
    //            else
    //            {
    //                ViewBag.Msg = "Email ID already exist plz choose different";
    //            }
    //        }

    //        return View(model);
    //    }

    //    private void getCountry()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void getCity()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void SendEmail(string code, string email, string name, string nic, string address)
    //    {
    //        string strHtml = "";

    //        string mail_email = "majidtahir2012@gmail.com";
    //        string mail_pass = "yarehman";
    //        string mail_smtp = "smtp.gmail.com";
    //        int mail_smtpport = 587;

    //        string webadd = "http://localhost:49479/Activate?CODE=" + code + "&EMAIL=" + email;
    //        /////////////////////////////////////////////////SMTP Settings///////////////////////
    //        SmtpClient client = new SmtpClient(mail_smtp, mail_smtpport);

    //        client.EnableSsl = true;

    //        MailAddress from = new MailAddress(mail_email, "Administrator");

    //        MailAddress to = new MailAddress(email, name);

    //        MailMessage message = new MailMessage(from, to);

    //        message.IsBodyHtml = true;

    //        strHtml = "<div >" +
    //                    "<center>" +
    //                      "<font size='3'>" +
    //                        "<b><u>Registration Information</u></b>" +
    //                      "</font>" +
    //                    "</center>" +

    //                  "<br><br><br>" +

    //                  "Dear " + name + "," +

    //                  "<br><br>We are pleased to inform you that ABC intends to register following information from their bio data<br><br>" +
    //                  "<b>NIC No. : </b>" + nic + "<br>" +
    //                  "<b>Address : </b>" + address + "<br>" +
    //                  "<br>" +
    //                  "<center>" +
    //                    "<a href='" + webadd + "'>" +
    //                        "Kindly visit our website for activation" +
    //                     "</a>" +
    //                   "</center>" +

    //                  "</li>" +
    //                  "<br>Regards," +
    //                  "<br>Registration System," +
    //                  "<br><br>" +
    //                    "<I>Please do not reply to this email. This is a computer generated message and hence requires no signature</I>" +
    //               "</div>";

    //        message.Body = strHtml;

    //        message.Subject = "Login Activation";

    //        System.Net.NetworkCredential myCreds = new System.Net.NetworkCredential(mail_email, mail_pass, "");

    //        client.Credentials = myCreds;
    //        /////////////////////////////////////////////////////////////////////////////////////
    //        try
    //        {
    //            client.Send(message);

    //        }

    //        catch (Exception ex)
    //        {


    //        }
    //    }
    }
}