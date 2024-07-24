USE [HRM_Test]
GO

/****** Object:  StoredProcedure [dbo].[SP_SELECT_EmployeeCompanyAccessAll]    Script Date: 7/24/2024 6:53:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================      
-- Author:  <Ashok Kumar>      
-- Create date: <27-07-2011>      
-- Modify By:  <Vinay Kumar Dubey>  -- Create date: <08-04-2013>    
-- Description: <Details View of Branch>      
-- SP_SELECT_EmployeeCompanyAccessAll 'CAL0080'      
-- SP_SELECT_EmployeeCompanyAccessAll ''   
-- =============================================      
CREATE PROCEDURE [dbo].[SP_SELECT_EmployeeCompanyAccessAll]      
@Employee_Code char(7)      
AS      
BEGIN     
  
if @Employee_Code<>''  
begin  
 --select '0000000' as Employee_Code,'CO00000000' as Comp_Code,'All Company' as Comp_Name,'ALL' as short_name    
 --union    
 SELECT     tbl_EmployeeCompanyAccess.Employee_Code, tbl_EmployeeCompanyAccess.Comp_Code, tbl_Company_Mst.Comp_Name,tbl_Company_Mst.short_name,
 tbl_Company_Mst.RegdAddress1,tbl_Company_Mst.RegdAddress2,tbl_Company_Mst.RegdAddress3       
 FROM         tbl_EmployeeCompanyAccess INNER JOIN      
 tbl_Company_Mst ON tbl_EmployeeCompanyAccess.Comp_Code = tbl_Company_Mst.Comp_Code      
 WHERE     (tbl_EmployeeCompanyAccess.Employee_Code = @Employee_Code and tbl_EmployeeCompanyAccess.Status='Y')      
     
 Union      
 SELECT     tbl_EmployeeCompany_Details.Employee_Code, tbl_EmployeeCompany_Details.Comp_Code,       
 tbl_Company_Mst.Comp_Name,tbl_Company_Mst.short_name,tbl_Company_Mst.RegdAddress1,tbl_Company_Mst.RegdAddress2,tbl_Company_Mst.RegdAddress3       
 FROM         tbl_EmployeeCompany_Details INNER JOIN      
  tbl_Company_Mst ON tbl_Company_Mst.Comp_Code = tbl_EmployeeCompany_Details.Comp_Code      
 WHERE     (tbl_EmployeeCompany_Details.Employee_Code = @Employee_Code)     
 end  
   
 else  
 begin  
   
 Select Comp_Name,Comp_Code,RegdAddress1,RegdAddress2,RegdAddress3 From tbl_Company_Mst where ActiveStatus='Active'  
   
 end  
    
    
END      
      
--select * from  tbl_Company_Mst as e inner join tbl_Company_Mst as c on c.Comp_Code=e.Comp_Code  where  Employee_Code='SGX0071'
GO

