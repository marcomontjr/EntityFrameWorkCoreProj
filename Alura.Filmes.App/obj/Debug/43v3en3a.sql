IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [actor] (
    [actor_id] int NOT NULL IDENTITY,
    [first_name] varchar(45) NOT NULL,
    [last_name] varchar(45) NOT NULL,
    [last_update] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_actor] PRIMARY KEY ([actor_id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180210215942_Inicial', N'2.0.1-rtm-125');

GO

CREATE TABLE [film] (
    [Id] int NOT NULL IDENTITY,
    [release_year] varchar(4) NULL,
    [description] text NULL,
    [length] smallint NULL,
    [language_id] tinyint NOT NULL,
    [original_language_id] tinyint NOT NULL,
    [rating] varchar(10) NULL DEFAULT (G),
    [title] varchar(255) NOT NULL,
    [last_update] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_film] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180211021002_Filme', N'2.0.1-rtm-125');

GO

