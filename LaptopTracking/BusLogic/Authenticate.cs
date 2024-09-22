using LaptopTracking.Helpers;
using LaptopTracking.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace LaptopTracking.BusLogic
{
    public class Authenticate
    {
        static SqlConnection con;
        static int created = 0;
        //get all accounts created
        public static DataTable GetUserLogData(string Password, string Email)
        {
            DataTable dtUsers = new DataTable();
            try
            {

                dtUsers.Rows.Clear();
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("select UserID,FirstName + ' ' +	Surname as FullName,Email,Theme from UserMaster where Email=@Email AND Password=@Password", con);
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dtUsers);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return dtUsers;
        }

    }
}
