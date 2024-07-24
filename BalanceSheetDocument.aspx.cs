using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using AjaxControlToolkit;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using System.Configuration;
public partial class FAMS_MIS_BalanceSheetDocument : System.Web.UI.Page
{
    FillTreeControl objtree = new FillTreeControl();
    BALFAMIS BS = new BALFAMIS();
    BAL_EmployeeLevelAccess access = new BAL_EmployeeLevelAccess();
    Message msg = new Message();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CalYear();
            Fill_Company();
            BindData();
            Fill_CompanyPopup();
            Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());

        }
    }
    void Page_PreRender(object obj, EventArgs e)
    {
        ViewState["update"] = Session["update"];
    }
    protected void ddlCompany_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (ddlCompany.SelectedValue != "0")
        //{
        //    // Add your logic here
        //}
    }

    protected void Fill_Company()
    {
        ddlCompany.Items.Clear();
        DataTable dt = access.LoadEmployeeCompanyAccess(Session["Employee_Code"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlCompany.DataSource = dt;
            ddlCompany.DataTextField = "Comp_Name";
            ddlCompany.DataValueField = "Comp_Code";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));
        }
        else
        {
            ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));
        }
    }

    protected void Fill_CompanyPopup()
    {
        ddlCompanyPopup.Items.Clear();
        DataTable dt = access.LoadEmployeeCompanyAccess(Session["Employee_Code"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlCompanyPopup.DataSource = dt;
            ddlCompanyPopup.DataTextField = "Comp_Name";
            ddlCompanyPopup.DataValueField = "Comp_Code";
            ddlCompanyPopup.DataBind();
            ddlCompanyPopup.Items.Insert(0, new ListItem("Select Company", "0"));
        }
        else
        {
            ddlCompanyPopup.Items.Insert(0, new ListItem("Select Company", "0"));
        }
    }

    protected void ddlFinancial_SelectedIndexChanged1(object sender, EventArgs e)
    {
        // Add your logic here
    }

    private void CalYear()
    {
        DateTime dtm = DateTime.Now;
        ArrayList Year = new ArrayList
        {   
            Convert.ToString(dtm.Year - 9) + "-" + Convert.ToString(dtm.Year - 8),
            Convert.ToString(dtm.Year - 8) + "-" + Convert.ToString(dtm.Year - 7),
            Convert.ToString(dtm.Year - 7) + "-" + Convert.ToString(dtm.Year - 6),
            Convert.ToString(dtm.Year - 6) + "-" + Convert.ToString(dtm.Year - 5),
            Convert.ToString(dtm.Year - 5) + "-" + Convert.ToString(dtm.Year - 4),
            Convert.ToString(dtm.Year - 4) + "-" + Convert.ToString(dtm.Year - 3),
            Convert.ToString(dtm.Year - 3) + "-" + Convert.ToString(dtm.Year - 2),
            Convert.ToString(dtm.Year - 2) + "-" + Convert.ToString(dtm.Year - 1),
            Convert.ToString(dtm.Year - 1) + "-" + Convert.ToString(dtm.Year),
            Convert.ToString(dtm.Year)  +  "-" +Convert.ToString(dtm.Year + 1)
        };

        ddlFinancial.DataSource = Year;
        ddlFinancial.DataBind();
        ddlFinancial.Items.Insert(0, new ListItem("All", "0"));

        ddlFinancialPopup.DataSource = Year;
        ddlFinancialPopup.DataBind();
        ddlFinancialPopup.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Fill_CompanyPopup();
        CalYear();

    }

    protected void btnSavePopup_Click(object sender, EventArgs e)
    {
        
            ErrorContainer.Visible = true;
            int result = 0;

            string filepath = "";
            string ext = "";
            string directoryPath = "";
            string fileName = string.Empty;

          
                        if (fuDocument != null && fuDocument.HasFile)
                        {
                        string DMS_Path = ConfigurationManager.AppSettings["DMSPATH_Calyx"].ToString();
                        ext = System.IO.Path.GetExtension(fuDocument.PostedFile.FileName).Substring(1);
                        filepath = "Calyx\\BS\\";
                        directoryPath = DMS_Path + filepath;

                        if (Path.GetExtension(fuDocument.FileName) == ".pdf" || Path.GetExtension(fuDocument.FileName) == ".jpeg" || Path.GetExtension(fuDocument.FileName) == ".jpg" || Path.GetExtension(fuDocument.FileName) == ".png")
                        {
                            result = BS.FA_Balance_Sheet_Document(ddlCompanyPopup.SelectedValue, ddlCompanyPopup.SelectedItem.Text, ddlFinancialPopup.SelectedValue, Convert.ToString(Session["Employee_Code"]), directoryPath, fuDocument);
     
                        }

                        if (result > 0)
                        {
                            Session["update"] = Server.UrlEncode(DateTime.Now.ToString());
                            msg.ShowMessage("Submitted Successfully.", null, ErrorContainer, MyMessage, "Success");
                        }
                        else
                        {
                          
                            ErrorContainer.Visible = true;
                            msg.ShowMessage("Failed to submit the document.", null, ErrorContainer, MyMessage, "Warning");
                        }
                    }
                        else
                        {
                            ErrorContainer.Visible = true;
                            msg.ShowMessage("Only PDF , JPEG, JPG, PNG files (*.pdf,.jpeg, .jpg,.png) are allowed to be uploaded.", null, ErrorContainer, MyMessage, "Warning");
                           
                        }
                    
                     //else
                     //   {
                     //       ErrorContainer.Visible = true;
                     //       msg.ShowMessage("Please select a file to upload.", null, ErrorContainer, MyMessage, "Warning");
                     //   }
                    
                    }
                    



                    
                
    //                        if (!File.Exists(filepath))
    //                        {
    //                            if (!Directory.Exists(filepath))
    //                            {
    //                                Directory.CreateDirectory(filepath);
    //                                Directory.CreateDirectory(filepath);
    //                            }
    //                            fuDocument.PostedFile.SaveAs(filepath); // Save the file
    //                        }
    //                        else
    //                        {
    //                            msg.ShowMessage("PDF file already exists.", null, ErrorContainer, MyMessage, "Warning");
    //                            return;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        msg.ShowMessage("PDF file size must be less than 10000000 bytes.", null, ErrorContainer, MyMessage, "Warning");
    //                        return;
    //                    }
    //                }
    //                else
    //                {
    //                    msg.ShowMessage("Please upload PDF files only.", null, ErrorContainer, MyMessage, "Warning");
    //                    return;
    //                }
    //            }

    //            result = BS.FA_Balance_Sheet_Document(ddlCompanyPopup.SelectedValue, ddlCompanyPopup.SelectedItem.Text, ddlFinancialPopup.SelectedValue, Convert.ToString(Session["Employee_Code"]), HdnUploaded_date.Value, fileName);
    //        }

    //        if (result > 0)
    //        {
    //            Session["update"] = Server.UrlEncode(DateTime.Now.ToString());
    //            msg.ShowMessage("Submitted Successfully.", null, ErrorContainer, MyMessage, "Success");
    //        }
    //        else
    //        {
    //            if (File.Exists(path))
    //            {
    //                File.Delete(path);
    //            }
    //            msg.ShowMessage("Submission failed: Try Again", null, ErrorContainer, MyMessage, "Warning");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        msg.ShowMessage("Error: " + ex.Message, null, ErrorContainer, MyMessage, "Error");
    //    }
    //}










    private void BindData()
    {
        string compName = ddlCompany.SelectedValue;
        string fy = ddlFinancial.SelectedValue; // Assuming FY should come from ddlFinancial

        DataSet dt = BS.FA_GET_Balance_Sheet_Documents(compName, fy);
        if (dt.Tables[0].Rows.Count > 0)
        {

            GVVoucherApproval.DataSource = dt.Tables[0];
            GVVoucherApproval.DataBind();
        }
        else
        {

            GVVoucherApproval.DataSource = null;
            GVVoucherApproval.DataBind();
        }


    }



    protected void btnShow_Click(object sender, EventArgs e)
    {

        BindData();
    }

 
 
}

   

