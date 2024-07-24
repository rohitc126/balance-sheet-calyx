using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Globalization;
using System.Resources;
using System.IO;

public class DALFAMIS
{
    string DBConnCFSCAL = null;
    string DBConnTrimaxCAL = ConfigurationManager.ConnectionStrings["DBConnCAL"].ToString();
    string DBConnCFS = null;

    SqlTransaction mytrans = null;
    string[] conStr = { };

	public DALFAMIS()
	{
        if (conStr.Length == 0)
        {
            ServerSelectionV2.switchServer(ref conStr);
        }
        if (conStr.Length > 0)
        {
            DBConnCFSCAL = conStr[0];
            DBConnCFS = conStr[1];
        }
		
	}

    // Created By : Devendra Kumar Date: 08/09/2015
    public DataSet FA_CustLedger(double custCode, string fromDate, string toDate, string RepBase, string RepOn)
    {
        SqlConnection conn = new SqlConnection(DBConnCFSCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_CustLedger", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 1200;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@custCode", custCode);
            dAd.SelectCommand.Parameters.AddWithValue("@fDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@eDate", toDate);
            dAd.SelectCommand.Parameters.AddWithValue("@RepBase", RepBase);
            dAd.SelectCommand.Parameters.AddWithValue("@RepOn", RepOn);

            dAd.Fill(dSet, "tbl_FA_CustLedger");
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

    // Created By : Devendra Kumar Date: 07/01/2016
    public DataTable FA_EmployeeLedger(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);       
        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_EmployeeLedger", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@compCode", compCode);
            dAd.SelectCommand.Parameters.AddWithValue("@region", region);
            dAd.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            dAd.SelectCommand.Parameters.AddWithValue("@FolioNo", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@toDate", toDate);

            dAd.Fill(dSet, "FA_EmployeeLedger");
            return dSet.Tables["FA_EmployeeLedger"];
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

    // Created By : Devendra Kumar Date: 09/01/2016
    public DataTable FA_GeneralLedger(string compCode, string region, string branchCode, double lgrGruopCode, double lgrCode, string FolioNo, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_GeneralLedger", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 1200;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@compCode", compCode);
            dAd.SelectCommand.Parameters.AddWithValue("@region", region);
            dAd.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            dAd.SelectCommand.Parameters.AddWithValue("@lgrGruopCode", lgrGruopCode);
            dAd.SelectCommand.Parameters.AddWithValue("@lgrCode", lgrCode);
            dAd.SelectCommand.Parameters.AddWithValue("@FolioNo", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@toDate", toDate);

            dAd.Fill(dSet, "FA_GeneralLedger");
            return dSet.Tables["FA_GeneralLedger"];
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


    // Created By : Devendra Kumar Date: 15/01/2016
    public DataSet FA_EmployeeLedger_V1(int lid,string EmpCode, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_EmployeeLedger_V1", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.SelectCommand.Parameters.AddWithValue("@Employee_Code", EmpCode);
            dAd.SelectCommand.Parameters.AddWithValue("@fDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@eDate", toDate);

            dAd.Fill(dSet, "tbl_FA_EmpLedger");
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

    //--- Added By   : Ashish Kalsarpe
    //--- Added Date : 01/10/2016 
    //----===========================================================================

    public DataSet FA_Cust_TDS_Register(double custCode, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnCFSCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_Cust_TDS_Register", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 240;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@custCode", custCode);
            dAd.SelectCommand.Parameters.AddWithValue("@fDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@eDate", toDate);

            dAd.Fill(dSet, "tbl_FA_CustLedger_TDS");
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



    //--- Added By    : Ashish Kalsarpe
    //--- Added Date  : 06/10/2016 
    //--- Description : Service Tax Register
    //----===========================================================================

    public DataSet FA_Cust_ServiceTax_Register(double custCode, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnCFSCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_Cust_STAX_Register", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 120;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@custCode", custCode);
            dAd.SelectCommand.Parameters.AddWithValue("@fDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@eDate", toDate);

            dAd.Fill(dSet, "tbl_FA_CustLedger_TDS");
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

    //Added By : Pramesh Kumar Vishwakarma, Date : 27-03-2017, Desc: Company Tds Book
    public DataSet Company_Tds_Book(string type, string payToId, string fromDate, string toDate, string brCode)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_Rpt_Company_Tds_Book", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 120;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@PayToTy", type);
            dAd.SelectCommand.Parameters.AddWithValue("@PayToId", payToId);
            dAd.SelectCommand.Parameters.AddWithValue("@fDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@eDate", toDate);
            dAd.SelectCommand.Parameters.AddWithValue("@JBranch_Code", brCode);


            dAd.Fill(dSet, "Company_Tds_Book");
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


    //----- Added By    : Ashish Kalsarpe --- Date : 22/09/2022---
    //----- Description : Vendor Ledger Report -------------------
    public DataTable FA_Vendor_Ledger(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_Vendor_Ledger", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 120;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@compCode", compCode);
            dAd.SelectCommand.Parameters.AddWithValue("@region", region);
            dAd.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);        
            dAd.SelectCommand.Parameters.AddWithValue("@FolioNo", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@toDate", toDate);

            dAd.Fill(dSet, "FA_VendorLedger");
            return dSet.Tables["FA_VendorLedger"];
          

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


    //----- Added By    : Ashish Kalsarpe --- Date : 22/09/2022---
    //----- Description : Cust Ledger V1 Report -------------------
    public DataTable FA_Cust_LedgerV1(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("usp_FA_Cusromer_LedgerV1", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 120;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@compCode", compCode);
            dAd.SelectCommand.Parameters.AddWithValue("@region", region);
            dAd.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            dAd.SelectCommand.Parameters.AddWithValue("@FolioNo", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@toDate", toDate);

            dAd.Fill(dSet, "FA_Cusromer_LedgerV1");
            return dSet.Tables["FA_Cusromer_LedgerV1"];


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

    //----- Added By    : Ashish Kalsarpe --- Date : 07/12/2022---
    //----- Description : Cust Ledger V1 Report -------------------
    public DataTable FA_Vendor_Register(string compCode, string region, string branchCode, string FolioNo, string fromDate, string toDate, int typ)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);

        SqlDataAdapter dAd = new SqlDataAdapter("USP_Get_Vendor_Register", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 120;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@compCode", compCode);
            dAd.SelectCommand.Parameters.AddWithValue("@region", region);
            dAd.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            dAd.SelectCommand.Parameters.AddWithValue("@FolioNo", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            dAd.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
            dAd.SelectCommand.Parameters.AddWithValue("@vcode", FolioNo);
            dAd.SelectCommand.Parameters.AddWithValue("@typ", typ);

            dAd.Fill(dSet, "FA_Vendor_Reg");
            return dSet.Tables["FA_Vendor_Reg"];


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





    public DataTable FA_Vendor_Opening_Closing_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Vendor_Yearly_Opn_Closing_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Vendor_Reg");
            return dSet.Tables["FA_Vendor_Reg"];
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

    public DataTable FA_Customer_Opening_Closing_Statetment(string FinYear, int lid=0, int compareMIS=0)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("Usp_Get_Cust_Yearly_OpnClosing_Statetment", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            if (lid == 0)
            {
                dAd.SelectCommand.Parameters.AddWithValue("@lid", DBNull.Value);
            }
            else
            {
                dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            }
            dAd.SelectCommand.Parameters.AddWithValue("@compareMIS", compareMIS);            
            dAd.Fill(dSet, "FA_Cust_Reg");
            return dSet.Tables["FA_Cust_Reg"];
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

    public DataTable FA_Customer_Opening_Closing_Statetment_Dtls(string FinYear, int lid, string JFolioNo)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("Usp_Get_Cust_Yearly_OpnClosing_Statetment_Dtls", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            if (lid == 0)
            {
                dAd.SelectCommand.Parameters.AddWithValue("@lid", DBNull.Value);
            }
            else
            {

                dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            }
            dAd.SelectCommand.Parameters.AddWithValue("@JFolioNo", JFolioNo);
            dAd.Fill(dSet, "FA_Cust_Yearly_OpnClosing_Statetment_Dtls");
            return dSet.Tables["FA_Cust_Yearly_OpnClosing_Statetment_Dtls"];
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



    public DataTable FA_Customer_Opening_Closing_Aging_Statetment(string FinYear)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("Usp_Get_Cust_Yearly_OpnClosing_Aging_Statetment", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
           
            dAd.Fill(dSet, "FA_Cust_Aging");
            return dSet.Tables["FA_Cust_Aging"];
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

    public DataTable FA_Vendor_Opening_Closing_Aging_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("Usp_Get_Vendor_Yearly_OpnClosing_Aging_Statetment", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Vendor_Aging");
            return dSet.Tables["FA_Vendor_Aging"];
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


    public DataTable FA_Vendor_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Vendor_Yearly_Opn_Closing_Br_Wise_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Vendor_Br_Reg");
            return dSet.Tables["FA_Vendor_Br_Reg"];
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

    public DataTable FA_Employee_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Employee_Yearly_Opn_Closing_Br_Wise_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Employee_Br_Reg");
            return dSet.Tables["FA_Employee_Br_Reg"];
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


    public DataTable FA_Cust_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Customer_Yearly_Opn_Closing_Br_Wise_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Cust_Br_Reg");
            return dSet.Tables["FA_Cust_Br_Reg"];
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


    public DataTable FA_BrLedger_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_BrLedger_Yearly_Opn_Closing_Br_Wise_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_BrLedger_Br_Reg");
            return dSet.Tables["FA_BrLedger_Br_Reg"];
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

    public DataTable FA_Ledger_Opening_Closing_Br_Wise_Statetment(string FinYear, int lid)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Ledger_Yearly_Opn_Closing_Br_Wise_Statement", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@FinYear", FinYear);
            dAd.SelectCommand.Parameters.AddWithValue("@lid", lid);
            dAd.Fill(dSet, "FA_Ledger_Br_Reg");
            return dSet.Tables["FA_Ledger_Br_Reg"];
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
    //======================================================ADDED BY ROHIT ON 15-07-2024====================================
    //public DataTable FA_Balance_Sheet_Document( string Comp_Code, string FY, string Uploaded_by, string fileName)
    //{
    //    SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
    //    SqlDataAdapter dAd = new SqlDataAdapter("[dbo].[USP_INSERT_Balance_Sheet_Document]", conn);
    //    dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    dAd.SelectCommand.CommandTimeout = 180;
    //    DataSet dSet = new DataSet();
    //    try
    //    {
    //        //dAd.SelectCommand.Parameters.AddWithValue("@BSD_ID", hdnBSD_ID);
    //        dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Comp_Code);
    //        dAd.SelectCommand.Parameters.AddWithValue("@FY", FY);
    //        dAd.SelectCommand.Parameters.AddWithValue("@Uploaded_by", Uploaded_by);
    //        //dAd.SelectCommand.Parameters.AddWithValue("@Uploaded_date", hdnDate);
    //        dAd.SelectCommand.Parameters.AddWithValue("@File_Path", fileName);

    //        dAd.Fill(dSet, "FA_Balance_Sheet");
    //        return dSet.Tables[" FA_Balance_Sheet"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dSet.Dispose();
    //        conn.Close();
    //        conn.Dispose();
    //    }
    //}


    public int FA_Balance_Sheet_Document(string Comp_Code, string Comp_Name, string FY, string Uploaded_by, string directoryPath, FileUpload postFile)
    {
        using (SqlConnection conn = new SqlConnection(DBConnTrimaxCAL))
        {
            SqlTransaction mytrans = null;
            SqlCommand cmd = null;

            try
            {
                conn.Open();
                mytrans = conn.BeginTransaction();
                cmd = new SqlCommand("USP_INSERT_Balance_Sheet_Document", conn, mytrans)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlp = new SqlParameter("@BSD_ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(sqlp);

                cmd.Parameters.AddWithValue("@Comp_Code", Comp_Code);
                cmd.Parameters.AddWithValue("@Comp_Name", Comp_Name);
                cmd.Parameters.AddWithValue("@FY", FY);
                cmd.Parameters.AddWithValue("@Uploaded_by", Uploaded_by);

                if (postFile.HasFile)
                {
                    string ext = Path.GetExtension(postFile.PostedFile.FileName).Substring(1);
                    cmd.Parameters.AddWithValue("@File_Path", directoryPath);
                    cmd.Parameters.AddWithValue("@File_Name", ext);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@File_Path", DBNull.Value);
                    cmd.Parameters.AddWithValue("@File_Name", DBNull.Value);
                }

                cmd.ExecuteNonQuery();

                int bsdId = (int)cmd.Parameters["@BSD_ID"].Value;
                string formatfileName = "";

                if (bsdId != -1)
                {
                    string query = "SELECT File_Name FROM [dbo].[Tbl_Balance_Sheet_Document] WHERE BSD_ID = @BSD_ID";
                    using (SqlCommand getFileNameCmd = new SqlCommand(query, conn, mytrans))
                    {
                        getFileNameCmd.Parameters.AddWithValue("@BSD_ID", bsdId);
                        formatfileName = getFileNameCmd.ExecuteScalar().ToString();
                    }

                    if (postFile.HasFile)
                    {
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        postFile.PostedFile.SaveAs(Path.Combine(directoryPath, formatfileName));
                    }
                }

                mytrans.Commit();
                return bsdId != -1 ? 1 : 0;
            }
            catch
            {
                mytrans.Rollback();
                throw;
            }
        }
    }


    public DataSet FA_GET_Balance_Sheet_Documents(string Comp_Name, string FY)
    {
        SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
        SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Balance_Sheet_Documents", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.CommandTimeout = 180;
        DataSet dSet = new DataSet();
        try
        {
            dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Comp_Name);
            dAd.SelectCommand.Parameters.AddWithValue("@FY", FY);
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
    //public DataTable FA_GET_Balance_Sheet_Documents(string Comp_Name ,string FY)
    //{
    //    SqlConnection conn = new SqlConnection(DBConnTrimaxCAL);
    //    SqlDataAdapter dAd = new SqlDataAdapter("USP_GET_Balance_Sheet_Documents", conn);
    //    dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    dAd.SelectCommand.CommandTimeout = 180;
    //    DataSet dSet = new DataSet();
    //    try
    //    {
    //        dAd.SelectCommand.Parameters.AddWithValue("@Comp_Code", Comp_Name);
    //        dAd.SelectCommand.Parameters.AddWithValue("@FY", FY);
    //        dAd.Fill(dSet, "GET_Balance_Sheet");
    //        return dSet.Tables["GET_Balance_Sheet"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dSet.Dispose();
    //        dAd.Dispose();
    //        conn.Close();
    //        conn.Dispose();
    //    }
    //}
}