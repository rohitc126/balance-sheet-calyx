<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="BalanceSheetDocument.aspx.cs"
    Inherits="FAMS_MIS_BalanceSheetDocument" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="SGG" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>::SG Group::</title>
    <link href="../../css/FA_1.css" rel="stylesheet" type="text/css" />
    <script src="../../Jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../css/FA_Msg.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/custom_Validate.js" type="text/javascript"></script>
       <style type="text/css">
        .GroupHeaderStyle
        {
            border: solid 1px Black;
            background-color: #cdeb8b;
            color: #000000;
            font-weight: bold;
        }
    </style>
    <style type="text/css">
        .backCSS
        {
            background-image: url('../../images/bg.png');
            filter: alpha(opacity=58);
            opacity: 0.58;
            overflow: hidden;
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
      <script type="text/javascript">

          $(document).ready(function () {
              $("#<%=GVVoucherApproval.ClientID%> [id*=imgFileView]").live("click", function (e) {
                  alert();
                  var FILE_PATH = $(this).closest('tr').find("[id*=hdnFILE_PATH]").val();
                  var fileName = $(this).closest('tr').find("[id*=hdnFileName]").val();
                  alert(FILE_PATH);
                  alert(fileName);
               
                      $('#iframeBill').attr('src', '../../Handler/ViewJVAttachFile.ashx?filePath=' + FILE_PATH);
                      $('#divvendor1').fadeIn(1000);
                      $('#divMain').css('opacity', '0.2');
                      $find("mpePhysicalFile").show();
                      e.preventDefault();              
              });
          });
    </script>
    <table width="100%" style="overflow: scroll;">
        <tr>
            <td>
                <asp:Panel ID="ErrorContainer" runat="server" CssClass="EmptyError">
                    <asp:Label ID="MyMessage" runat="server" Font-Size="10pt"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td colspan="4">
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:Button ID="Button1" runat="server" Style="display: none" />
                <SGG:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button1"
                    PopupControlID="Panel1" CancelControlID="ImageButton1" BehaviorID="mpe" BackgroundCssClass="modalBackground">
                </SGG:ModalPopupExtender>
                <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
                        <table width="100%" style="overflow: scroll; text-align: center; border-collapse: collapse">
                            <tr>
                                <td width="5%" class="Left">
                                    Company Name:
                                </td>
                                <td width="15%">
                                    <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" Style="width: 130px" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlCompany" runat="server" ErrorMessage="Select Company Name"
                                        ValidationGroup="Show2" ControlToValidate="ddlCompany" ToolTip="Select Company Name"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td width="5%" class="Left">
                                    Financial Year:
                                </td>
                                <td width="15%">
                                    <asp:DropDownList ID="ddlFinancial" runat="server" AutoPostBack="True" Style="width: 130px" OnSelectedIndexChanged="ddlFinancial_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                    <%-- <asp:RequiredFieldValidator ID="rfvddlFinancial" runat="server" ErrorMessage="Select Financial Year"
                                    ValidationGroup="Show2" ControlToValidate="ddlFinancial" ToolTip="Select Financial Year"
                                    InitialValue="0"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td style="text-align: left;">
                                    <asp:Button ID="btnShow" runat="server" Text="Show" ValidationGroup="Show2" CssClass="btnsave"
                                        OnClick="btnShow_Click" />
                                    <asp:Button ID="btnAdd" runat="server" Text="Add New" ValidationGroup="Add2" CssClass="btnsave"
                                        OnClick="btnAdd_Click1" />
                                    <SGG:ModalPopupExtender ID="mpeAddMore" runat="server" BehaviorID="mpeAddMore" TargetControlID="btnAdd"
                                        PopupControlID="pnlPopup" CancelControlID="Close" BackgroundCssClass="modalBackground">
                                    </SGG:ModalPopupExtender>
                                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Show2" ShowMessageBox="true"
                                        ShowSummary="false" runat="server" />
                                </td>
                            </tr>
                        <%--    <asp:Panel ID="Panel1" runat="server" CssClass="EmptyErrorFin">--%>
                                <%--<table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblErrorTitle" runat="server" CssClass="ErrorTitle" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:Label ID="Label1" runat="server" Font-Size="10pt"></asp:Label><br />
                        <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="20" ForeColor="#006600"
                            Visible="false"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="btnclose" type="button" value="Close" onclick="javascript:$('#ErrorContainer').hide();javascript:$('#ErrorContainer').attr('class', 'EmptyError');" />
                </td>
            </tr>
        </table>--%>
                                <div>
                                    <asp:GridView ID="GVVoucherApproval" Width="100%" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="False" CellPadding="4" CellSpacing="0" EmptyDataText="Record Not Found"
                                        GridLines="Vertical" CssClass="grid-view_1" EnableTheming="True">
                                        <HeaderStyle CssClass="header_1" />
                                        <RowStyle CssClass="normal_1" Height="0px" />
                                        <FooterStyle CssClass="header_1" />
                                        <AlternatingRowStyle CssClass="alternaterow" Height="0px" />
                                        <EmptyDataRowStyle CssClass="GridEmpty"></EmptyDataRowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.L No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                    <asp:HiddenField ID="hdnBSD_ID" runat="server" Value='<%# Eval("BSD_ID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComp_Name" runat="server" Text='<%# Eval("Comp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Financial Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFY" runat="server" Text='<%# Eval("FY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View Document">
                                                <ItemTemplate>
                                                    <%--<asp:ImageButton ID="imgFileView"  runat="server" ImageUrl="~/images/attach.png" />--%>
                                                               <asp:ImageButton id="imgFileView" runat="server" src="../../images/attach.png" style="cursor: pointer; width: 15px;height: 15px; " title="View Physical File" alt=""   Visible='<%# bool.Parse(Eval("File_Name").ToString() != "" ? "True": "False") %>'   />   
                                                       <asp:HiddenField ID="hdnFile_Path" runat="server" Value='<%# Eval("File_Path") %>' />
                                                       <asp:HiddenField ID="hdnFileName" runat="server" Value='<%#  Eval("File_Name") %>' />
                                                      

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                           <%-- </asp:Panel>--%>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upPopup" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlPopup" runat="server" Style="display: none;">
                <div class="Reportpopupbox" style="height: 250px; top: 20%; left: 12%; width: 62%">
                    <table style="width: 100%">
                        <tr>
                            <td class="closePopup">
                            </td>
                            <td>
                                <div style="float: right; padding-right: 10px;" id="close" class="closePopup">
                                    <asp:ImageButton ID="Close" runat="server" ImageUrl="~/images/dialog-close.png" />
                                   
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="up11" runat="server">
                                  <%--  <table width="100%" style="overflow: scroll;">
                                        <tr>
                                            <td style="width: 90%">
                                                <asp:Panel ID="ErrorContainer1" runat="server" CssClass="EmptyError">
                                                    <asp:Label ID="MyMessage1" runat="server" Font-Size="10pt"></asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>--%>
                                    <table width="100%">
                                        <tr>
                                            <td width="5%" class="Left">
                                                Company Name:
                                            </td>
                                            <td width="15%">
                                                <asp:DropDownList ID="ddlCompanyPopup" runat="server" Style="width: 130px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCompanyPopup" runat="server" ErrorMessage="Select Company Name"
                                                    ValidationGroup="Savepopup" ControlToValidate="ddlCompanyPopup" ToolTip="Select Company Name"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="HdnCompany" runat="server" />
                                            </td>
                                            <td width="5%" class="Left">
                                                Financial Year:
                                            </td>
                                            <td width="10%">
                                                <asp:DropDownList ID="ddlFinancialPopup" runat="server" Style="width: 130px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvFinancialPopup" runat="server" ErrorMessage="Select Financial Year"
                                                    ValidationGroup="Savepopup" ControlToValidate="ddlFinancialPopup" ToolTip="Select Financial Year"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="text-align: left;" class="Left">
                                                Upload File
                                            </td>
                                            <td style="text-align: left;" class="Left">
                                                <asp:FileUpload ID="fuDocument" runat="server" CssClass="txtNormal" Style="width:130px" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Savepopup"
                                                    ControlToValidate="fuDocument" ErrorMessage="Select file" ToolTip="Select file"
                                                    Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                               <%--  <asp:HiddenField ID="HdnFile_Name" runat="server" Value='<%# Eval("File_Name") %>' />
                                                <asp:HiddenField ID="HdnUploaded_date" runat="server" />--%>
                                                
                                            </td>
                                            <tr>
                                                <td colspan="6" style="text-align: center;">
                                                    <asp:Button ID="btnSavePopup" runat="server" Text="Save" ValidationGroup="Savepopup"
                                                        CssClass="btnsave" OnClick="btnSavePopup_Click" />
                                                    <asp:ValidationSummary ID="vsPopup" ValidationGroup="Savepopup" ShowMessageBox="true"
                                                        ShowSummary="false" runat="server" />
                                                </td>
                                            </tr>

                                    </table>
                                </asp:Panel>

                            </td>
                        </tr>
                    </table>
                </div>
                
                   
                                        <asp:Button ID="btnShowFile" runat="server" Style="display: none;" />
    <SGG:ModalPopupExtender ID="ModalPhysicalFile" runat="server" TargetControlID="btnShowFile"
        PopupControlID="pnlPhysicalFile" BackgroundCssClass="modalBackground" BehaviorID="mpePhysicalFile"
        CancelControlID="closeFile">
    </SGG:ModalPopupExtender>
    <asp:Panel ID="pnlPhysicalFile" runat="server" Style="display: none;">
        <div id="divvendor1" style="overflow: auto; width: 90%; height: 530px; top: 1px;"
            class='Reportpopupbox'>
            <div class="PopTitle">
                <span id="Span2">Physical File </span><span id="closeFile" class="cls" style="float: right;
                    cursor: pointer; position: relative; right: 10px; padding: 0px 3px 0px 3px;">X</span>
                <img id="img1" src="../../images/imgClose.png" style="float: right; padding-right: 20px;
                    width: 70px; top: -3px; display: none; position: relative;" />
                <br />
                <hr />
            </div>
            <iframe id="iframeBill" width="100%" height="460px;" style="border-style: none; z-index: 1000"
                marginwidth="0px" marginheight="0px" src=""></iframe>
        </div>
    </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    </form>
</body>
</html>
