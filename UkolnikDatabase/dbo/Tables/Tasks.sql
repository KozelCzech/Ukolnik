CREATE TABLE [dbo].[Tasks] (
    [TasksID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [CreatorID]   INT            NOT NULL,
    [Status]      VARCHAR (50)   NOT NULL,
    [Text]        VARCHAR (MAX)  NOT NULL,
    [TimeCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([TasksID] ASC)
);

