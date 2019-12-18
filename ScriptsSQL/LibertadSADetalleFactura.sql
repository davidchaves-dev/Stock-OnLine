USE [LibertadSADetalleFactura]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 06/12/2019 11:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Cant] [decimal](18, 3) NOT NULL,
	[DocCode] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Insert_DocumentItem]    Script Date: 06/12/2019 11:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_DocumentItem]
@Code varchar(15),
@Cant decimal(18,3),
@DocCode varchar(49)
as
begin
	insert into Items(Code, Cant, DocCode) values (@Code, @Cant, @DocCode)
end
GO
