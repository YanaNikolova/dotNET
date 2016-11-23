using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMDbLib.Client;
using TMDbLib.Objects.General;

namespace TVSeriesCalendar.Models
{
    public class IndexServices : IShow
    {
        private string connectionString;

        public IndexServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Show FindShowByName(string showName)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            IEnumerable<TMDbLib.Objects.Search.SearchTv> tvshows = client.SearchTvShow(showName, 1).Results;
            TMDbLib.Objects.Search.SearchTv show = tvshows.First();
            string overview = client.GetTvShow(show.Id).Overview;
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> similarTV = client.GetTvShowSimilar(show.Id);
            Show newShow = new Show{
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
                
            };
            return newShow;
        }

        public IEnumerable<Show> FindAllShowsByName(string showName)
        {
            List<Show> showResults = new List<Show>();
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            IEnumerable<TMDbLib.Objects.Search.SearchTv> tvshows = client.SearchTvShow(showName, 1).Results;
            foreach(var show in tvshows)
            {
                showResults.Add(new Show { Name = show.Name, ID = show.Id, PosterPath = client.GetImageUrl("w185", show.PosterPath, false)});
            }
            return showResults;
        }

        public Show FindShowById(int id)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            TMDbLib.Objects.Search.SearchTv show = client.GetTvShow(id);
            string overview = client.GetTvShow(show.Id).Overview;
            TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> similarTV = client.GetTvShowSimilar(show.Id);
            Show newShow = new Show {
                ID = show.Id,
                Name = show.Name,
                FirstAirDate = show.FirstAirDate.Value,
                OriginalName = show.OriginalName,
                //OriginCountry = show.OriginCountry.First(),
                Popularity = show.Popularity,
                VoteAverage = show.VoteAverage,
                Overview = overview,
                SimilarTVShows = similarTV,
                PosterPath = client.GetImageUrl("w185", show.PosterPath, false)
            };
            return newShow;
        }

        public void AddToFavorites(int id)
        {
            var usID = 1;
            using(var conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE usr.Users SET FavoriteTvShows = @FavoriteTvShows WHERE Id = @usID", conn);
                conn.Open();
                command.Parameters.AddWithValue("@usID", usID);
                command.Parameters.AddWithValue("@FavoriteTVShows", id);
                command.ExecuteNonQuery();
            }
        }

       /* public void AddToFavorites(int Id)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            client.GetConfig();
            var session = client.AuthenticationGetUserSession("yana.nikolova", "tir3311tiri1");
            client.SetSessionInformation(session.SessionId, TMDbLib.Objects.Authentication.SessionType.UserSession);
            var account = client.AccountChangeFavoriteStatus(TMDbLib.Objects.General.MediaType.TVShow, Id, true);
        }*/
        
    }
}