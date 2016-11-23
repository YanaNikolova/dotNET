using ND21_LogServer.Models.Events;
using ND21_LogServer.Models.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ND21_LogServer.ADOServices
{
    public class ADOLogServices : ILogServices
    {
        private string connectionString;

        public ADOLogServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AppendEvent(Event ev)
        {
            var ApiKey = ev.ApiKey;
            if (ApiKey == null)
            {
                return false;
            }
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand selectCmd = new SqlCommand("SELECT Id FROM dbo.Locations WHERE Id = @ApiKey ORDER BY Name ", connection);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.Events(Id, Timestamp, Type, Message, LocationId) VALUES (@Id, @Timestamp, @Type, @Message, @LocationId)", connection);
                connection.Open();
                if (selectCmd.ExecuteScalar() != null)
                {
                    return false;
                }
                selectCmd.Parameters.AddWithValue("@LocationId", ev.ApiKey);
                insertCmd.Parameters.AddWithValue("@Id", ev.Id);
                insertCmd.Parameters.AddWithValue("@Timestamp", ev.Date);
                insertCmd.Parameters.AddWithValue("@Type", ev.Type);
                insertCmd.Parameters.AddWithValue("@Message", ev.Message);
                insertCmd.ExecuteNonQuery();

                return true;
            }
        }

        public bool AppendEvent(IEnumerable<Event> events)
        {
            foreach (var ev in events)
            {
                var ApiKey = ev.ApiKey;
                if (ApiKey == null)
                {
                    return false;
                }
                using (var connection = new SqlConnection(connectionString))
                {

                    SqlCommand selectCmd = new SqlCommand("SELECT Id FROM dbo.Locations WHERE APIKey = @ApiKey ORDER BY Name ", connection);
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.Events(Timestamp, Type, Message, LocationId) VALUES (@Timestamp, @Type, @Message, @LocationId)", connection);
                    selectCmd.Parameters.AddWithValue("@ApiKey", ev.ApiKey);
                    connection.Open();
                    if (selectCmd.ExecuteScalar() == null)
                    {
                        return false;
                    }
                    insertCmd.Parameters.AddWithValue("@Timestamp", ev.Date);
                    insertCmd.Parameters.AddWithValue("@Type", ev.Type);
                    insertCmd.Parameters.AddWithValue("@Message", ev.Message);
                    insertCmd.Parameters.AddWithValue("@LocationId", 2);
                    insertCmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}