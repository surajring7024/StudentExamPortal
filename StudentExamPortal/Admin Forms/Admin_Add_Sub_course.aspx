<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Add_Sub_course.aspx.cs" Inherits="StudentExamPortal.Admin_Add_Sub_course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Add Subject to Course</title>
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        
    <div class="form-signin " style="margin-bottom: 100px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />

        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Add Subject To Course</h1>
        <div class="container mycont">
            <div class="row row1">
                <div class="col-md-4 label1">
                    <label for="Academic" class="sr-only " style="">Academic Year</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="nm input"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <div class="row row1">
                <div class="col-md-4 label1">
                    <label for="Course" class="sr-only " style="">Course</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="nm input"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <div class="row row1">
                <div class="col-md-4 label1">
                    <label for="Semester" class="sr-only " style="">Semester</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="nm input"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <div class="row row1">
                <div class="col-md-4 label1">
                    <label for="Subject" class="sr-only " style="">Subject</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="nm input"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>
             <br />
                <div style="margin:auto;">
                     <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary btn-block" Text="Register" Style="" OnClick="Button1_Click" />
                </div>
            
        </div>
    </div>
</asp:Content>
