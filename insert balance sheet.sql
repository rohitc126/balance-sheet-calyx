USE [CALYX_Test]
GO

/****** Object:  StoredProcedure [dbo].[USP_INSERT_Balance_Sheet_Document]    Script Date: 7/24/2024 6:44:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





 
--- Created By   :Rohit Chaurasiya
--- Created Date : 22/05/2023
--- Description  :
---- Select * from [dbo].[Tbl_Balance_Sheet_Document]
---- [dbo].[USP_INSERT_Balance_Sheet_Document] 5,'CAL0000000001','rrrr','2024-2025','cal0026','16-07-2024',''
 ---- [dbo].[USP_INSERT_Balance_Sheet_Document] 0,'CO00000001','Calyx Container Terminals Private Limited','2023-2024','cal0026','H:\DMS\Calyx\BS\','pdf'
-----=================================================================  



CREATE PROCEDURE [dbo].[USP_INSERT_Balance_Sheet_Document]
@BSD_ID  int OUTPUT,
@Comp_Code varchar(10),
@Comp_Name varchar(50),
@FY varchar(15),
@Uploaded_by    varchar(7),
@File_Path varchar(100),
@File_Name varchar(50) OUTPUT -- Set as output parameter

AS
BEGIN

--DECLARE @FinancialYear varchar(50);
--SET @FinancialYear = Right(@FY,50);

DECLARE @SYear varchar(4);
DECLARE @FYear varchar(4);
SET @SYear = SUBSTRING(@FY,0,5);
SET  @FYear = Right(@FY,4);
--Select @SYear,@FYear


DECLARE @ShortCompName varchar(10);
DECLARE @formatfileName varchar(100);

Declare @count int

Select @ShortCompName= short_name From HRM.dbo.tbl_Company_Mst WHERE  Comp_Code= @Comp_Code


Select @count=1 From  [dbo].[Tbl_Balance_Sheet_Document] WHERE Comp_Code= @Comp_Code AND FY=@FY AND STATUS='Y'
      SET @formatfileName = @ShortCompName + '_BS_FY_' + @SYear+'_'+ @FYear;
	  --SELECT @formatfileName

IF(ISNULL(@count,0)=0)
BEGIN
      SET @formatfileName = @ShortCompName + '_BS_FY_' + @SYear+'_'+ @FYear;

	  Insert Into [dbo].[Tbl_Balance_Sheet_Document]
	  ( 	   
		Comp_Code,
		Comp_Name,
		FY ,
		Uploaded_by , 
		File_Path,		
		File_Name,
		Status	
	  )
	  Values
	   (
		@Comp_Code,
		@Comp_Name,
		@FY, 
		@Uploaded_by,
		@File_Path,
		case when @formatfileName  is not null  then @formatfileName+ '.'+@File_Name  else null end ,

		'Y'
		)

	SET @BSD_ID=(Select SCOPE_IDENTITY())
	END
	ELSE
	BEGIN
	   SET @BSD_ID= -1
	END




END

GO

