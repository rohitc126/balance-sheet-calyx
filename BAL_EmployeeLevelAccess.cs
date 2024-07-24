using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
/// <summary>
/// Summary description for BAL_EmployeeLevelAccess
/// </summary>
public class BAL_EmployeeLevelAccess
{
	public BAL_EmployeeLevelAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(DataTable dt, int aclLevel)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.Insert(dt, aclLevel);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataTable LoadChildMenu(string Employee_Code, int ParentID)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadChildMenu(Employee_Code, ParentID);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataTable LoadChildEmployeeMenu(string Company_Code, string Branch_Code, string Department_Code, string Designation_Code, string PositionLevel_Code, string Employee_Code, string ParentID,int aclLevel)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadChildEmployeeMenu(Company_Code, Branch_Code, Department_Code, Designation_Code, PositionLevel_Code, Employee_Code, ParentID, aclLevel);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataTable Check_EmployeeLevelMenu(string Company_Code, string Branch_Code, string Department_Code, string Designation_Code, string PositionLevel_Code,string  MenuID,int aclLevel)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.Check_EmployeeLevelMenu(Company_Code, Branch_Code, Department_Code, Designation_Code, PositionLevel_Code, MenuID, aclLevel);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    
    }
    public int InsertDefaultAccess(string Employee_Code,int aclLevel)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.InsertDefaultAccess(Employee_Code, aclLevel);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataTable LoadEmployeeCompanyAccess(string Employee_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeCompanyAccess(Employee_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }

    public DataTable LoadEmployeeBranchAccess(string Employee_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeBranchAccess(Employee_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }

    public DataTable LoadEmployeeDepartmentAccess(string Employee_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeDepartmentAccess(Employee_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataTable LoadEmployeeChain(string Employee_Code,string Company,string Branch,string Department)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeChain(Employee_Code,Company,Branch,Department);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }

    public DataTable LoadEmployeeBranchAccessByCompany(string Employee_Code, string Comp_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeBranchAccessByCompany(Employee_Code, Comp_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }

    public DataTable LoadEmployeeHeirarchy(string Employee_Code, string Company, string Branch, string Department)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadEmployeeHeirarchy(Employee_Code, Company, Branch, Department);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public DataSet MenuAccessDetails(string Employee_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.MenuAccessDetails(Employee_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
    public int InsertEmployeeLevelMenuAccess(DataTable dt)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.InsertEmployeeLevelMenuAccess(dt);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }

    }

    // ERP Data Entry Status
    // Added By : Sunil Kumar Singh
    // Add On : 19/06/2015
    public DataTable LoadDataEntryStatus(string dte, int days)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadDataEntryStatus(dte, days);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }


    // Branch Fill By Company Code
    // Added By : Sunil Kumar Singh
    // Add On : 30/06/2015
    public DataTable LoadBranchByCompanyCode(string Comp_Code)
    {
        DAL_EmployeeLevelAccess EmployeeLevelAccessDAL = new DAL_EmployeeLevelAccess();
        try
        {
            return EmployeeLevelAccessDAL.LoadBranchByCompanyCode(Comp_Code);
        }
        catch
        {
            throw;
        }
        finally
        {
            EmployeeLevelAccessDAL = null;
        }
    }
}
