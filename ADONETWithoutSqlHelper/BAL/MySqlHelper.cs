using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ADONETWithoutSqlHelper.BAL
{
    
    public sealed class MySqlHelper
    {
        SqlConnection MyConn;
        public static string ConnectionString
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ADOCNN"].ConnectionString;
                return connectionString;    
            }



        }

       



    }
}
