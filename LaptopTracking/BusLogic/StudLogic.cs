using LaptopTracking.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace LaptopTracking.BusLogic
{
    public class StudLogic
    {
        static SqlConnection con;
        static int created = 0;

        //get all products
        public static DataTable GetUserLogData(string CDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    string Query = " SELECT R1.[USER] As UserId,R1.Host,CAST(CAST(FISTlOGIN AS DATE) AS varchar) AS [Date],FISTlOGIN,LASTLOGOFF,CONVERT(varchar,LASTLOGOFF-FISTlOGIN,8) As TotalActiveTime FROM ( ";
                    Query += " SELECT Host,[USER],MIN(tIME) AS FISTlOGIN FROM USERLOG ";
                    Query += " WHERE cast(Time as date)=@Date AND Event=0 ";
                    Query += " GROUP BY Host,[USER]) as R1 ";
                    Query += " JOIN ( ";
                    Query += " SELECT Host,[USER],MAX(tIME) AS LASTLOGOFF FROM USERLOG  ";
                    Query += " WHERE cast(Time as date)=@Date AND Event=3 ";
                    Query += " GROUP BY Host,[USER]) as R2 on R1.[User]=R2.[User]";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", CDate ?? DateTime.Now.ToShortDateString()));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static DataTable GetUserBreachData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    string Query = " SELECT * FROM (";
                    Query += " SELECT ITS_Number,TRNO UserCode,Fullname,IP_Address,Laptop_Model,Host,convert(varchar, MAX(tIME), 20) times";
                    Query += " FROM Student S";
                    Query += " JOIN USERLOG U ON S.TRNO=U.[User]";
                    Query += " GROUP BY  ITS_Number,TRNO,Fullname,IP_Address,Laptop_Model,Host) As Result";
                    Query += " where times<=dateadd(d,-6,GETDATE())";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@Date", CDate ?? DateTime.Now.ToShortDateString()));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static DataTable GetAppLogData(string CDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    string Query = "sp_AppLog";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", CDate ?? DateTime.Now.ToShortDateString()));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

    }
}
