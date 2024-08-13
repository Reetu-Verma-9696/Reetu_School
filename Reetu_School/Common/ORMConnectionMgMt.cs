using System.Data.SqlClient;

namespace Reetu_School.Common
{
    public class ORMConnectionMgMt
    {
        private static SqlConnection con;
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection(MyConnection.DefaultConnection);
            return con;
        }
    }
    public static class MyConnection
    {
        public static string DefaultConnection { get; set; }
    }
    public class ORMConnection
    {
        private static SqlConnection con;
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection(MyConnection.DefaultConnection  );
            return con;
        }
    }
}
