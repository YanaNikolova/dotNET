using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND21_LogServer.Models.Projects
{
    public interface IProjectServices
    {
        IEnumerable<Project> GetProjects();

        Project GetProject(int id);

        bool SaveProject(Project project);

        IEnumerable<Location> GetLocations();

        Location GetLocation(int id);

        bool SaveLocation(Location location);
    }
}
