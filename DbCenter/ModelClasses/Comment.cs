using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class Comment
    {
        public string ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> PostID { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
