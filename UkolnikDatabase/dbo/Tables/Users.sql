CREATE TABLE [dbo].[Users] (
    [UsersID]  INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UsersID] ASC)
);

