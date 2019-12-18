USE [RequestLog]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 06/12/2019 11:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Content] [text] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetLog]    Script Date: 06/12/2019 11:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLog]
@IdOffset bigint
as
begin
select top 10 * from Log where Id>@IdOffset and Content NOT LIKE '' order by Id Desc
end
GO
/****** Object:  StoredProcedure [dbo].[InsertLog]    Script Date: 06/12/2019 11:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLog] 
@DateTime varchar(30),
@Content text
as
begin
insert into Log([DateTime],[Content]) values (Convert(datetime,@DateTime,120), @Content)
end
GO
