IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Admins] (
    [Id] int NOT NULL IDENTITY,
    [Account] nvarchar(20) NULL,
    [Password] nvarchar(20) NULL,
    [NickName] nvarchar(20) NULL,
    [Email] nvarchar(30) NULL,
    CONSTRAINT [PK_Admins] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Categorys] (
    [Id] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(30) NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Categorys] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Diarys] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(500) NULL,
    [CreateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Diarys] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NULL,
    [Abstr] nvarchar(500) NULL,
    [CreateTime] datetime2 NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Blogs_Categorys_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categorys] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BContents] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NULL,
    [BlogId] int NOT NULL,
    CONSTRAINT [PK_BContents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BContents_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Account', N'Email', N'NickName', N'Password') AND [object_id] = OBJECT_ID(N'[Admins]'))
    SET IDENTITY_INSERT [Admins] ON;
INSERT INTO [Admins] ([Id], [Account], [Email], [NickName], [Password])
VALUES (1, N'admin', N'admin@admin.com', N'admin', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Account', N'Email', N'NickName', N'Password') AND [object_id] = OBJECT_ID(N'[Admins]'))
    SET IDENTITY_INSERT [Admins] OFF;

GO

CREATE UNIQUE INDEX [IX_BContents_BlogId] ON [BContents] ([BlogId]);

GO

CREATE INDEX [IX_Blogs_CategoryId] ON [Blogs] ([CategoryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191026084616_init', N'3.0.0');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Diarys]') AND [c].[name] = N'CreateTime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Diarys] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Diarys] ALTER COLUMN [CreateTime] nvarchar(max) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categorys]') AND [c].[name] = N'CreateTime');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Categorys] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Categorys] ALTER COLUMN [CreateTime] nvarchar(max) NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'CreateTime');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [CreateTime] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191026123308_updatedatetimestring', N'3.0.0');

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categorys]') AND [c].[name] = N'CreateTime');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Categorys] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Categorys] ALTER COLUMN [CreateTime] datetime2 NOT NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'CreateTime');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [CreateTime] datetime2 NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191026124045_updatedatetimestringback', N'3.0.0');

GO

