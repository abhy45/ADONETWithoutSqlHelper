using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETWithoutSqlHelper.BAL.Model
{
    public class userModel
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public string RememberMe { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
