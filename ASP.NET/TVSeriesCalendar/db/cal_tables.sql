BEGIN TRANSACTION;

CREATE TABLE usr.Users (
	Id INTEGER IDENTITY PRIMARY KEY NOT NULL,
	Name VARCHAR(256) NOT NULL,
	Username VARCHAR(256) NOT NULL,
	Password VARCHAR(256) NOT NULL,
	Status BIT NOT NULL,
	FavoriteTvShows INTEGER,
	FavoriteMovies INTEGER
);

CREATE TABLE dbo.FavoriteTvShows (
	Id INTEGER IDENTITY PRIMARY KEY NOT NULL,
	ShowId INTEGER NOT NULL,
	UserId NVARCHAR(128) NOT NULL REFERENCES dbo.AspNetUsers(Id), 
	Name VARCHAR(256) NOT NULL,
	PosterPath VARCHAR(256),
	AirDate DATE NOT NULL
);

CREATE TABLE dbo.FavoriteMovies (
	Id INTEGER PRIMARY KEY NOT NULL,
	UserId  NVARCHAR(128) NOT NULL REFERENCES dbo.AspNetUsers(Id),
	Name VARCHAR(256) NOT NULL,
	PosterPath VARCHAR(256),
	AirDate TIMESTAMP NOT NULL
);

CREATE TABLE dbo.Shows(
	Id INTEGER PRIMARY KEY NOT NULL,
	Name VARCHAR(256) NOT NULL,
	OnAir BIT NOT NULL,
	
);

COMMIT TRANSACTION;