USE [LibertadSAStock]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 06/12/2019 12:31:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ArtCod] [varchar](15) NOT NULL,
	[BranchCod] [varchar](15) NOT NULL,
	[Quantity] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 06/12/2019 12:31:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStock]
@ArtCod varchar(15),
@BranchCod varchar(15),
@Quantity decimal(18,3)

as
begin

declare @Result bigint
set @Result = (Select Count(Id) from Stock where ArtCod=@ArtCod and BranchCod=@BranchCod)

if (@Result=1)
begin
	declare @OldStock decimal(18,2)
	set @OldStock = (Select Quantity from Stock where ArtCod=@ArtCod and BranchCod=@BranchCod)
	Update Stock set Quantity=(@OldStock+@Quantity) where ArtCod=@ArtCod and BranchCod=@BranchCod 
	return 0
end

if(@Result=0)
begin
	Insert into Stock(ArtCod, BranchCod, Quantity) values (@ArtCod,@BranchCod,@Quantity)
	return 1
end

if(@Result>1)
begin
	return -1
end



end
GO
