﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class Post
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Text { get; set; }
        public Nullable<int> PhotoID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual User User { get; set; }
    }
}
