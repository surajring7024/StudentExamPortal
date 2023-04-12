<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Add_Que.aspx.cs" Inherits="StudentExamPortal.Admin_Add_Que" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Add Questions</title>
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        
    <div class="form-signin " style="margin-bottom: 100px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />

        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Add Questions</h1>
        <div class="container mycont">
            <div class="row row1">
                <div class="col-md-4 label1">
                    <label for="Excelpath" class="sr-only " style="">Enter Excel Path</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="ExcelPath" runat="server" CssClass="nm input"></asp:TextBox>

                </div>
                <div class="col-md-6"></div>
            </div>
            <br />
            <div class="row row1">

                <div class="col-md-4 label1">
                    <label for="ExcelSheet" class="sr-only " style="">Enter Excel Sheet</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="ExcelSheet" runat="server" CssClass="nm input"></asp:TextBox>

                </div>
                <div class="col-md-6"></div>

            </div>
            <br />

            <div style="margin: auto;">
                <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary btn-block" Text="Register" Style="" OnClick="Button1_Click"  />
            </div>
        </div>
</div>
</asp:Content>
