CREATE DATABASE [FilmsBase];

CREATE TABLE [dbo].[Actors] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NULL,
    [MiddleName] NVARCHAR (MAX) NULL,
    [Birth]      DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Actors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Films] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [IssueDate]          DATETIME       NOT NULL,
    [Country]            NVARCHAR (MAX) NULL,
    [Genre]              NVARCHAR (MAX) NULL,
    [Duration]           INT            NOT NULL CHECK [Duration] > 0,
    CONSTRAINT [PK_dbo.Films] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[FilmActorBase] (
	[FilmId]	BIGINT,
	[ActorId]	BIGINT,
	CONSTRAINT Film_Actor_PK PRIMARY KEY (FilmId, ActorId),
	CONSTRAINT FK_Films FOREIGN KEY (FilmId) REFERENCES dbo.Films (Id),
	CONSTRAINT FK_Actors FOREIGN KEY (ActorId) REFERENCES dbo.Actors (Id)
);