USE [master]
GO
/****** Object:  Database [Team4]    Script Date: 4/13/2020 4:59:03 PM ******/
CREATE DATABASE [Team4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Team4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ABHISQL\MSSQL\DATA\Team4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Team4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ABHISQL\MSSQL\DATA\Team4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Team4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Team4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Team4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Team4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Team4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Team4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Team4] SET ARITHABORT OFF 
GO
ALTER DATABASE [Team4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Team4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Team4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Team4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Team4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Team4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Team4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Team4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Team4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Team4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Team4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Team4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Team4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Team4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Team4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Team4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Team4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Team4] SET RECOVERY FULL 
GO
ALTER DATABASE [Team4] SET  MULTI_USER 
GO
ALTER DATABASE [Team4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Team4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Team4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Team4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Team4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Team4', N'ON'
GO
ALTER DATABASE [Team4] SET QUERY_STORE = OFF
GO
USE [Team4]
GO
/****** Object:  Table [dbo].[Booking_Table]    Script Date: 4/13/2020 4:59:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_Table](
	[Ticket_ID] [nvarchar](50) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[SID] [nvarchar](50) NOT NULL,
	[NoOfTickets] [int] NOT NULL,
 CONSTRAINT [PK_Booking_Table] PRIMARY KEY CLUSTERED 
(
	[Ticket_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusDetails_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusDetails_Table](
	[Bus_ID] [nvarchar](50) NOT NULL,
	[Bus_Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_BusDetails_Table] PRIMARY KEY CLUSTERED 
(
	[Bus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Table](
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Pincode] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Contactno] [varchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[CustomerType] [nvarchar](50) NOT NULL,
	[Customer_ID] [int] NOT NULL,
 CONSTRAINT [PK_Customer_Table] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Table](
	[User_ID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login_Table] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route_Table](
	[Route_ID] [nvarchar](50) NOT NULL,
	[From] [nvarchar](50) NOT NULL,
	[To] [nvarchar](50) NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_Route_Table] PRIMARY KEY CLUSTERED 
(
	[Route_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule_Table](
	[SID] [nvarchar](50) NOT NULL,
	[Route_ID] [nvarchar](50) NOT NULL,
	[Bus_ID] [nvarchar](50) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[DateOfJourney] [date] NOT NULL,
	[AvailableSeats] [int] NOT NULL,
 CONSTRAINT [PK_Schedule_Table] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewHistory]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ViewHistory]
as
SELECT   distinct     dbo.Booking_Table.Customer_ID, dbo.Booking_Table.Ticket_ID, dbo.Booking_Table.NoOfTickets, dbo.BusDetails_Table.Bus_ID,
				dbo.BusDetails_Table.Bus_Name, dbo.BusDetails_Table.Type, dbo.Route_Table.[From],dbo.Route_Table.[To], 
             dbo.Route_Table.Cost, dbo.Schedule_Table.StartTime, dbo.Schedule_Table.DateOfJourney,dbo.Booking_Table.NoOfTickets*dbo.Route_Table.Cost TotalCost
FROM            dbo.Booking_Table INNER JOIN
                         dbo.Customer_Table ON dbo.Booking_Table.Customer_ID = dbo.Customer_Table.Customer_ID INNER JOIN
                         dbo.Schedule_Table ON dbo.Booking_Table.SID = dbo.Schedule_Table.SID INNER JOIN
                         dbo.BusDetails_Table ON dbo.Schedule_Table.Bus_ID = dbo.BusDetails_Table.Bus_ID INNER JOIN
                         dbo.Route_Table ON dbo.Schedule_Table.Route_ID = dbo.Route_Table.Route_ID CROSS JOIN
                         dbo.Login_Table
GO
/****** Object:  Table [dbo].[CS_Table]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CS_Table](
	[Country] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CS_Table] PRIMARY KEY CLUSTERED 
(
	[Country] ASC,
	[State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[destination]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[destination](
	[location] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_destination] PRIMARY KEY CLUSTERED 
(
	[location] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Booking_Table] ([Ticket_ID], [Customer_ID], [SID], [NoOfTickets]) VALUES (N'B001270320201234', 2020031234, N'S1', 2)
INSERT [dbo].[Booking_Table] ([Ticket_ID], [Customer_ID], [SID], [NoOfTickets]) VALUES (N'B002280320204562', 2020034561, N'S2', 2)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B001', N'GoTour', N'A/C Semi Sleeper', 30)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B002', N'Orange', N'A/C Sleeper', 22)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B003', N'hm travels', N'A/C Semi Sleeper', 30)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B004', N'mm travels', N'A/C Sleeper', 20)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B005', N'om travels', N'Non A/C seater', 40)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B006', N'hari travels', N'A/C Semi Sleeper', 30)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B007', N'xyz travels', N'A/C Semi Sleeper', 30)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B008', N'new travels', N'A/C Sleeper', 24)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B009', N'good travels', N'A/C Sleeper', 24)
INSERT [dbo].[BusDetails_Table] ([Bus_ID], [Bus_Name], [Type], [Capacity]) VALUES (N'B010', N'abhi travel', N'A/C Sleeper', 23)
INSERT [dbo].[CS_Table] ([Country], [State]) VALUES (N'India', N'AP')
INSERT [dbo].[CS_Table] ([Country], [State]) VALUES (N'India', N'Karnataka')
INSERT [dbo].[CS_Table] ([Country], [State]) VALUES (N'India', N'TN')
INSERT [dbo].[CS_Table] ([Country], [State]) VALUES (N'India', N'TS')
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'abhishek', N'forum', N'hyderbad', N'TS', N'India', 500085, N'abhik@gail.com', N'Male', N'1234512345', CAST(N'1997-07-09' AS Date), N'High', 202040003)
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'Ram shyam', N'Gachibowli', N'Hyderabad', N'TS', N'India', 500032, N'ramsam123@gmail.com', N'Male', N'8888888888', CAST(N'1998-03-15' AS Date), N'Normal', 2020031234)
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'Sruthi', N'DSNR', N'Hyderabad', N'TS', N'India', 500023, N'Sruthi456@gmail.com', N'Female', N'7845129632', CAST(N'1997-02-27' AS Date), N'High', 2020034561)
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'tom bro', N'new town', N'hyderbad', N'TN', N'India', 123456, N'asdf@gmsi.com', N'Male', N'8888888888', CAST(N'1997-07-09' AS Date), N'High', 2020040004)
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'raman', N'forum', N'hyderabad', N'TS', N'India', 123789, N'abh@gmail.com', N'Male', N'7894561237', CAST(N'1997-07-09' AS Date), N'High', 2020040005)
INSERT [dbo].[Customer_Table] ([Name], [Address], [City], [State], [Country], [Pincode], [Email], [Gender], [Contactno], [DateOfBirth], [CustomerType], [Customer_ID]) VALUES (N'jim', N'ak nagar', N'chennai', N'TS', N'India', 456789, N'asdasd@ghdj.com', N'Female', N'1234564561', CAST(N'1997-07-19' AS Date), N'Normal', 2020040006)
INSERT [dbo].[destination] ([location]) VALUES (N'Agartala')
INSERT [dbo].[destination] ([location]) VALUES (N'Agra')
INSERT [dbo].[destination] ([location]) VALUES (N'Ahemdabad')
INSERT [dbo].[destination] ([location]) VALUES (N'Bangalore')
INSERT [dbo].[destination] ([location]) VALUES (N'Bhopal')
INSERT [dbo].[destination] ([location]) VALUES (N'Chennai')
INSERT [dbo].[destination] ([location]) VALUES (N'Cochin')
INSERT [dbo].[destination] ([location]) VALUES (N'Delhi')
INSERT [dbo].[destination] ([location]) VALUES (N'Imphal')
INSERT [dbo].[destination] ([location]) VALUES (N'Indore')
INSERT [dbo].[destination] ([location]) VALUES (N'Jaipur')
INSERT [dbo].[destination] ([location]) VALUES (N'Kolkata')
INSERT [dbo].[destination] ([location]) VALUES (N'Lucknow')
INSERT [dbo].[destination] ([location]) VALUES (N'Madras')
INSERT [dbo].[destination] ([location]) VALUES (N'Mumbai')
INSERT [dbo].[destination] ([location]) VALUES (N'Nagpur')
INSERT [dbo].[destination] ([location]) VALUES (N'Noida')
INSERT [dbo].[destination] ([location]) VALUES (N'Patna')
INSERT [dbo].[destination] ([location]) VALUES (N'Pune')
INSERT [dbo].[destination] ([location]) VALUES (N'Raipur')
INSERT [dbo].[destination] ([location]) VALUES (N'Trivandrum')
INSERT [dbo].[destination] ([location]) VALUES (N'Vijaywada')
INSERT [dbo].[destination] ([location]) VALUES (N'Vishakapatnam')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'2020031234', N'ram', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'2020034561', N'Sruthi', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'2020040004', N'tom', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'2020040005', N'raman', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'2020040006', N'jim', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'202040003', N'abhishek', N'Customer')
INSERT [dbo].[Login_Table] ([User_ID], [Password], [UserType]) VALUES (N'abc', N'xyz', N'Admin')
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R001', N'Hyderabad', N'Chennai', 1200)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R002', N'Hyderabad', N'Bangalore', 1300)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R003', N'hyderbad', N'goa', 1200)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R004', N'hyderbad', N'nagpur', 1800)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R005', N'goa', N'hyderabad', 1200)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R006', N'hyderabad', N'mumbai', 1800)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R007', N'patna', N'agra', 1100)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R008', N'Pune', N'Trivandrun', 2000)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R009', N'Pune', N'Indore', 2000)
INSERT [dbo].[Route_Table] ([Route_ID], [From], [To], [Cost]) VALUES (N'R010', N'Noida', N'Patna', 2000)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S1', N'R001', N'B001', CAST(N'15:00:00' AS Time), CAST(N'2020-03-27' AS Date), 30)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S10', N'R008', N'B008', CAST(N'07:00:00' AS Time), CAST(N'2020-04-07' AS Date), 23)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S11', N'R009', N'B009', CAST(N'07:00:00' AS Time), CAST(N'2020-04-15' AS Date), 21)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S12', N'R010', N'B010', CAST(N'10:00:00' AS Time), CAST(N'2020-04-15' AS Date), 21)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S2', N'R002', N'B002', CAST(N'16:00:00' AS Time), CAST(N'2020-04-03' AS Date), 22)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S3', N'R002', N'B002', CAST(N'12:00:00' AS Time), CAST(N'2020-03-31' AS Date), 23)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S4', N'R002', N'B003', CAST(N'13:00:00' AS Time), CAST(N'2020-04-04' AS Date), 15)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S5', N'R001', N'B002', CAST(N'19:00:00' AS Time), CAST(N'2020-04-05' AS Date), 20)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S6', N'R002', N'B003', CAST(N'19:00:00' AS Time), CAST(N'2020-04-07' AS Date), 20)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S7', N'R003', N'B003', CAST(N'02:06:00' AS Time), CAST(N'2020-04-08' AS Date), 25)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S8', N'R007', N'B005', CAST(N'23:00:00' AS Time), CAST(N'2020-04-09' AS Date), 38)
INSERT [dbo].[Schedule_Table] ([SID], [Route_ID], [Bus_ID], [StartTime], [DateOfJourney], [AvailableSeats]) VALUES (N'S9', N'R007', N'B006', CAST(N'14:00:00' AS Time), CAST(N'2020-04-06' AS Date), 28)
ALTER TABLE [dbo].[Booking_Table]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Table_Customer_Table] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer_Table] ([Customer_ID])
GO
ALTER TABLE [dbo].[Booking_Table] CHECK CONSTRAINT [FK_Booking_Table_Customer_Table]
GO
ALTER TABLE [dbo].[Booking_Table]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Table_Schedule_Table] FOREIGN KEY([SID])
REFERENCES [dbo].[Schedule_Table] ([SID])
GO
ALTER TABLE [dbo].[Booking_Table] CHECK CONSTRAINT [FK_Booking_Table_Schedule_Table]
GO
ALTER TABLE [dbo].[Schedule_Table]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Table_BusDetails_Table] FOREIGN KEY([Bus_ID])
REFERENCES [dbo].[BusDetails_Table] ([Bus_ID])
GO
ALTER TABLE [dbo].[Schedule_Table] CHECK CONSTRAINT [FK_Schedule_Table_BusDetails_Table]
GO
ALTER TABLE [dbo].[Schedule_Table]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Table_Route_Table1] FOREIGN KEY([Route_ID])
REFERENCES [dbo].[Route_Table] ([Route_ID])
GO
ALTER TABLE [dbo].[Schedule_Table] CHECK CONSTRAINT [FK_Schedule_Table_Route_Table1]
GO
/****** Object:  StoredProcedure [dbo].[history]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[history] 
	@cid int
AS
BEGIN
	select * from ViewHistory where Customer_ID=@cid   
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Test]    Script Date: 4/13/2020 4:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Test] 
@From nvarchar(15),
@To nvarchar(15),
@doj date,
@not int
as
begin
select SID,B.Bus_ID,R.Route_ID,Bus_Name,StartTime,Cost*@not TotalCost,AvailableSeats 
from BusDetails_Table B inner join Schedule_Table S on B.Bus_ID=S.Bus_ID 
inner join Route_Table R on R.Route_ID=S.Route_ID where 
R.Route_ID in(select Route_ID from Route_Table where [From]=@From and [To]=@To) and 
DateOfJourney in(select DateOfJourney from Schedule_Table where [DateOfJourney]=@doj);
end
GO
USE [master]
GO
ALTER DATABASE [Team4] SET  READ_WRITE 
GO
