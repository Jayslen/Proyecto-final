using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BookingEntity
    {
        public String id { get; set; }
        public String date { get; set; }
        public String service { get; set; }
        public String state { get; set; }
        public String userName { get; set; }
    }

    public class UserEntity
    {
        public String id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String rol { get; set; }
    }
    }
