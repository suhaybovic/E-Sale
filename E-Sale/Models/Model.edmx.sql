
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2017 01:15:29
-- Generated from EDMX file: F:\Microsoft Apps\E-Sale\E-Sale\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [E-Sale];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Company_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Company_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Following_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Following] DROP CONSTRAINT [FK_Following_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_Following_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Following] DROP CONSTRAINT [FK_Following_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Friend_User1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friend] DROP CONSTRAINT [FK_Friend_User1];
GO
IF OBJECT_ID(N'[dbo].[FK_Friend_User2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friend] DROP CONSTRAINT [FK_Friend_User2];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Like] DROP CONSTRAINT [FK_Post_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_Photo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Photo];
GO
IF OBJECT_ID(N'[dbo].[FK_PostID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_PostID];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_User_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_User_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Photo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Photo];
GO
IF OBJECT_ID(N'[dbo].[FK_User_ProfilePhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_ProfilePhoto];
GO
IF OBJECT_ID(N'[dbo].[FK_UserID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Like] DROP CONSTRAINT [FK_UserID];
GO
IF OBJECT_ID(N'[dbo].[FK_UserID_Comment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_UserID_Comment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Following]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Following];
GO
IF OBJECT_ID(N'[dbo].[Friend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friend];
GO
IF OBJECT_ID(N'[dbo].[Like]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Like];
GO
IF OBJECT_ID(N'[dbo].[Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photo];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [ID] int  NOT NULL,
    [Country] varchar(100)  NULL,
    [Area] varchar(100)  NULL,
    [Street] varchar(100)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [ID] nchar(10)  NOT NULL,
    [UserID] int  NULL,
    [PostID] int  NULL,
    [Text] varchar(1000)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Field] varchar(50)  NULL,
    [ProfilePhoto] int  NULL,
    [Password] varchar(1000)  NULL,
    [Address] int  NULL,
    [Status] varchar(50)  NULL
);
GO

-- Creating table 'Followings'
CREATE TABLE [dbo].[Followings] (
    [ID] int  NOT NULL,
    [UserID] int  NULL,
    [CompanyID] int  NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [ID] int  NOT NULL,
    [User1] int  NOT NULL,
    [User2] int  NOT NULL
);
GO

-- Creating table 'Likes'
CREATE TABLE [dbo].[Likes] (
    [ID] int  NOT NULL,
    [UserID] int  NULL,
    [PostID] int  NULL
);
GO

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [ID] int  NOT NULL,
    [URL] varchar(100)  NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [ID] int  NOT NULL,
    [UserID] int  NULL,
    [CompanyID] int  NULL,
    [Text] varchar(1000)  NOT NULL,
    [Photo] int  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int  NOT NULL,
    [FirstName] varchar(100)  NULL,
    [LastName] varchar(100)  NULL,
    [UserName] varchar(100)  NULL,
    [ProfilePhoto] int  NULL,
    [Password] varchar(100)  NULL,
    [Address] int  NULL,
    [email] varchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [PK_Followings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Likes'
ALTER TABLE [dbo].[Likes]
ADD CONSTRAINT [PK_Likes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Address] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_Company_Address]
    FOREIGN KEY ([Address])
    REFERENCES [dbo].[Addresses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Company_Address'
CREATE INDEX [IX_FK_Company_Address]
ON [dbo].[Companies]
    ([Address]);
GO

-- Creating foreign key on [Address] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Address]
    FOREIGN KEY ([Address])
    REFERENCES [dbo].[Addresses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Address'
CREATE INDEX [IX_FK_User_Address]
ON [dbo].[Users]
    ([Address]);
GO

-- Creating foreign key on [PostID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_PostID]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Posts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PostID'
CREATE INDEX [IX_FK_PostID]
ON [dbo].[Comments]
    ([PostID]);
GO

-- Creating foreign key on [UserID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_UserID_Comment]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserID_Comment'
CREATE INDEX [IX_FK_UserID_Comment]
ON [dbo].[Comments]
    ([UserID]);
GO

-- Creating foreign key on [CompanyID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Company_ID]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Companies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Company_ID'
CREATE INDEX [IX_FK_Company_ID]
ON [dbo].[Posts]
    ([CompanyID]);
GO

-- Creating foreign key on [ProfilePhoto] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_Company_Photo]
    FOREIGN KEY ([ProfilePhoto])
    REFERENCES [dbo].[Photos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Company_Photo'
CREATE INDEX [IX_FK_Company_Photo]
ON [dbo].[Companies]
    ([ProfilePhoto]);
GO

-- Creating foreign key on [CompanyID] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [FK_Following_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Companies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Following_Company'
CREATE INDEX [IX_FK_Following_Company]
ON [dbo].[Followings]
    ([CompanyID]);
GO

-- Creating foreign key on [UserID] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [FK_Following_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Following_User'
CREATE INDEX [IX_FK_Following_User]
ON [dbo].[Followings]
    ([UserID]);
GO

-- Creating foreign key on [User1] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friend_User1]
    FOREIGN KEY ([User1])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Friend_User1'
CREATE INDEX [IX_FK_Friend_User1]
ON [dbo].[Friends]
    ([User1]);
GO

-- Creating foreign key on [User2] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friend_User2]
    FOREIGN KEY ([User2])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Friend_User2'
CREATE INDEX [IX_FK_Friend_User2]
ON [dbo].[Friends]
    ([User2]);
GO

-- Creating foreign key on [PostID] in table 'Likes'
ALTER TABLE [dbo].[Likes]
ADD CONSTRAINT [FK_Post_ID]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Posts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_ID'
CREATE INDEX [IX_FK_Post_ID]
ON [dbo].[Likes]
    ([PostID]);
GO

-- Creating foreign key on [ID] in table 'Likes'
ALTER TABLE [dbo].[Likes]
ADD CONSTRAINT [FK_UserID]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Photo] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_Photo]
    FOREIGN KEY ([Photo])
    REFERENCES [dbo].[Photos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_Photo'
CREATE INDEX [IX_FK_Post_Photo]
ON [dbo].[Posts]
    ([Photo]);
GO

-- Creating foreign key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Photo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Photos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProfilePhoto] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_ProfilePhoto]
    FOREIGN KEY ([ProfilePhoto])
    REFERENCES [dbo].[Photos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_ProfilePhoto'
CREATE INDEX [IX_FK_User_ProfilePhoto]
ON [dbo].[Users]
    ([ProfilePhoto]);
GO

-- Creating foreign key on [UserID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_User_ID]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_ID'
CREATE INDEX [IX_FK_User_ID]
ON [dbo].[Posts]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------