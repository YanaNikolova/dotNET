using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMDbLib.Client;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.Mvc;

namespace TVSeriesCalendar_3.Models
{
    public class ShowServices : IShow
    {
        private string connectionString;

        public ShowServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Show FindShowByName(string showName)
        {
            Dictionary<int, int> seasonsAndEpisodes = new Dictionary<int, int>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.TvShows.TvShow latestOnAir = client.GetLatestTvShow(); //any TV show that has an episode with an air date in the next 7 days.
            IEnumerable<TMDbLib.Objects.Search.SearchTv> tvshows = client.SearchTvShow(showName, 1).Results;
            TMDbLib.Objects.Search.SearchTv show = tvshows.First();
            string overview = client.GetTvShow(show.Id).Overview;
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> similarTV = client.GetTvShowSimilar(show.Id);
            for (var i = 1; i < 5; i++)
            {
                TMDbLib.Objects.TvShows.TvSeason seasons = client.GetTvSeason(show.Id, i);
                if (!seasonsAndEpisodes.ContainsKey(seasons.SeasonNumber))
                {
                    seasonsAndEpisodes.Add(seasons.SeasonNumber, seasons.EpisodeCount);
                }
                else
                {
                    break;
                }
            }
            Show newShow = new Show
            {
                Name = show.Name,
                ID = show.Id,
                PosterPath = client.GetImageUrl("w185", show.PosterPath, false),
                FirstAirDate = show.FirstAirDate.Value,
                OriginalName = show.OriginalName,
                OriginCountry = show.OriginCountry.First(),
                Popularity = show.Popularity,
                VoteAverage = show.VoteAverage,
                Overview = overview,
                SimilarTVShows = similarTV,
                SeasonsAndEpisodes = seasonsAndEpisodes 
            };
            TMDbLib.Objects.TvShows.TvSeason season = client.GetTvSeason(newShow.ID, 0);
            return newShow;
        }

        public IEnumerable<Show> FindAllShowsByName(string showName)
        {
            List<Show> showResults = new List<Show>();
            Dictionary<int, int> seasonsInfo = new Dictionary<int, int>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            IEnumerable<TMDbLib.Objects.Search.SearchTv> tvshows = client.SearchTvShow(showName, 1).Results;
            foreach (var show in tvshows)
            {
                for(var i=1; i <5; i++)
                {
                    TMDbLib.Objects.TvShows.TvSeason season = client.GetTvSeason(show.Id, i);
                    if (!seasonsInfo.ContainsKey(season.SeasonNumber))
                    {
                        seasonsInfo.Add(season.SeasonNumber, season.EpisodeCount);
                    }
                    else
                    {
                        break;
                    }
                }
                showResults.Add(new Show { Name = show.Name, ID = show.Id, PosterPath = client.GetImageUrl("w185", show.PosterPath, false), SeasonsAndEpisodes = seasonsInfo });
            }
            return showResults;
        }

        public Show FindShowById(int id)
        {
            List<Season> seasonList = new List<Season>();
            Dictionary<int, int> seasonsAndEpisodes = new Dictionary<int, int>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.Search.SearchTv show = client.GetTvShow(id);
            string overview = client.GetTvShow(show.Id).Overview;
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> similarTV = client.GetTvShowSimilar(show.Id);
            int seasonCounter = 1;
            TMDbLib.Objects.TvShows.TvSeason season = client.GetTvSeason(show.Id, seasonCounter);
            do
            {
                season = client.GetTvSeason(show.Id, seasonCounter);
                if (!seasonsAndEpisodes.ContainsKey(season.SeasonNumber) && season.SeasonNumber != 0)
                {
                    seasonList.Add(new Season
                    {
                        Id = season.Id.Value,
                        ShowName = show.Name,
                        SeasonNumber = season.SeasonNumber,
                        EpisodeCount = season.EpisodeCount,
                        AirDate = season.AirDate.Value,
                        Overview = season.Overview,
                        PosterPath = season.PosterPath
                    });
                    seasonsAndEpisodes.Add(season.SeasonNumber, season.EpisodeCount);
                    seasonCounter++;
                }
            }
            while(season.Id != null);

            Show newShow = new Show
            {
                ID = show.Id,
                Name = show.Name,
                FirstAirDate = show.FirstAirDate.Value,
                OriginalName = show.OriginalName,
                //OriginCountry = show.OriginCountry.First(),
                Popularity = show.Popularity,
                VoteAverage = show.VoteAverage,
                Overview = overview,
                SimilarTVShows = similarTV,
                PosterPath = client.GetImageUrl("w185", show.PosterPath, false),
                SeasonsAndEpisodes = seasonsAndEpisodes 
            };
            return newShow;
        }

        public void AddToFavorites(int id)
        {
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            if( currentUserId != "")
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO dbo.FavoriteTvShows(ShowId, UserId, Name, PosterPath, AirDate) VALUES (@ShowId, @UserId, @Name, @PosterPath, @AirDate)", conn);
                    SqlCommand selectCmd = new SqlCommand("SELECT Name FROM dbo.FavoriteTvShows WHERE ShowId = @ShowId ", conn);
                    selectCmd.Parameters.AddWithValue("@ShowId", id);
                    conn.Open();
                    if (selectCmd.ExecuteScalar() == null)
                    {
                        command.Parameters.AddWithValue("@ShowId", id);
                        command.Parameters.AddWithValue("@UserId", currentUserId);
                        command.Parameters.AddWithValue("@Name", "MyTVShow");
                        command.Parameters.AddWithValue("@PosterPath", "//path");
                        command.Parameters.AddWithValue("@AirDate", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
            
        }

        public IEnumerable<int> GetUserFavoriteShows()
        {
            List<int> showIds = new List<int>();
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            if (currentUserId != null)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT ShowId FROM dbo.FavoriteTvShows WHERE UserId = @currentUserId ", conn);
                    command.Parameters.AddWithValue("@currentUserId", currentUserId);
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            showIds.Add(reader.GetInt32(reader.GetOrdinal("ShowId")));
                        }
                    }
                }
                
            }
            return showIds;
        }
        public IEnumerable<ShowViewModel> GetTopRatedTvShows()
        {
            List<ShowViewModel> listTopRatedShows = new List<ShowViewModel>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> topRatedShows = client.GetTvShowTopRated();
            foreach(var show in topRatedShows.Results)
            {
                listTopRatedShows.Add(new ShowViewModel
                {
                    ID = show.Id,
                    Name = show.Name,
                    FirstAirDate = show.FirstAirDate.Value,
                    OriginalName = show.OriginalName,
                    Popularity = show.Popularity,
                    VoteAverage = show.VoteAverage,
                    PosterPath = client.GetImageUrl("w185", show.PosterPath, false),
                    TopRatedShows = listTopRatedShows
                });
            }
            return listTopRatedShows;
        }

        public IEnumerable<ShowViewModel> GetPopularTvShows()
        {
            List<ShowViewModel> listPopularShows = new List<ShowViewModel>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> popularShows = client.GetTvShowPopular();
            var list = client.GetTvShowList(TMDbLib.Objects.Movies.TvShowListType.AiringToday);
            foreach (var show in popularShows.Results)
            {
                listPopularShows.Add(new ShowViewModel
                {
                    ID = show.Id,
                    Name = show.Name,
                    FirstAirDate = show.FirstAirDate.Value,
                    OriginalName = show.OriginalName,
                    Popularity = show.Popularity,
                    VoteAverage = show.VoteAverage,
                    PosterPath = client.GetImageUrl("w185", show.PosterPath, false),
                    PopularShows = listPopularShows
                });
            }
            return listPopularShows;
        }

        public IEnumerable<ShowViewModel> GetAiringTodayShows()
        {
            List<ShowViewModel> listAiringTodayShows = new List<ShowViewModel>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.TvShows.TvShow> airingTodayShows = client.GetTvShowList(TMDbLib.Objects.Movies.TvShowListType.AiringToday);
            foreach (var show in airingTodayShows.Results)
            {
                listAiringTodayShows.Add(new ShowViewModel
                {
                    ID = show.Id,
                    Name = show.Name,
                    FirstAirDate = show.FirstAirDate.Value,
                    OriginalName = show.OriginalName,
                    Popularity = show.Popularity,
                    VoteAverage = show.VoteAverage,
                    PosterPath = client.GetImageUrl("w185", show.PosterPath, false),
                    PopularShows = listAiringTodayShows
                });
            }
            return listAiringTodayShows;
        }

        public JsonResult LoadEventsIntoCalendar()
        {
            return null;
        }

       /* public void GetShowSeasons(int id)
        {
            Dictionary<int, string> seasonsAndEpisodes = new Dictionary<int, string>();
            List<ShowViewModel> listAiringTodayShows = new List<ShowViewModel>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            
            for(var i=0; i<30; i++)
            {
                TMDbLib.Objects.TvShows.TvSeason season = client.GetTvSeason(id, i);
                //seasonsAndEpisodes.Add(id, )
            }
        } */

        public IEnumerable<Episode> GetEpisodes()
        {
            throw new NotImplementedException();
        }
    }
}