
<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Stu_Login.aspx.cs" Inherits="StudentExamPortal.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Signin</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <!-- Bootstrap core CSS -->
   <%-- <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">--%>

    <!-- Custom styles for this template -->
   <%-- <link href="signin.css" rel="stylesheet">--%>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form class="form-signin" runat="server" style="margin-bottom:50px" autocomplete="off">
        <p>
        <br />
        <img class="mb-4" src="/Images/icons8-login-64.png" alt="" width="72" height="72" style="">
        </p>
        <h1 class="h3 mb-3 font-weight-normal" style="">Student Login</h1>

        <div class="container mycont" style="width:40%">
                
            <div class="row">

                <div class="col-md-6 label2">
                    <label for="username" class="sr-only " style="">Username</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="username" runat="server" CssClass="input"></asp:TextBox>
                </div>
                
            </div>
            <br />
            <div class="row">

                <div class="col-md-6 label2">
                    <label for="password" class="sr-only ">Password</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

                </div>
                
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2"></div>
                <div class="col-md-2 ">
                </div>
                <div class="col-md-6 ">
                    <a href="ForgetPass.aspx">
                        <asp:Label Text="Forget Password ?" runat="server"></asp:Label>
                    </a>
                </div>
                

            </div>
            <br />
            <div class="row">
                
                <div class="col-md-2"></div>
                <div class="col-md-4 ">
                    <asp:Button ID="Button2" runat="server" class="btn btn-lg btn-primary btn-block" Text="Login" Style="" OnClick="Button2_Click" />
                </div>
                <div class="col-md-4 ">
                    <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary btn-block" Text="SignUp" Style="" OnClick="Button1_Click1" />
                </div>
                
                <div class="col-md-2"></div>
            </div>
            <br />
        </div>







    </form>


</asp:Content>
 