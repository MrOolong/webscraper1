CREATE TABLE [dbo].[ArticleDBs] (
    [IDKey]        INT            IDENTITY (1, 1) NOT NULL,
    [ArticleTitle] NVARCHAR (MAX) NULL UNIQUE,
    CONSTRAINT [PK_dbo.ArticleDBs] PRIMARY KEY CLUSTERED ([IDKey] ASC)
);

