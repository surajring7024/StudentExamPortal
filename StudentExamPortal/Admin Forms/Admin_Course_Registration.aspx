<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Course_Registration.aspx.cs" Inherits="StudentExamPortal.Admin_Course_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Add Course</title>
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        
    <div class="form-signin " style="margin-bottom: 100px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />

        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Course Registration</h1>
        <div class="container mycont">
            <div class="row row1">
                    <div class="col-md-4 label1">
                        <label for="course_code" class="sr-only " style="">Course Code</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="Course_code" runat="server" CssClass="nm input"></asp:TextBox>

                    </div>
                    <div class="col-md-6"></div>
                </div>
            <br />
                <div class="row row1">

                    <div class="col-md-4 label1">
                        <label for="Course_name" class="sr-only " style="">Course Name</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="Course_Name" runat="server" CssClass="nm input"></asp:TextBox>

                    </div>
                    <div class="col-md-6"></div>

                </div>
            <br />
                <div class="row row1">
                    <div class="col-md-4 label1">
                        <label for="isactive" class="sr-only " style="">Is Active</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="isactive" runat="server" CssClass="nm input"></asp:TextBox>

                    </div>
                    <div class="col-md-6"></div>

                </div>
            <br />
            <div class="row row1">
                    <div class="col-md-4 label1">
                        <label for="isenable" class="sr-only " style="">Is Enable</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="isenable" runat="server" CssClass="nm input"></asp:TextBox>

                    </div>
                    <div class="col-md-6"></div>

                </div>
            <br />
            <div class="row row1">
                    <div class="col-md-4 label1">
                        
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="Submit" runat="server" class="btn btn-lg btn-primary btn-block" Text="Submit" Style="" OnClick="Submit_Click" />

                    </div>
                    <div class="col-md-4"></div>

                </div>
        </div>
 </div>
</asp:Content>
