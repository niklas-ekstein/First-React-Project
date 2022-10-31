IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016181927_InitialCreate')
BEGIN
    CREATE TABLE [Posts] (
        [PostId] int NOT NULL IDENTITY,
        [Title] nvarchar(100) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016181927_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] ON;
    EXEC(N'INSERT INTO [Posts] ([PostId], [Content], [Title])
    VALUES (1, N''Seed data 1'', N''Seed 1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016181927_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] ON;
    EXEC(N'INSERT INTO [Posts] ([PostId], [Content], [Title])
    VALUES (2, N''Seed data 2'', N''Seed 2'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016181927_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] ON;
    EXEC(N'INSERT INTO [Posts] ([PostId], [Content], [Title])
    VALUES (3, N''Seed data 3'', N''Seed 3'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostId', N'Content', N'Title') AND [object_id] = OBJECT_ID(N'[Posts]'))
        SET IDENTITY_INSERT [Posts] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016181927_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221016181927_InitialCreate', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221016183157_StoredProcedure_Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221016183157_StoredProcedure_Migration', N'6.0.10');
END;
GO

COMMIT;
GO

