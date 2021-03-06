﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> ProfilePhotoID { get; set; }
        public Nullable<int> AddressID { get; set; }

        public virtual MVCAddress Address { get; set; }
        public virtual MVCPhoto ProfilePhoto { get; set; }
    }
}