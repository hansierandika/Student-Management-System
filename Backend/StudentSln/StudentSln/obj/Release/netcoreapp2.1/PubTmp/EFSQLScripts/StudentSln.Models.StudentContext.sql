IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506175226_InitialCreate')
BEGIN
    CREATE TABLE [StudentDetails] (
        [SId] int NOT NULL IDENTITY,
        [Id] nvarchar(10) NOT NULL,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [Sinhala] int NOT NULL,
        [Maths] int NOT NULL,
        [English] int NOT NULL,
        [ContactNo] nvarchar(20) NOT NULL,
        [Age] int NOT NULL,
        CONSTRAINT [PK_StudentDetails] PRIMARY KEY ([SId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506175226_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210506175226_InitialCreate', N'2.1.14-servicing-32113');
END;

GO

