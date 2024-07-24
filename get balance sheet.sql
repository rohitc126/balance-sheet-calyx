USE [CALYX_Test]
GO

/****** Object:  StoredProcedure [dbo].[USP_GET_Balance_Sheet_Documents]    Script Date: 7/24/2024 6:43:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




 
--- Created By   :Rohit Chaurasiya
--- Created Date : 17/07/2024
--- Description  :USP_GET_Balance_Sheet_Documents
  
---- [dbo].[USP_GET_Balance_Sheet_Documents] 'CO00000002','0'
 
-----=================================================================  
CREATE PROCEDURE [dbo].[USP_GET_Balance_Sheet_Documents]
@Comp_Code varchar(50),
@FY  varchar(50)= null
AS
BEGIN
 SELECT BSD_ID, b.Comp_Name, FY, (case When a.File_Name Is null Then '' else  ( a.File_Path+a.File_Name) end) 
 as File_Path  , Isnull(a.File_Name,'') as File_Name,
 Uploaded_by, Uploaded_date, a.Status
    FROM Tbl_Balance_Sheet_Document as a 
	inner join HRM.dbo.tbl_Company_Mst as b on  a.Comp_Code = b.Comp_Code
    WHERE a.Status = 'Y' and 
	     a.Comp_Code =@Comp_Code and (a.FY = @FY OR @FY='0'  )
		  --( a.Comp_Code =@Comp_Name OR ISNULL (@Comp_Name, '')='')
	END

GO

