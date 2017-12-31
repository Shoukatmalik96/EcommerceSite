using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceSite.Models
{
    public class Registration
    {
        internal readonly object UserName;

        [Display(Name = "Enter Name")]
        [Required(ErrorMessage = "Please enter Name")]
        public string CUSTOMER_NAME
        {
            get;
            set;
        }

        [Display(Name = "Enter Email")]
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string EMAIL_ID
        {
            get;
            set;
        }

        ////REMOTE VALIDATION      
        //[Required(ErrorMessage = "Please enter your email address")]
        //[RegularExpression(".+\\@.+\\..+",
        //ErrorMessage = "Please enter a valid email address")]
        //[DataType(DataType.EmailAddress)]
        //[Remote("CheckUserName", "Login")]
        //public string EMAIL_ID
        //{
        //    get;
        //    set;
        //}

        [Display(Name = "Enter PIN")]
        [Required(ErrorMessage = "Please enter PIN_CODE")]
        public int PIN_CODE
        {
            get;
            set;
        }

        [Display(Name = "Enter KeyWord")]
        [Required(ErrorMessage = "Please enter KEYWORD")]
        public string KEYWORD
        {
            get;
            set;
        }


        [Display(Name = "Enter Address")]
        [Required(ErrorMessage = "Please enter ADDRESS")]
        public string ADDRESS
        {
            get;
            set;
        }


        [Display(Name = "Select Country Name")]
        public int COUNTRY_ID
        {
            get;
            set;
        }



        [Display(Name = "Select City Name")]
        public int CITY_ID
        {
            get;
            set;
        }

        [Display(Name = "Enter Password")]
        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(10, ErrorMessage = "The PASSWORD must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]

        public string PASSWORD
        {
            get;
            set;
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        // [Compare("PASSWORD", ErrorMessage = "The password and confirmation password do not match.")]
        public string CPASSWORD
        {
            get;
            set;
        }

        // FOR Self-Validating Models

        //[DataType(DataType.Date)]
        //public DateTime Date 
        //{ 
        //    get; 
        //    set; 
        //}

        //Remote Validation
        //[DataType(DataType.Date)]
        //[Remote("ValidateDate", "Login")]
        //public DateTime Date
        //{
        //    get;
        //    set;
        //}


        public bool TermsAccepted
        {
            get;
            set;
        }


    }
}