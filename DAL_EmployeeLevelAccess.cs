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
using System.Data.SqlClient;
using System.Net;

/// <summary>
/// Summary description for DAL_EmployeeLevelAccess
/// </summary>
public class DAL_EmployeeLevelAccess
{
    string connStr = ConfigurationManager.ConnectionStrings["DBConnHRM"].ToString();
    string DBConnCal = ConfigurationManager.ConnectionStrings["DBConnCAL"].ToString();
    SqlTransaction mytrans = null;

	public DAL_EmployeeLevelAccess()
	{
		
	}
    public int Insert(DataTable dt, int aclLevel)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlConnection conn1 = new SqlConnection(connStr);
        conn.Open(); conn1.Open();
        SqlCommand dCmd1 = null;
        mytrans = conn.BeginTransaction();
        try
        {
            dCmd1 = new SqlCommand("SP_Delete_EmployeeLevelMenuAccess_Mst", conn);
            dCmd1.CommandType = CommandType.StoredProcedure;
            dCmd1.Transaction = mytrans;
            dCmd1.Parameters.AddWithValue("@Employee_Code", dt.Rows[0]["Employee_Code"]);
            dCmd1.Parameters.AddWithValue("@aclLevel", aclLevel);
            dCmd1.ExecuteNonQuery();


            SqlBulkCopy sbc = new SqlBulkCopy(conn1);
            if (aclLevel == 2)
            {
                sbc.DestinationTableName = "tbl_EmployeeAccessRight";
            }
            if (aclLevel == 1)
            {
                sbc.DestinationTableName = "tbl_ERPEmployeeAccessRight";
            }
            sbc.WriteToServer(dt);
            mytrans.Commit();
            return 1;
        }
        catch
        {
            mytrans.Rollback();
            throw;

        }
        finally
        {
            conn1.Close();
            conn1.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadChildMenu(string Employee_Code, int ParentID)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_ChildEmployeeLevelMenuAccessAll", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@ParentID", ParentID);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadChildEmployeeMenu(string Company_Code, string Branch_Code, string Department_Code, string Designation_Code, string PositionLevel_Code, string Employee_Code, string ParentID, int aclLevel)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_EmployeeLevelMenuAccessAll", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Company_Code", Company_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Branch_Code", Branch_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Department_Code", Department_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Designation_Code", Designation_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@PositionLevel_Code", PositionLevel_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@ParentID", ParentID);
            dAd.SelectCommand.Parameters.AddWithValue("@aclLevel", aclLevel);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable Check_EmployeeLevelMenu(string Company_Code, string Branch_Code, string Department_Code, string Designation_Code, string PositionLevel_Code, string MenuID, int aclLevel)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_Check_EmployeeLevelMenuAccess_Mst", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Company_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Branch_Code", Branch_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Department_Code", Department_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Designation_Code", Designation_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@PositionLevel_Code", PositionLevel_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@MenuID", MenuID);
            dAd.SelectCommand.Parameters.AddWithValue("@aclLevel", aclLevel);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public int InsertDefaultAccess(string Employee_Code, int aclLevel)
    {
        SqlConnection conn = new SqlConnection(connStr);
       
        conn.Open(); 
        SqlCommand dCmd1 = null;
        mytrans = conn.BeginTransaction();
        try
        {
            dCmd1 = new SqlCommand("SP_Delete_EmployeeLevelMenuAccess_Mst", conn);
            dCmd1.CommandType = CommandType.StoredProcedure;
            dCmd1.Transaction = mytrans;
            dCmd1.Parameters.AddWithValue("@Employee_Code",Employee_Code);
            dCmd1.Parameters.AddWithValue("@aclLevel", aclLevel);
            dCmd1.ExecuteNonQuery();
            mytrans.Commit();
            return 1;
        }
        catch
        {
            mytrans.Rollback();
            throw;

        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadEmployeeCompanyAccess(string Employee_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_EmployeeCompanyAccessAll", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadEmployeeBranchAccess(string Employee_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_EmployeeBranchAccessAll", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadEmployeeDepartmentAccess(string Employee_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_EmployeeDepartmentAccessAll", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataTable LoadEmployeeChain(string Employee_Code, string Company, string Branch, string Department)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("usp_EmployeeChain", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Emp", Employee_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Company);
            dAd.SelectCommand.Parameters.AddWithValue("@branch", Branch);
            dAd.SelectCommand.Parameters.AddWithValue("@dept", Department);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public DataTable LoadEmployeeBranchAccessByCompany(string Employee_Code, string Comp_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("usp_SelectEmployeeBrachAccessByCompany", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Comp_Code);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }

    }

    public DataTable LoadEmployeeHeirarchy(string Employee_Code, string Company, string Branch, string Department)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("usp_EmployeehierarchicalChart", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Emp", Employee_Code);
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Company);
            dAd.SelectCommand.Parameters.AddWithValue("@branch", Branch);
            dAd.SelectCommand.Parameters.AddWithValue("@dept", Department);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DataSet MenuAccessDetails(string Employee_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_SELECT_MenuAccessDetails", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", Employee_Code);
            dAd.Fill(dSet);
            return dSet;
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public int InsertEmployeeLevelMenuAccess(DataTable dt)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlConnection conn1 = new SqlConnection(connStr);
        conn.Open(); conn1.Open();
        SqlCommand dCmd1 = null;
        mytrans = conn.BeginTransaction();
        try
        {
            dCmd1 = new SqlCommand("SP_DeleteEmployeeLevelMenuAccess", conn);
            dCmd1.CommandType = CommandType.StoredProcedure;
            dCmd1.Transaction = mytrans;
            dCmd1.Parameters.AddWithValue("@Employee_Code", dt.Rows[0]["Employee_Code"]);
            dCmd1.ExecuteNonQuery();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dCmd1 = new SqlCommand("SP_InsertEmployeeLevelMenuAccess", conn);
                dCmd1.CommandType = CommandType.StoredProcedure;
                dCmd1.Transaction = mytrans;
                dCmd1.Parameters.AddWithValue("@Employee_Code", dt.Rows[i]["Employee_Code"]);
                dCmd1.Parameters.AddWithValue("@MenuID", dt.Rows[i]["MenuID"]);
                dCmd1.Parameters.AddWithValue("@C", dt.Rows[i]["C"]);
                dCmd1.Parameters.AddWithValue("@R", dt.Rows[i]["R"]);
                dCmd1.Parameters.AddWithValue("@U", dt.Rows[i]["U"]);
                dCmd1.Parameters.AddWithValue("@D", dt.Rows[i]["D"]);
                dCmd1.Parameters.AddWithValue("@IPAddress", dt.Rows[i]["IPAddress"]);
                dCmd1.Parameters.AddWithValue("@CreatedBY", dt.Rows[i]["CreatedBY"]);
                dCmd1.Parameters.AddWithValue("@CreatedOn", dt.Rows[i]["CreatedOn"]);
                dCmd1.Parameters.AddWithValue("@Status", dt.Rows[i]["Status"]);
                dCmd1.Parameters.AddWithValue("@Allow", dt.Rows[i]["Allow"]);
                dCmd1.ExecuteNonQuery();

            }
            mytrans.Commit();
            return 1;
        }
        catch
        {
            mytrans.Rollback();
            throw;

        }
        finally
        {
            conn1.Close();
            conn1.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    // ERP Data Entry Status
    // Added By : Sunil Kumar Singh
    // Add On : 19/06/2015
    public DataTable LoadDataEntryStatus(string dte, int days)
    {
        SqlConnection conn = new SqlConnection(DBConnCal);
        SqlDataAdapter dAd = new SqlDataAdapter("usp_ERP_DataEntry_Status", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dtable = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Dt", dte);
            dAd.SelectCommand.Parameters.AddWithValue("@dy", days);
            dAd.Fill(dtable);
            return dtable;
        }
        catch
        {
            throw;
        }
        finally
        {
            dtable.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    // Branch Fill By Company Code
    // Added By : Sunil Kumar Singh
    // Add On : 30/06/2015
    public DataTable LoadBranchByCompanyCode(string Comp_Code)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("SP_SELECT_BranchByCompCode", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Comp_Code);
            dAd.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            dt.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }

    }
}
