using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkeshPatelFullStackLib.dal
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "data source = DWARIKA; initial catalog = AlkeshPatelFullStack; integrated security = True; MultipleActiveResultSets = True;";
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {

            }
            return conn;
        } 
    }
}
