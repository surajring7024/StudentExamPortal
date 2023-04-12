<%@ Page Title="" Language="C#" MasterPageFile="~/Student_Master.Master" AutoEventWireup="true" CodeBehind="ViewTimeTable.aspx.cs" Inherits="StudentExamPortal.ViewTimeTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>View TimeTable</title>

    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    
       <div class="form-signin" style="margin-bottom: 400px">
        <div class="container">
            <div class="row">
                
                <div class="col-12" style="margin: auto; text-align:center; display:flex; align-items:center">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="align-content-center" Width="1110px">
                        <FooterStyle BackColor="White" ForeColor="#000066" VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </div>
        </div>
           </div>
   
</asp:Content>
