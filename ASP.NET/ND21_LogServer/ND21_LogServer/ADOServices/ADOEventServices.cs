using ND21_LogServer.Models.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ND21_LogServer.ADOServices
{
    public class ADOEventServices : IEventServices
    {
        private string connectionString;

        public ADOEventServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<ExtendedEvent> GetEvents(DateTime fromDate, DateTime toDate, int projectID, bool errorsOnly)
        {
            List<ExtendedEvent> events = new List<ExtendedEvent>();
            using (var connection = new SqlConnection(connectionString))
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("SELECT e.Id, e.Timestamp, e.Type, e.Message, l.Id, l.Name AS LocationName, p.Id, p.Name AS ProjectName ");
                strBuilder.Append("FROM dbo.Events AS e, dbo.Locations AS l, dbo.Projects AS p ");
                strBuilder.Append("WHERE e.Timestamp BETWEEN @FromDate AND @ToDate ");
                strBuilder.Append("AND ((@TypeFilter is null) OR (e.Type = @TypeFilter)) ");
                strBuilder.Append("AND ((@ProjectId is null) OR (p.Id = @ProjectId)) ");
                strBuilder.Append("AND e.LocationId = l.Id AND p.Id = l.ProjectId ");
                strBuilder.Append("ORDER BY Timestamp ");
                SqlCommand cmd = new SqlCommand(strBuilder.ToString(), connection);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                cmd.Parameters.AddWithValue("@ProjectId", projectID);
                cmd.Parameters.AddWithValue("@TypeFilter", errorsOnly ? 1 : (object)DBNull.Value);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new ExtendedEvent
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Timestamp")),
                            Type = reader.GetInt32(reader.GetOrdinal("Type")),
                            Message = reader.GetString(reader.GetOrdinal("Message")),
                            Location = reader.GetString(reader.GetOrdinal("LocationName")),
                            Project = reader.GetString(reader.GetOrdinal("ProjectName"))
                        });
                    }
                }
            }
            return events;
        }
    }
}