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


public class BALFAMIS
{
    public BALFAMIS()
    {

    }

    // Created By : Devendra Kumar Date: 08/09/2015
    public DataSet FA_CustLedger(double custCode, string fromDate, string toDate, string RepBase, string RepOn)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_CustLedger(custCode, fromDate, toDate, RepBase, RepOn);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_EmployeeLedger(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_EmployeeLedger(compCode, region, branchCode, FolioNo, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }


    public DataTable FA_GeneralLedger(string compCode, string region, string branchCode, double lgrGruopCode, double lgrCode, string FolioNo, string fromDate, string toDate)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_GeneralLedger(compCode, region, branchCode, lgrGruopCode, lgrCode, FolioNo, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    // Created By : Devendra Kumar Date: 15/01/2016
    public DataSet FA_EmployeeLedger_V1(int lid, string EmpCode, string fromDate, string toDate)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_EmployeeLedger_V1(lid, EmpCode, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    //--- Added By   : Ashish Kalsarpe
    //--- Added Date : 01/10/2016 
    //----===========================================================================
    public DataSet FA_Cust_TDS_Register(double custCode, string fromDate, string toDate)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Cust_TDS_Register(custCode, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }


    //--- Added By    : Ashish Kalsarpe
    //--- Added Date  : 06/10/2016 
    //--- Description : Service Tax Register
    //----===========================================================================

    public DataSet FA_Cust_ServiceTax_Register(double custCode, string fromDate, string toDate)
    {

        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Cust_ServiceTax_Register(custCode, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataSet Company_Tds_Book(string type, string payToId, string fromDate, string toDate, string brCode)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.Company_Tds_Book(type, payToId, fromDate, toDate, brCode);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    //----- Added By    : Ashish Kalsarpe --- Date : 22/09/2022---
    //----- Description : Vendor Ledger Report -------------------
    public DataTable FA_Vendor_Ledger(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Vendor_Ledger(compCode, region, branchCode, FolioNo, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    //----- Added By    : Ashish Kalsarpe --- Date : 22/09/2022---
    //----- Description : Cust Ledger V1 Report -------------------
    public DataTable FA_Cust_LedgerV1(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Cust_LedgerV1(compCode, region, branchCode, FolioNo, fromDate, toDate);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }


    //----- Added By    : Ashish Kalsarpe --- Date : 07/12/2022---
    //----- Description : Cust Ledger V1 Report -------------------
    public DataTable FA_Vendor_Register(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate, int typ)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Vendor_Register(compCode, region, branchCode, FolioNo, fromDate, toDate, typ);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Vendor_Opening_Closing_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Vendor_Opening_Closing_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Customer_Opening_Closing_Statetment(string FinYear, int lid, int compareMIS)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Customer_Opening_Closing_Statetment(FinYear, lid, compareMIS);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }


    public DataTable FA_Customer_Opening_Closing_Statetment_Dtls(string FinYear, int lid, string JFolioNo)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Customer_Opening_Closing_Statetment_Dtls(FinYear, lid, JFolioNo);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Customer_Opening_Closing_Aging_Statetment(string FinYear)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Customer_Opening_Closing_Aging_Statetment(FinYear);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Vendor_Opening_Closing_Aging_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Vendor_Opening_Closing_Aging_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Vendor_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Vendor_Opening_Closing_Br_Wise_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Employee_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Employee_Opening_Closing_Br_Wise_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Cust_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Cust_Opening_Closing_Br_Wise_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_BrLedger_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_BrLedger_Opening_Closing_Br_Wise_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    public DataTable FA_Ledger_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Ledger_Opening_Closing_Br_Wise_Statetment(FinYear, lid);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }

    //======================================================ADDED BY ROHIT ON 15-07-2024====================================
    public int FA_Balance_Sheet_Document(string Comp_Code, string Comp_Name, string FY, string Uploaded_by, string directoryPath, FileUpload postFile)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_Balance_Sheet_Document(Comp_Code, Comp_Name, FY, Uploaded_by, directoryPath, postFile);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }
    }
    public DataSet FA_GET_Balance_Sheet_Documents(string Comp_Name, string FY)
    {
        DALFAMIS rpt = new DALFAMIS();
        try
        {
            return rpt.FA_GET_Balance_Sheet_Documents(Comp_Name, FY);
        }
        catch
        {
            throw;
        }
        finally
        {
            rpt = null;
        }

    }
}