using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    public class DataBaseLogger : ILogger
    {
        public LoggerResponse LogMessage(Message message)
        {
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConeBD"].ToString()))
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "INS_LogMessage",
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@@prmMessage", SqlDbType = SqlDbType.VarChar, Value = message.Content });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@@prmType", SqlDbType = SqlDbType.Int, Value = (int)message.MessageType });
                    cmd.Connection = myConnection;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                    return new LoggerResponse(LogType.DataBase);
                }
                catch(Exception ex)
                {
                    return new LoggerResponse(LogType.DataBase, ex);
                }
                finally
                {
                    if (myConnection.State != ConnectionState.Closed)
                    {
                        myConnection.Close();
                    }
                }
            }
        }
    }
}