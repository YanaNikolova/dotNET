using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TVSeriesCalendar_3.Models
{
    public interface IShow
    {
        IEnumerable<Show> FindAllShowsByName(string showName);
        Show FindShowByName(string showName);
        Show FindShowById(int id);
        void AddToFavorites(int Id);
        IEnumerable<int> GetUserFavoriteShows();
        IEnumerable<ShowViewModel> GetTopRatedTvShows();
        IEnumerable<ShowViewModel> GetPopularTvShows();
        IEnumerable<ShowViewModel> GetAiringTodayShows();
        JsonResult LoadEventsIntoCalendar();
        //void GetShowSeasons(int id);
        IEnumerable<Episode> GetEpisodes();
        //Show GetShowId(Show show);
    }
}
