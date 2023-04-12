<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Student_Registeration.aspx.cs" Inherits="StudentExamPortal.Student_Registeration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Student Registration</title>
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

   <%-- <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">--%>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-signin " style="margin-bottom: 100px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />

        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Student Registeration Form</h1>


        <div class=" container mycont">

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Name" class="sr-only " style="">Name</label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="firstname" runat="server" class="input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="firstname" CssClass=""></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-2">
                    <asp:TextBox ID="midname" runat="server" CssClass="input "></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="midname" CssClass=""></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 last">
                    <asp:TextBox ID="lastname" runat="server" CssClass="input "></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ControlToValidate="lastname" CssClass=""></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="email" class="sr-only " style="">Email</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="Email" runat="server" CssClass="nm input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ControlToValidate="email" CssClass=""></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6"></div>
            </div>

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Mobile_no" class="sr-only " style="">Mobile No</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="Mobile" runat="server" CssClass="nm input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ControlToValidate="Mobile" CssClass=""></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6"></div>

            </div>

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Address" class="sr-only " style="">Address</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="Address" runat="server" CssClass="nm input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ControlToValidate="Address" CssClass=""></asp:RequiredFieldValidator>

                </div>
                <div class="col-md-6"></div>

            </div>

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Academic" class="sr-only " style="">Academic Year</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="nm input" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Semester" class="sr-only " style="">Semester</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="nm input" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>
            </div>

            <br />

            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Course" class="sr-only " style="">Course</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="nm input" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>

            </div>
            <br />
            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="DOB" class="sr-only " style="">Date of Birth</label>
                </div>
                <div class="col-md-3">
                    <div id="date-picker-example" class=" input-with-post-icon datepicker  " inline="true">
                        <asp:TextBox ID="DOB" runat="server" TextMode="Date" class="bg-white nm input "></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <div class="row row1">
                <div class="col-md-2"></div>
                <div class="col-md-2 label2">
                    <label for="Gender" class="sr-only " style="">Gender</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="nm input">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                </div>

            </div>
            <br />
            <div style="margin: auto;">
                <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary btn-block" Text="Register" Style="" OnClick="Button1_Click" />
            </div>
        </div>
    </div>


</asp:Content>
