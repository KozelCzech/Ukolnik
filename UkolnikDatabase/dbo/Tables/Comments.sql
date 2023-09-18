CREATE TABLE [dbo].[Comments] (
    [CommentsID]  INT            IDENTITY (1, 1) NOT NULL,
    [TaskID]      INT            NOT NULL,
    [MakerID]     INT            NOT NULL,
    [Text]        NVARCHAR (MAX) NOT NULL,
    [TimeCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([CommentsID] ASC)
);

