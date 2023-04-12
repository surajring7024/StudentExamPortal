<%@ Page Title="" Language="C#" MasterPageFile="~/Student_Master.Master" AutoEventWireup="true" CodeBehind="ApplyForExam.aspx.cs" Inherits="StudentExamPortal.ApplyForExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Signin</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
   
   
        <div class="form-signin" style="margin: auto; margin-bottom: 250px;">
        <h1 class="h3 mb-3 font-weight-normal label2">Apply for Exam</h1>
        <br />
        <div class="container">
            <div class="row" >
                <div class="col-md-4"></div>
                <div class="col-md-4 " style="margin: auto;">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="nm2 input label2" Style="margin: auto; justify-content: left; display: grid">
                    </asp:CheckBoxList>
                </div>
                <div class="col-md-4"></div>
            </div>
            <br />
            <div class="row" style="">
                <div class="col-md-4"></div>
                <div class="col-md-4 " style="margin: auto;">
                    <asp:Button ID="Submit" runat="server" class="btn btn-lg btn-primary btn-block" Text="Submit" Style="margin: auto; justify-items: center; display: grid" OnClick="Submit_Click" />
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
            </div>
   


</asp:Content>
