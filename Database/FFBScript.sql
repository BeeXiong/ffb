USE [master]
GO
/****** Object:  Database [FantasyDatabase]    Script Date: 8/29/2018 2:03:32 PM ******/
GO
ALTER DATABASE [footballplayerspool] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [footballplayerspool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [footballplayerspool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [footballplayerspool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [footballplayerspool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [footballplayerspool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [footballplayerspool] SET ARITHABORT OFF 
GO
ALTER DATABASE [footballplayerspool] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [footballplayerspool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [footballplayerspool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [footballplayerspool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [footballplayerspool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [footballplayerspool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [footballplayerspool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [footballplayerspool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [footballplayerspool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [footballplayerspool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [footballplayerspool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [footballplayerspool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [footballplayerspool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [footballplayerspool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [footballplayerspool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [footballplayerspool] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [footballplayerspool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [footballplayerspool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [footballplayerspool] SET  MULTI_USER 
GO
ALTER DATABASE [footballplayerspool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [footballplayerspool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [footballplayerspool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [footballplayerspool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [footballplayerspool] SET DELAYED_DURABILITY = DISABLED 
GO
USE [footballplayerspool]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[awayTeams]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[awayTeams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[locationId] [int] NOT NULL CONSTRAINT [DF__awayTeams__locat__73FA27A5]  DEFAULT ((0)),
	[awayTeamName] [nvarchar](50) NULL,
	[stadiumName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.awayTeams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[calendarYears]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calendarYears](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[year] [int] NOT NULL,
 CONSTRAINT [PK_dbo.calendarYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[conferences]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conferences](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[conferenceName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.conferences] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[currentYears]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[currentYears](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[calendarYearId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.currentYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_League]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_League](
	[leagueName] [nvarchar](50) NOT NULL,
	[leaguePassword] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](128) NULL,
	[entryCode] [nvarchar](50) NOT NULL DEFAULT (''),
	[amountOfTeams] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.fantasy_League] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_League_Detail]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_League_Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fantasy_LeagueId] [int] NOT NULL,
	[fantasy_TeamId] [int] NOT NULL DEFAULT ((0)),
	[userId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.fantasy_League_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_Owner]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_Owner](
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[userName] [nvarchar](50) NULL,
	[ownerPassword] [nvarchar](50) NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.fantasy_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_Player_Slot]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_Player_Slot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[playerSlot] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.fantasy_Player_Slot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_Roster]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_Roster](
	[playerId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[sportId] [int] NOT NULL,
	[fantasy_League_DetailId] [int] NOT NULL CONSTRAINT [DF__fantasy_R__fanta__5654B625]  DEFAULT ((0)),
	[draftPickNumber] [int] NOT NULL CONSTRAINT [DF__fantasy_R__draft__69678A99]  DEFAULT ((0)),
	[fantasy_Player_SlotId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.fantasy_Roster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fantasy_Team]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fantasy_Team](
	[teamName] [nvarchar](50) NOT NULL,
	[nickName] [nvarchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.fantasy_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[games]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[games](
	[homeTeamId] [int] NOT NULL,
	[awayTeamId] [int] NOT NULL,
	[isactive] [nvarchar](50) NULL,
	[sportId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[playoffRoundId] [int] NOT NULL DEFAULT ((0)),
	[gameDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[homeTeams]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homeTeams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[locationId] [int] NOT NULL,
	[homeTeamName] [nvarchar](50) NULL,
	[stadiumName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.homeTeams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[locations]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[location] [nvarchar](50) NOT NULL,
	[Id] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[playerPositions]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playerPositions](
	[position] [nvarchar](50) NOT NULL,
	[Id] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.playerPositions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NULL,
	[isHealthy] [nvarchar](max) NULL,
	[isStarter] [nvarchar](50) NULL,
	[isLoaded] [nvarchar](50) NULL,
	[playerPositionId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[teamId] [int] NOT NULL,
	[calendarYearId] [int] NULL,
 CONSTRAINT [PK_players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[playoffRounds]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playoffRounds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[round] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.playoffRounds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[playoffTeams]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playoffTeams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[homeTeamId] [int] NOT NULL,
	[playoffSeed] [int] NOT NULL,
	[year] [int] NOT NULL,
	[conferenceId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.playoffTeams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sports]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sports](
	[sportDescription] [nvarchar](50) NULL,
	[Id] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.sports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[statisticalCategories]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statisticalCategories](
	[statisticalCategory] [nvarchar](50) NULL,
	[Id] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.statisticalCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stats]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[playerId] [int] NOT NULL,
	[statisticalCategoryid] [int] NULL,
	[points] [int] NOT NULL,
	[statisticCategoryQuantity] [int] NULL,
	[isAtdbetween35_49] [bit] NOT NULL,
	[isAtdOver50] [bit] NOT NULL,
	[gameId] [int] NOT NULL DEFAULT ((0)),
	[passAttempt] [bit] NOT NULL DEFAULT ((0)),
	[passCompletion] [bit] NOT NULL DEFAULT ((0)),
	[passYards] [int] NULL,
	[isAPassTouchdown] [bit] NOT NULL DEFAULT ((0)),
	[isAinterception] [bit] NOT NULL DEFAULT ((0)),
	[rushAttempt] [bit] NOT NULL DEFAULT ((0)),
	[rushYards] [int] NULL,
	[isARushTouchdown] [bit] NOT NULL DEFAULT ((0)),
	[isAFumble] [bit] NOT NULL DEFAULT ((0)),
	[target] [bit] NOT NULL DEFAULT ((0)),
	[reception] [bit] NOT NULL DEFAULT ((0)),
	[recYards] [int] NULL,
	[isARecTouchdown] [bit] NOT NULL DEFAULT ((0)),
	[isA2Point] [bit] NOT NULL DEFAULT ((0)),
	[isASack] [bit] NOT NULL DEFAULT ((0)),
	[isADefensiveTD] [bit] NOT NULL DEFAULT ((0)),
	[isAFumbleRecovery] [bit] NOT NULL DEFAULT ((0)),
	[isASafety] [bit] NOT NULL DEFAULT ((0)),
	[PAT] [bit] NOT NULL DEFAULT ((0)),
	[isAFG39] [bit] NOT NULL DEFAULT ((0)),
	[isAFG49] [bit] NOT NULL DEFAULT ((0)),
	[isAFG59] [bit] NOT NULL DEFAULT ((0)),
	[isAFG60] [bit] NOT NULL DEFAULT ((0)),
	[points0] [bit] NOT NULL DEFAULT ((0)),
	[points7] [bit] NOT NULL DEFAULT ((0)),
	[points20] [bit] NOT NULL DEFAULT ((0)),
	[points27] [bit] NOT NULL DEFAULT ((0)),
	[points34] [bit] NOT NULL DEFAULT ((0)),
	[points35] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.stats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/29/2018 2:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 8/29/2018 2:03:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[UserClaimId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserClaim] PRIMARY KEY CLUSTERED 
(
	[UserClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 8/29/2018 2:03:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/29/2018 2:03:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[zRawNFLRosters]    Script Date: 8/29/2018 2:03:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zRawNFLRosters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[playerPosition] [nvarchar](max) NULL,
	[firstName] [nvarchar](max) NULL,
	[lastName] [nvarchar](max) NULL,
	[location] [nvarchar](max) NULL,
	[teamName] [nvarchar](max) NULL,
	[teamid] [int] NOT NULL DEFAULT ((0)),
	[playoffYear] [int] NULL,
	[calendarYearId] [int] NULL,
 CONSTRAINT [PK_dbo.zRawNFLRosters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_locationId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_locationId] ON [dbo].[awayTeams]
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_calendarYearId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_calendarYearId] ON [dbo].[currentYears]
(
	[calendarYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_userId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_userId] ON [dbo].[fantasy_League]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_fantasy_LeagueId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_fantasy_LeagueId] ON [dbo].[fantasy_League_Detail]
(
	[fantasy_LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_fantasy_TeamId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_fantasy_TeamId] ON [dbo].[fantasy_League_Detail]
(
	[fantasy_TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_userId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_userId] ON [dbo].[fantasy_League_Detail]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_fantasy_League_DetailId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_fantasy_League_DetailId] ON [dbo].[fantasy_Roster]
(
	[fantasy_League_DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_fantasy_Player_SlotId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_fantasy_Player_SlotId] ON [dbo].[fantasy_Roster]
(
	[fantasy_Player_SlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_playerId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_playerId] ON [dbo].[fantasy_Roster]
(
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sportId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_sportId] ON [dbo].[fantasy_Roster]
(
	[sportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_awayTeamId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_awayTeamId] ON [dbo].[games]
(
	[awayTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_homeTeamId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_homeTeamId] ON [dbo].[games]
(
	[homeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_playoffRoundId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_playoffRoundId] ON [dbo].[games]
(
	[playoffRoundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sportId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_sportId] ON [dbo].[games]
(
	[sportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_locationId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_locationId] ON [dbo].[homeTeams]
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_calendarYearId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_calendarYearId] ON [dbo].[players]
(
	[calendarYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_playerPositionid]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_playerPositionid] ON [dbo].[players]
(
	[playerPositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_teamid]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_teamid] ON [dbo].[players]
(
	[teamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_conferenceId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_conferenceId] ON [dbo].[playoffTeams]
(
	[conferenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_homeTeamId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_homeTeamId] ON [dbo].[playoffTeams]
(
	[homeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_gameId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_gameId] ON [dbo].[stats]
(
	[gameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_playerId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_playerId] ON [dbo].[stats]
(
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_statisticalCategoryid]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_statisticalCategoryid] ON [dbo].[stats]
(
	[statisticalCategoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[User]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserClaim]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserLogin]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 8/29/2018 2:03:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[fantasy_Owner] ADD  DEFAULT ((0)) FOR [Id]
GO
ALTER TABLE [dbo].[awayTeams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.awayTeams_dbo.locations_locationId] FOREIGN KEY([locationId])
REFERENCES [dbo].[locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[awayTeams] CHECK CONSTRAINT [FK_dbo.awayTeams_dbo.locations_locationId]
GO
ALTER TABLE [dbo].[currentYears]  WITH CHECK ADD  CONSTRAINT [FK_dbo.currentYears_dbo.calendarYears_calendarYearId] FOREIGN KEY([calendarYearId])
REFERENCES [dbo].[calendarYears] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[currentYears] CHECK CONSTRAINT [FK_dbo.currentYears_dbo.calendarYears_calendarYearId]
GO
ALTER TABLE [dbo].[fantasy_League]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_League_dbo.User_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[fantasy_League] CHECK CONSTRAINT [FK_dbo.fantasy_League_dbo.User_userId]
GO
ALTER TABLE [dbo].[fantasy_League_Detail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_League_Detail_dbo.fantasy_League_fantasy_LeagueId] FOREIGN KEY([fantasy_LeagueId])
REFERENCES [dbo].[fantasy_League] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[fantasy_League_Detail] CHECK CONSTRAINT [FK_dbo.fantasy_League_Detail_dbo.fantasy_League_fantasy_LeagueId]
GO
ALTER TABLE [dbo].[fantasy_League_Detail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_League_Detail_dbo.User_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[fantasy_League_Detail] CHECK CONSTRAINT [FK_dbo.fantasy_League_Detail_dbo.User_userId]
GO
ALTER TABLE [dbo].[fantasy_Roster]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_Roster_dbo.fantasy_League_Detail_fantasy_League_DetailId] FOREIGN KEY([fantasy_League_DetailId])
REFERENCES [dbo].[fantasy_League_Detail] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[fantasy_Roster] CHECK CONSTRAINT [FK_dbo.fantasy_Roster_dbo.fantasy_League_Detail_fantasy_League_DetailId]
GO
ALTER TABLE [dbo].[fantasy_Roster]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_Roster_dbo.fantasy_Player_Slot_fantasy_Player_SlotId] FOREIGN KEY([fantasy_Player_SlotId])
REFERENCES [dbo].[fantasy_Player_Slot] ([Id])
GO
ALTER TABLE [dbo].[fantasy_Roster] CHECK CONSTRAINT [FK_dbo.fantasy_Roster_dbo.fantasy_Player_Slot_fantasy_Player_SlotId]
GO
ALTER TABLE [dbo].[fantasy_Roster]  WITH CHECK ADD  CONSTRAINT [FK_dbo.fantasy_Roster_dbo.sports_sportId] FOREIGN KEY([sportId])
REFERENCES [dbo].[sports] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[fantasy_Roster] CHECK CONSTRAINT [FK_dbo.fantasy_Roster_dbo.sports_sportId]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_dbo.games_dbo.sports_sportId] FOREIGN KEY([sportId])
REFERENCES [dbo].[sports] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_dbo.games_dbo.sports_sportId]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_games_games] FOREIGN KEY([Id])
REFERENCES [dbo].[games] ([Id])
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_games_games]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_games_games_dbo.playoffRounds_playoffRoundsId] FOREIGN KEY([Id])
REFERENCES [dbo].[games] ([Id])
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_games_games_dbo.playoffRounds_playoffRoundsId]
GO
ALTER TABLE [dbo].[homeTeams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.homeTeams_dbo.locations_locationId] FOREIGN KEY([locationId])
REFERENCES [dbo].[locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homeTeams] CHECK CONSTRAINT [FK_dbo.homeTeams_dbo.locations_locationId]
GO
ALTER TABLE [dbo].[players]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.players_dbo.calendarYears_calendarYearId] FOREIGN KEY([calendarYearId])
REFERENCES [dbo].[calendarYears] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[players] CHECK CONSTRAINT [FK_dbo.players_dbo.calendarYears_calendarYearId]
GO
ALTER TABLE [dbo].[players]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.players_dbo.playerPositions_playerPositionid] FOREIGN KEY([playerPositionId])
REFERENCES [dbo].[playerPositions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[players] CHECK CONSTRAINT [FK_dbo.players_dbo.playerPositions_playerPositionid]
GO
ALTER TABLE [dbo].[playoffTeams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.playoffTeams_dbo.conferences_conferenceId] FOREIGN KEY([conferenceId])
REFERENCES [dbo].[conferences] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[playoffTeams] CHECK CONSTRAINT [FK_dbo.playoffTeams_dbo.conferences_conferenceId]
GO
ALTER TABLE [dbo].[playoffTeams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.playoffTeams_dbo.homeTeams_homeTeamId] FOREIGN KEY([homeTeamId])
REFERENCES [dbo].[homeTeams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[playoffTeams] CHECK CONSTRAINT [FK_dbo.playoffTeams_dbo.homeTeams_homeTeamId]
GO
ALTER TABLE [dbo].[stats]  WITH CHECK ADD  CONSTRAINT [FK_dbo.stats_dbo.games_gameId] FOREIGN KEY([gameId])
REFERENCES [dbo].[games] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[stats] CHECK CONSTRAINT [FK_dbo.stats_dbo.games_gameId]
GO
ALTER TABLE [dbo].[stats]  WITH CHECK ADD  CONSTRAINT [FK_dbo.stats_dbo.players_playerId] FOREIGN KEY([playerId])
REFERENCES [dbo].[players] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[stats] CHECK CONSTRAINT [FK_dbo.stats_dbo.players_playerId]
GO
ALTER TABLE [dbo].[stats]  WITH CHECK ADD  CONSTRAINT [FK_dbo.stats_dbo.statisticalCategories_statisticalCategoryid] FOREIGN KEY([statisticalCategoryid])
REFERENCES [dbo].[statisticalCategories] ([Id])
GO
ALTER TABLE [dbo].[stats] CHECK CONSTRAINT [FK_dbo.stats_dbo.statisticalCategories_statisticalCategoryid]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [FantasyDatabase] SET  READ_WRITE 
GO
