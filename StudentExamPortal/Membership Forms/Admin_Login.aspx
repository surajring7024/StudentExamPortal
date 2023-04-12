<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="StudentExamPortal.Admin_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Signin</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

    <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-signin" runat="server" autocomplete="off" id="form" style="margin-bottom:50px">
        <br />
        <img class="mb-4" src="/Images/icons8-login-64.png" alt="" width="72" height="72" style="">
        <h1 class="h3 mb-3 font-weight-normal" style="">Admin Login</h1>
       

        
        <div class="container mycont" style="width:40%">
            <br />
            <div class="row">
                
                <div class="col-md-6 label2">
                    <label for="username" class="sr-only " style="">Username</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="username" runat="server" CssClass="input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="username"></asp:RequiredFieldValidator>
                </div>
                
            </div>
            
            <div class="row">
               
                <div class="col-md-6 label2">
                    <label for="password" class="sr-only ">Password</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="password"></asp:RequiredFieldValidator>
                    
                </div>
               
            </div>
            <br />
            <div class="row">

                <div class="col-md-12 ">
                    <asp:Button ID="Button2" runat="server" class="btn btn-lg btn-primary btn-block" Text="Login" Style="" OnClick="Login_Click" />
                </div>


            </div>
            <br />
        </div>



        <%--<div class="col-md-6 input" style="width:100%;border:1px solid white;vertical-align:central;display: flex;align-items: center;justify-content: center;">
            <div class="col-md-3"></div>
            <div class="col-md-3 label1">
                <label for="username" class="sr-only " style="">Username</label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="username" runat="server" CssClass="input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="username"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3"></div>
        </div>
        
        <br />
        <div class="col-md-6 input" style="width:100%;border:1px solid white;vertical-align:central;display: flex;align-items: center;justify-content: center;">
            <div class="col-md-3 label1">
                <label for="password" class="sr-only " >Password</label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="password"></asp:RequiredFieldValidator>
            </div>
        </div>
       <br />
        <br />
        <div >
            <asp:Button ID="Login" runat="server" class="btn btn-lg btn-primary btn-block" Text="Login" Style="margin-left: 50px" OnClick="Login_Click" />
        </div>
        --%>
    </form>
</asp:Content>
