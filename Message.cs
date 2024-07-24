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
using System.Text;
using System.IO;
using System.Diagnostics;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    public Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ShowMessage(String Message, Exception ex, Panel PanelContainerID, Label MessageControlID, String ErrorType)
    {


        if ((PanelContainerID == null) == true & (MessageControlID == null) == true)
        {
            if ((ex == null) == false)
            {
                MessageControlID.Text = ex.ToString();
                PanelContainerID.CssClass = "DatabaseError";

            }
            else if ((Message == null) == false)
            {
                MessageControlID.Text = Message.ToString();
                PanelContainerID.CssClass = "ApplicationError";
            }
            else
            {
                PanelContainerID.CssClass = "EmptyError";
                MessageControlID.Text = "";
            }

            return;
        }
        if ((PanelContainerID == null) == false & (MessageControlID == null) == false)
        {
            PanelContainerID.CssClass = "EmptyError";
            MessageControlID.Text = "";

            if ((ex == null) == false)
            {
                if ((ex) is Exception)
                {
                    if ((PanelContainerID == null) == false)
                    {
                        PanelContainerID.CssClass = "DatabaseError";
                    }
                }
                else
                {
                    if ((PanelContainerID == null) == false)
                    {
                        PanelContainerID.CssClass = "ApplicationError";
                    }
                }
                MessageControlID.Text = ex.ToString();
                return;
            }

            if ((Message == null) == false)
            {
                if ((ErrorType == null) == false)
                {
                    if (ErrorType == "Success")
                    {
                        PanelContainerID.CssClass = "Success";
                        MessageControlID.Text = Message;
                        return;
                    }
                    else if (ErrorType == "Warning")
                    {
                        PanelContainerID.CssClass = "ApplicationError";
                        MessageControlID.Text = Message;
                        return;
                    }

                }
                else
                {
                    PanelContainerID.CssClass = "Message";
                    MessageControlID.Text = Message;
                    return;
                }
            }

        }

    }
    //----------------------scan file through avg--------------------//
    public void scanfile(string c, FileUpload fileupload1)
    {
        bool IsValid = true;
        //foreach (FileInfo file in fileuploadExcel.Unload)
        //{
        try
        {
            //do av check here
            Process myProcess = new Process();
            fileupload1.SaveAs("C:\\VirusScan\\temp\\" + fileupload1.FileName);
            //address of command line virus scan exe
            myProcess.StartInfo.FileName = "C:\\Program Files\\Symantec\\Symantec Endpoint Protection\\DoScan.exe";
            //"C:\\Program Files\\AVG\\AVG2012\\avgscanx.exe";

            string path = '"' + "" + "C:\\VirusScan\\temp\\" + "" + fileupload1.FileName + "" + '"';
            string report = '"' + "" + "C:\\VirusScan\\Report.txt" + "" + '"';
            string myprocarg = "/SCAN=" + path + " /REPORT=" + report;
            //" /REPORT=C:\\Upload\\Temp\\Report.txt";
            myProcess.StartInfo.Arguments = myprocarg;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;

            myProcess.Start();
            myProcess.WaitForExit(); //wait for the scan to complete                
            //add some time for report to be written to file

            int j = 0;
            int y = 0;
            for (j = 0; j <= 1000000; j++)
            {
                y = y + 1;
            }

            //Get a StreamReader class that can be used to read the file
            StreamReader objStreamReader = default(StreamReader);
            objStreamReader = File.OpenText("C:\\VirusScan\\Report.txt");
            String reportVerbose = objStreamReader.ReadToEnd().Trim();

            File.Delete("C:\\VirusScan\\temp\\" + "" + fileupload1.FileName);

            if (reportVerbose.Length > 0 && !reportVerbose.Contains("Found infections    :    0"))
            {
                IsValid = false;
            }

            objStreamReader.Close();
            if (IsValid)
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void ShowMessageFin(String Message, Exception ex, Panel PanelContainerID, Label MessageControlID, String ErrorType, Label lblTitle)
    {


        if ((PanelContainerID == null) == true & (MessageControlID == null) == true)
        {
            if ((ex == null) == false)
            {
                MessageControlID.Text = ex.ToString();
                PanelContainerID.CssClass = "DatabaseErrorFin";
                lblTitle.Text = "Database Error";
            }
            else if ((Message == null) == false)
            {
                MessageControlID.Text = Message.ToString();
                PanelContainerID.CssClass = "ApplicationErrorFin";
                lblTitle.Text = "Application Error";
            }
            else
            {
                PanelContainerID.CssClass = "EmptyErrorFin";
                MessageControlID.Text = "";
                lblTitle.Text = "Empty Error";
            }

            return;
        }
        if ((PanelContainerID == null) == false & (MessageControlID == null) == false)
        {
            PanelContainerID.CssClass = "EmptyErrorFin";
            MessageControlID.Text = "";
            lblTitle.Text = "Empty Error";
            if ((ex == null) == false)
            {
                if ((ex) is Exception)
                {
                    if ((PanelContainerID == null) == false)
                    {
                        PanelContainerID.CssClass = "DatabaseErrorFin";
                        lblTitle.Text = "Database Error";
                    }
                }
                else
                {
                    if ((PanelContainerID == null) == false)
                    {
                        PanelContainerID.CssClass = "ApplicationErrorFin";
                        lblTitle.Text = "Application Error";
                    }
                }
                MessageControlID.Text = ex.ToString();
                return;
            }

            if ((Message == null) == false)
            {
                if ((ErrorType == null) == false)
                {
                    if (ErrorType == "Success")
                    {
                        PanelContainerID.CssClass = "SuccessFin";
                        MessageControlID.Text = Message;
                        lblTitle.Text = "Success";
                        return;
                    }
                    else if (ErrorType == "Warning")
                    {
                        PanelContainerID.CssClass = "ApplicationErrorFin";
                        MessageControlID.Text = Message;
                        lblTitle.Text = "Warning";
                        return;
                    }

                }
                else
                {
                    PanelContainerID.CssClass = "MessageFin";
                    MessageControlID.Text = Message;
                    return;
                }
            }

        }

    }
}
