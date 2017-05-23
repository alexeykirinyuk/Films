СREATE DATABASE [Films];

CREATE TABLE [dbo].[WorkersBase] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NULL,
    [MiddleName] NVARCHAR (MAX) NULL,
    [Birth]      DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.WorkersBase] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[FilmsBase] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [IssueDate]          DATETIME       NOT NULL,
    [Country]            NVARCHAR (MAX) NULL,
    [Genre]              NVARCHAR (MAX) NULL,
    [Duration]           INT            NOT NULL CHECK [Duration] > 0,
    CONSTRAINT [PK_dbo.ProjectsBase] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[FilmActorBase] (
	[FilmId]	BIGINT,
	[ActorId]	BIGINT,
	CONSTRAINT Project_Worker_PK PRIMARY KEY (ProjectId, WorkerId),
	CONSTRAINT FK_ProjectsBase FOREIGN KEY (ProjectId) REFERENCES dbo.ProjectsBase (Id),
	CONSTRAINT FK_WorkersBase FOREIGN KEY (WorkerId) REFERENCES dbo.WorkersBase (Id)
);
GO
CREATE NONCLUSTERED INDEX [IX_EmployeeId]
    ON [dbo].[ProjectsBase]([EmployeeId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_LeaderId]
    ON [dbo].[ProjectsBase]([LeaderId] ASC);