<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="StudentExamPortal.ForgetPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Signin</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

   <%-- <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">--%>
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-signin " autocomplete="off" id="form" style="margin-bottom: 100px" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
       
        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Forget Password</h1>
         <br />
        <div class="container mycont">
            <div class="row">
                <div class="col-md-4 label1">
                     <label for="Username" class="sr-only " style="">Username</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="username" runat="server" CssClass="nm1 input"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="getinfo" runat="server" Text="Get Info" class="btn btn-md btn-primary btn-block" OnClick="getinfo_Click"/>
                </div>
                
            </div>
            <br />
            <div class="row">
                 <div class="col-md-4 label1">
                     <label for="Email" class="sr-only " style="">Email</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Email" runat="server" CssClass="nm1 input"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="Send" runat="server" Text="Send OTP" class="btn btn-md btn-primary btn-block" OnClick="Send_Click"/>
                </div>
                
            </div>
            <br />
            <div class="row">
                <div class="col-md-4 label1">
                     <label for="OTP" class="sr-only " style="">OTP</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="OTP" runat="server" CssClass="nm1 input"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="validate" runat="server" Text="Validate" class="btn btn-md btn-primary btn-block" OnClick="validate_Click"/>
                </div>
                
            </div>
            <br />
            <hr />
            <br />
            <div class="row">
                <div class="col-md-4 label1">
                     <label for="Password" class="sr-only " style="">Password</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="nm1 input"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    
                </div>
                
            </div>
            <br />
            <div class="row">
                <div class="col-md-4 label1">
                     
                </div>
                <div class="col-md-4">
                    <asp:Button ID="Set" runat="server" Text="Set Password" class="btn btn-md btn-primary btn-block" OnClick="Set_Click"/>
                </div>
                <div class="col-md-4">
                    
                </div>
            </div>
        </div>
    </form>
</asp:Content>
