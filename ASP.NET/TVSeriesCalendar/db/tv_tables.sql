CREATE SCHEMA tv;
GO

BEGIN TRANSACTION;

CREATE TABLE tv.Shows (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	OriginalName NVARCHAR(MAX),
	OriginCountry NVARCHAR(256),
	Popularity DOUBLE NOT NULL,
	PosterPath VARCHAR(MAX) NOT NULL,
	VoteAverage DOUBLE NOT NULL,
	VoteCount DOUBLE,
	FirstAirDate TIMESTAMP NOT NULL
);

CREATE TABLE tv.Seasons (
	Id INTEGER IDENTITY NOT NULL PRIMARY KEY,
	Name NVARCHAR(256) NOT NULL,
	CompanyId INTEGER NOT NULL REFERENCES base.Companies(Id),
	Number INTEGER NOT NULL,
	Credits
	EpisodeCount INTEGER NOT NULL,
	Episodes INTEGER NOT NULL,
	ExternalIds INTEGER,
	Images VARCHAR(256) NOT NULL,
	Overview NVARCHAR(MAX) NOT NULL,
	PosterPath NVARCHAR(256) NOT NULL,
	SeasonNumber INTEGER NOT NULL,
	Videos NVARCHAR(256),
	AirDate TIMESTAMP NOT NULL
	
);

CREATE TABLE tv.Episodes (
	Id INTEGER IDENTITY NOT NULL PRIMARY KEY,
	Name NVARCHAR(256) NOT NULL,
	Credits,
	Crew NVARCHAR(MAX) NOT NULL,
	EpisodeNumber INTEGER NOT NULL,
	ExternalIds INTEGER,
	GuestStars NVARCHAR(MAX),
	Images VARCHAR(256),
	Overview NVARCHAR(MAX) NOT NULL,
	ProductionCode INTEGER,
	SeasonNumber INTEGER NOT NULL,
	StillPath,
	Videos NVARCHAR(256),
	VoteAverage DOUBLE,
	VoteCount INTEGER
);

CREATE TABLE tv.Users (
	Id INTEGER IDENTITY NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(256) NOT NULL,
	LastName NVARCHAR(256) NOT NULL,
	Usersname NVARCHAR(256) NOT NULL,
	Password NVARCHAR(128) NOT NULL,
	Status BOOLEAN NOT NULL
);
COMMIT TRANSACTION;