using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleanCode.LongMethods
{
    public class DataSource
    {
        public DataTable ReadFromDataTable(string tableName)
        {
            string strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tableName} ORDER BY id ASC", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            DataTable dt = ds.Tables[tableName];
            return dt;
        }
    }
}