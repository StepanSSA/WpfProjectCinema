
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/26/2022 19:28:29
-- Generated from EDMX file: C:\Users\Степан\Desktop\Учёба\Программирование\3Курс\С#\Project\WpfProjectCinema\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [model];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FilmsFilmsNCinemas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet1] DROP CONSTRAINT [FK_FilmsFilmsNCinemas];
GO
IF OBJECT_ID(N'[dbo].[FK_HallsFilmsNCinemas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet1] DROP CONSTRAINT [FK_HallsFilmsNCinemas];
GO
IF OBJECT_ID(N'[dbo].[FK_CinemasFilmsNCinemas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet1] DROP CONSTRAINT [FK_CinemasFilmsNCinemas];
GO
IF OBJECT_ID(N'[dbo].[FK_CinemasHalls]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HallsSet] DROP CONSTRAINT [FK_CinemasHalls];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HallsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HallsSet];
GO
IF OBJECT_ID(N'[dbo].[FilmsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmsSet];
GO
IF OBJECT_ID(N'[dbo].[SessionSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionSet1];
GO
IF OBJECT_ID(N'[dbo].[CinemasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CinemasSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HallsSet'
CREATE TABLE [dbo].[HallsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idCinema] int  NOT NULL,
    [Size] int  NOT NULL,
    [FreeSeats] int  NOT NULL,
    [Number] int  NOT NULL
);
GO

-- Creating table 'FilmsSet'
CREATE TABLE [dbo].[FilmsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Rating] float  NOT NULL,
    [Time] time  NOT NULL
);
GO

-- Creating table 'SessionSet1'
CREATE TABLE [dbo].[SessionSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idFilm] int  NOT NULL,
    [idHall] int  NOT NULL,
    [IdCinema] int  NOT NULL,
    [Price] int  NOT NULL,
    [sessionTime] datetime  NOT NULL
);
GO

-- Creating table 'CinemasSet'
CREATE TABLE [dbo].[CinemasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Addres] nvarchar(max)  NOT NULL,
    [Rating] float  NOT NULL,
    [HallsQuantity] int  NOT NULL
);
GO

-- Creating table 'CinemaSessionSet'
CREATE TABLE [dbo].[CinemaSessionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idFilm] int  NOT NULL,
    [idHall] int  NOT NULL,
    [idCinema] int  NOT NULL,
    [Price] int  NOT NULL,
    [sessionTime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HallsSet'
ALTER TABLE [dbo].[HallsSet]
ADD CONSTRAINT [PK_HallsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilmsSet'
ALTER TABLE [dbo].[FilmsSet]
ADD CONSTRAINT [PK_FilmsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SessionSet1'
ALTER TABLE [dbo].[SessionSet1]
ADD CONSTRAINT [PK_SessionSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CinemasSet'
ALTER TABLE [dbo].[CinemasSet]
ADD CONSTRAINT [PK_CinemasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CinemaSessionSet'
ALTER TABLE [dbo].[CinemaSessionSet]
ADD CONSTRAINT [PK_CinemaSessionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idFilm] in table 'SessionSet1'
ALTER TABLE [dbo].[SessionSet1]
ADD CONSTRAINT [FK_FilmsFilmsNCinemas]
    FOREIGN KEY ([idFilm])
    REFERENCES [dbo].[FilmsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmsFilmsNCinemas'
CREATE INDEX [IX_FK_FilmsFilmsNCinemas]
ON [dbo].[SessionSet1]
    ([idFilm]);
GO

-- Creating foreign key on [idHall] in table 'SessionSet1'
ALTER TABLE [dbo].[SessionSet1]
ADD CONSTRAINT [FK_HallsFilmsNCinemas]
    FOREIGN KEY ([idHall])
    REFERENCES [dbo].[HallsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HallsFilmsNCinemas'
CREATE INDEX [IX_FK_HallsFilmsNCinemas]
ON [dbo].[SessionSet1]
    ([idHall]);
GO

-- Creating foreign key on [IdCinema] in table 'SessionSet1'
ALTER TABLE [dbo].[SessionSet1]
ADD CONSTRAINT [FK_CinemasFilmsNCinemas]
    FOREIGN KEY ([IdCinema])
    REFERENCES [dbo].[CinemasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemasFilmsNCinemas'
CREATE INDEX [IX_FK_CinemasFilmsNCinemas]
ON [dbo].[SessionSet1]
    ([IdCinema]);
GO

-- Creating foreign key on [idCinema] in table 'HallsSet'
ALTER TABLE [dbo].[HallsSet]
ADD CONSTRAINT [FK_CinemasHalls]
    FOREIGN KEY ([idCinema])
    REFERENCES [dbo].[CinemasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemasHalls'
CREATE INDEX [IX_FK_CinemasHalls]
ON [dbo].[HallsSet]
    ([idCinema]);
GO

-- Creating foreign key on [idCinema] in table 'CinemaSessionSet'
ALTER TABLE [dbo].[CinemaSessionSet]
ADD CONSTRAINT [FK_CinemasCinemaSession]
    FOREIGN KEY ([idCinema])
    REFERENCES [dbo].[CinemasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemasCinemaSession'
CREATE INDEX [IX_FK_CinemasCinemaSession]
ON [dbo].[CinemaSessionSet]
    ([idCinema]);
GO

-- Creating foreign key on [idHall] in table 'CinemaSessionSet'
ALTER TABLE [dbo].[CinemaSessionSet]
ADD CONSTRAINT [FK_HallsCinemaSession]
    FOREIGN KEY ([idHall])
    REFERENCES [dbo].[HallsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HallsCinemaSession'
CREATE INDEX [IX_FK_HallsCinemaSession]
ON [dbo].[CinemaSessionSet]
    ([idHall]);
GO

-- Creating foreign key on [idFilm] in table 'CinemaSessionSet'
ALTER TABLE [dbo].[CinemaSessionSet]
ADD CONSTRAINT [FK_FilmsCinemaSession]
    FOREIGN KEY ([idFilm])
    REFERENCES [dbo].[FilmsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmsCinemaSession'
CREATE INDEX [IX_FK_FilmsCinemaSession]
ON [dbo].[CinemaSessionSet]
    ([idFilm]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------