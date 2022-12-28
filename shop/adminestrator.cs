using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{

    internal class adminestrator
    {
        public int id { get; set; }

        public string log_in { get; set; }


        public string password { get; set; }

        public roles_enum roles_Enum { get; set; }

        public adminestrator(int id, string log_in, string password, roles_enum roles_Enum)
        {
            this.id = id;
            this.log_in = log_in;
            this.password = password;
            this.roles_Enum = roles_Enum;
        }
    }
}