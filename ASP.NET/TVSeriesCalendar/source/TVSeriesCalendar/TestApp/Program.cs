using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.SearchTVShowByName("Blindspot");
            //program.DiscoverTVShowById(48866);
            program.AddTVShowToFavorites(48866);

        }

        public void SearchTVShowByName(string showName)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            IEnumerable<TMDbLib.Objects.Search.SearchTv> tvshows = client.SearchTvShow(showName, 1).Results;
            TMDbLib.Objects.Search.SearchTv show = tvshows.First();
            Console.WriteLine("Name: {0} ; ID: {1}; FirstAirDate: {2}; Original name: {3}; Origin country: {4}; Popularity: {5}, Poster: {6}; BackdoorPath: {7} ", show.Name, show.Id, show.FirstAirDate, show.OriginalName, show.OriginCountry, show.Popularity, show.PosterPath, show.BackdropPath);
            Console.ReadKey();
        }

        public void DiscoverTVShowById(int id)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            var session = client.AuthenticationGetUserSession("yana.nikolova", "tir3311tiri1");
            client.SetSessionInformation(session.SessionId, TMDbLib.Objects.Authentication.SessionType.UserSession);
            TMDbLib.Objects.Search.SearchTv show = client.GetTvShow(id);
            TMDbLib.Objects.TvShows.TvEpisode episode = client.GetTvEpisode(id, 3, 8);
            TMDbLib.Objects.TvShows.TvSeason season = client.GetTvSeason(id, 3);
            TMDbLib.Objects.Account.AccountDetails account = client.AccountGetDetails();
            Console.WriteLine("Id: {0} ", season.Id);
            Console.WriteLine(); ;
            Console.WriteLine("Name: {0} ", season.Name);
            Console.WriteLine();
            Console.WriteLine("Poster path: {0} ", season.PosterPath);
            Console.WriteLine();
            Console.WriteLine("Air date: {0} ", season.AirDate);
            Console.WriteLine();
            Console.WriteLine("Credits: {0} ", season.Credits);
            Console.WriteLine();
            Console.WriteLine("Episodes count: {0} ", season.EpisodeCount);
            Console.WriteLine();
            Console.WriteLine("Episodes: {0} ", season.Episodes);
            Console.WriteLine();
            Console.WriteLine("External ids, Imdb id: {0} ", season.ExternalIds);
            Console.WriteLine();
            Console.WriteLine("Images: {0} ", season.Images);
            Console.WriteLine();
            Console.WriteLine("Overview: {0} ", season.Overview);
            Console.WriteLine();
            Console.WriteLine("Poster path: {0} ", season.PosterPath);
            Console.WriteLine();
            Console.WriteLine("Season number: {0} ", season.SeasonNumber);
            Console.WriteLine();
            Console.WriteLine("Videos: {0} ", season.Videos);
            Console.WriteLine();
            Console.WriteLine("Episodes: {0} ", season.AccountStates);
            Console.Read();
        }

        public void AddTVShowToFavorites(int showId)
        {
            TMDbClient client = new TMDbClient("3223607019722624843b888a49468858");
            var session = client.AuthenticationGetUserSession("yana.nikolova", "tir3311tiri1");
            client.SetSessionInformation(session.SessionId, TMDbLib.Objects.Authentication.SessionType.UserSession);
            var account = client.AccountChangeFavoriteStatus(TMDbLib.Objects.General.MediaType.TVShow, showId, true);
            Console.WriteLine("The show is added to favorites.");
            Console.ReadKey();
        }
    }
}
