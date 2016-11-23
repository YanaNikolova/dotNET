using ND21_LogServer.Models.Projects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ND21_LogServer.ADOServices
{
    public class ADOProjectServices : IProjectServices
    {
        private string connectionString;

        public ADOProjectServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            var queryString = "SELECT Id, Name, Notes, Active FROM dbo.Projects ORDER BY Name";
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        });
                    }
                }
            }
            return projects;
        }

        public Project GetProject(int id)
        {
            Project project = new Project();
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand selectCmd = new SqlCommand("SELECT Id, Name, Active FROM dbo.Projects WHERE Id = @Id", connection);
                selectCmd.Parameters.AddWithValue("Id", id);
                connection.Open();
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        project = new Project
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        };
                    }
                    return project;
                }
            }
        }

        public bool SaveProject(Project project)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string updateString = "UPDATE Projects SET Name = @Name, Notes = @Notes, Active = @Active WHERE Id = @Id";
                SqlCommand selectCmd = new SqlCommand("SELECT Id FROM dbo.Projects WHERE LOWER(Name) = @Name ", conn);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.Projects(Name, Notes, Active) VALUES (@Name, @Notes, @Active)", conn);
                SqlCommand updateCmd = new SqlCommand(updateString, conn);
                selectCmd.Parameters.AddWithValue("@Name", project.Name);
                conn.Open();
                var id = selectCmd.ExecuteScalar();
                if (id != null && (int)id != project.ID)
                {
                    return false;
                }
                if (project.ID == 0)
                {
                    insertCmd.Parameters.AddWithValue("@Name", project.Name);
                    insertCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    insertCmd.Parameters.AddWithValue("@Active", project.Active);
                    insertCmd.ExecuteNonQuery();
                }
                else
                {
                    updateCmd.Parameters.AddWithValue("@Id", project.ID);
                    updateCmd.Parameters.AddWithValue("@Name", project.Name);
                    updateCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    updateCmd.Parameters.AddWithValue("@Active", project.Active);
                    updateCmd.ExecuteNonQuery();
                }
                /*if (selectCmd.ExecuteScalar() != null)
                {
                    return false;
                }
                if (project.ID == 0) // if id is different than 0 - the project is new so create it
                {
                    insertCmd.Parameters.AddWithValue("@Name", project.Name);
                    insertCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    insertCmd.Parameters.AddWithValue("@Active", project.Active);
                    insertCmd.ExecuteNonQuery();
                }
                else // this project already exists so edit it
                {
                    updateCmd.Parameters.AddWithValue("@Id", project.ID);
                    updateCmd.Parameters.AddWithValue("@Name", project.Name);
                    updateCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    updateCmd.Parameters.AddWithValue("@Active", project.Active);
                    updateCmd.ExecuteNonQuery();
                }if (selectCmd.ExecuteScalar() != null && project.ID > 0)
                {
                    // UPDATE
                    updateCmd.Parameters.AddWithValue("@Id", project.ID);
                    updateCmd.Parameters.AddWithValue("@Name", project.Name);
                    updateCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    updateCmd.Parameters.AddWithValue("@Active", project.Active);
                    updateCmd.ExecuteNonQuery();
                }
                if (selectCmd.ExecuteScalar() == null && project.ID == 0)
                {
                    // INSERT
                    insertCmd.Parameters.AddWithValue("@Name", project.Name);
                    insertCmd.Parameters.AddWithValue("@Notes", project.Notes);
                    insertCmd.Parameters.AddWithValue("@Active", project.Active);
                    insertCmd.ExecuteNonQuery();
                }*/
            }
            return true;
        }

        public IEnumerable<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            var queryString = "SELECT Id, ProjectId, Name, Notes, Active FROM dbo.Locations ORDER BY Name";
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        locations.Add(new Location
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ProjectId = reader.GetInt32(reader.GetOrdinal("ProjectId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        });
                    }
                }
            }
            return locations;
        }

        public Location GetLocation(int id)
        {
            Location location = new Location();
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand selectCmd = new SqlCommand("SELECT Id, ProjectId, Name, Notes, Active FROM dbo.Locations WHERE Id = @Id", connection);
                selectCmd.Parameters.AddWithValue("Id", id);
                connection.Open();
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        location = new Location
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ProjectId = reader.GetInt32(reader.GetOrdinal("ProjectId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        };
                    }
                    return location;
                }
            }
        }

        public bool SaveLocation(Location location)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string updateString = "UPDATE dbo.Locations SET Name = @Name, Notes = @Notes, Active = @Active WHERE Id = @Id";
                SqlCommand selectCmd = new SqlCommand("SELECT Name FROM dbo.Locations WHERE LOWER(Name) = @Name ", conn);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.Locations(Name, ProjectId, Notes, APIKey, Active) VALUES (@Name, @ProjectId, @Notes, NEWID(), @Active)", conn);
                SqlCommand updateCmd = new SqlCommand(updateString, conn);
                //selectCmd.Parameters.AddWithValue("Id", project.ID);
                selectCmd.Parameters.AddWithValue("@Name", location.Name);
                conn.Open();
                if (selectCmd.ExecuteScalar() != null)
                {
                    return false;
                }
                if (location.Id == 0) // if id is different than 0 - the project is new so create it
                {
                    insertCmd.Parameters.AddWithValue("@Name", location.Name);
                    insertCmd.Parameters.AddWithValue("@ProjectId", location.ProjectId);
                    insertCmd.Parameters.AddWithValue("@Notes", location.Notes);
                    //insertCmd.Parameters.AddWithValue("@APIKey", NEWID(););
                    insertCmd.Parameters.AddWithValue("@Active", location.Active);
                    insertCmd.ExecuteNonQuery();
                }
                else // this project already exists so edit it
                {
                    updateCmd.Parameters.AddWithValue("@Id", location.Id);
                    updateCmd.Parameters.AddWithValue("@Name", location.Name);
                    updateCmd.Parameters.AddWithValue("@Notes", location.Notes);
                    updateCmd.Parameters.AddWithValue("@Active", location.Active);
                    updateCmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}