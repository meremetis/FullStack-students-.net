using System.Data.SqlClient;

namespace SevStudentsApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;


        //no instances of this class should be available
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                //pernaw mesa to connection apo to json
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
                //to kanw sxolia giati den thelw to conn string na einai mesa ston kodika gia logous asfalias
                /*string url = "Data Source=.\\sqlexpress;Initial Catalog=SevDB;Integrated Security=True";
                */
                conn = new SqlConnection(url);
                return conn;

            }
            catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static void CloseConnection() 
        {
            if (conn != null) 
            {
                conn.Close();
            }
        }
    }
}
