using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesCalendar.Models
{
    public interface IShow
    {
        IEnumerable<Show> FindAllShowsByName(string showName);
        Show FindShowByName(string showName);
        Show FindShowById(int id);
        void AddToFavorites(int Id);
        //Show GetShowId(Show show);
    }
}
