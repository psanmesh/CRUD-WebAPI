using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDBConnector
{
    public class DBConnection
    {
        private SqlConnection SqlConn = null;
        public SqlConnection GetConnection
        {
            get { return SqlConn; }
            set { SqlConn = value; }
        }

        //start: defines connection to the sql server, add this connection to the webconfig file
        public DBConnection()
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            SqlConn = new SqlConnection(ConnectionString);
        }
        //End: d
    }
}
