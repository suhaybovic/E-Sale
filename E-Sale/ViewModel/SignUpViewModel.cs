using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Sale.Models;
using System.Web.Mvc;

namespace E_Sale.ViewModel
{
    public class SignUpViewModel
    {
        public string Name { get; set; }
        public Field field { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}