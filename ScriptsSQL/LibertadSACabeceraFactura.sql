USE [LibertadSACabeceraFactura]
GO
/****** Object:  Table [dbo].[Headers]    Script Date: 06/12/2019 11:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StockSystem] [varchar](10) NULL,
	[IdMessage] [varchar](50) NULL,
	[BranchID] [varchar](10) NULL,
	[TrxId] [varchar](20) NULL,
	[TrxDateTime] [varchar](20) NULL,
	[TrxDocType] [varchar](5) NULL,
	[ClientDoc] [varchar](15) NULL,
	[ClientName] [varchar](50) NULL,
	[ClientAdress] [varchar](50) NULL,
	[GUID] [varchar](40) NULL,
 CONSTRAINT [PK_Headers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Insert_DocumentHeader]    Script Date: 06/12/2019 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_DocumentHeader] 
@StockSystem varchar(10),
@IdMessage  varchar(50),
@BranchId  varchar(10),
@TrxId  varchar(20),
@TrxDateTime  varchar(20),
@TrxDocType  varchar(5),
@ClientDoc  varchar(15),
@ClientName  varchar(50),
@ClientAdress  varchar(50),
@GUID  varchar(40)

as
begin
insert into Headers(StockSystem, IdMessage, BranchID, TrxId, TrxDateTime, TrxDocType, ClientDoc, ClientName, ClientAdress, [GUID])
values (@StockSystem, @IdMessage,@BranchId,@TrxId,@TrxDateTime, @TrxDocType, @ClientDoc, @ClientName, @ClientAdress,@GUID)
end
GO
