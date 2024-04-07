<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarcodeReport.aspx.cs" Inherits="ProductLabelPrinting.Web.Report.BarcodeReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


    <!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>  
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px"></rsweb:ReportViewer>  
    </div>
    </form>
</body>
</html>
