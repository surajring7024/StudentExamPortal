<%@ Page Title="" Language="C#" MasterPageFile="~/Student_Master.Master" AutoEventWireup="true" CodeBehind="ShowProfile.aspx.cs" Inherits="StudentExamPortal.ShowProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Show Profile</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="form-signin" style="margin-bottom: 100px">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <br />

            <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">My Profile</h1>

            <div class=" container mycont">

                <%-- Enrollment row  id=enroll --%>
                <div class="row" id="enroll">
                    <div class="col-md-4 label1">
                        <label for="Enroll" class="sr-only " style="">Enrollment No</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Enroll" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
                <br />
                <%-- name id=drop1 --%>

                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Name" class="sr-only " style="">Name</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Name" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
                <br />
                <%-- Course --%>
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Course" class="sr-only " style="">Course</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Course" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Academic" class="sr-only " style="">Academic Year</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Academic" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Semester" class="sr-only " style="">Semester</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Semester" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>
                </div>
                <br />
                <%-- mobile --%>
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Mobile" class="sr-only " style="">Mobile No</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Mobile" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>
                </div>
                <br />
                <%-- Address --%>
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="address" class="sr-only " style="">Address</label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="Address" runat="server" CssClass=" input" Width="570px"></asp:TextBox>
                    </div>

                    <div class="col-md-2"></div>
                </div>
                <br />
                <%-- Email --%>
                <div class="row">
                    <div class="col-md-4 label1">
                        <label for="Email" class="sr-only " style="">Email</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Email" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
            </div>


        </div>
 
</asp:Content>
