<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="StudentExamPortal.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">

    <title>Sign Up</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">

   <%-- <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">--%>
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
    
    <script src='<%=ResolveClientUrl("../Scripts/Toggler.js") %>' type="text/javascript"></script>
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-signin " autocomplete="off" id="form" style="margin-bottom: 100px" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />

        <h1 class="h3 mb-3 font-weight-normal" style="text-align: center;">Sign Up</h1>


        <div class=" container mycont">

            <%-- Enrollment row  id=enroll --%>
            <div class="row" id="enroll">
                <div class="col-md-4 label1">
                    <label for="Enroll" class="sr-only " style="">Enrollment No</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Enroll" runat="server" CssClass="nm1 input"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="getinfo" runat="server" Text="Get Info" class="btn btn-md btn-primary btn-block" OnClick="getinfo_Click" />
                </div>
                <div class="col-md-2">
                </div>
            </div>
            <br />
            <%-- name id=drop1 --%>
            <div id="drop1" style="display:none;">
                <div class="row">
                    <div class="col-md-2">
                        <label for="Name" class="sr-only " style="">Name</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Name" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label for="Academic" class="sr-only " style="">Academic Year</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Academic" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                </div>
                <br />
                <%-- Course --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Course" class="sr-only " style="">Course</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Course" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label for="Semester" class="sr-only " style="">Semester</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Semester" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                </div>
                <br />
                <%-- mobile --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Mobile" class="sr-only " style="">Mobile No</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Mobile" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-4"></div>
                </div>
                <br />
                <%-- Address --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="address" class="sr-only " style="">Address</label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="Address" runat="server" CssClass=" input" Width="570px"></asp:TextBox>
                    </div>

                    <div class="col-md-4"></div>
                </div>
                <br />
                <%-- Email --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Email" class="sr-only " style="">Email</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Email" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="Send" runat="server" Text="Send OTP" class="btn btn-md btn-primary btn-block" OnClick="Send_Click" />
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
            </div>
            <br />
            <%-- OTP  id =drop2 --%>
            <div id="drop2" style="display:none;">
                <div class="row">
                    <div class="col-md-2">
                        <label for="OTP" class="sr-only " style="">OTP</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="OTP" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="Validate" runat="server" Text="Validate" class="btn btn-md btn-primary btn-block" OnClick="Validate_Click" />
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
            </div>
            <br />
            <%-- Username id=drop3 --%>
            <div id="drop3"  style="display:none;">
                <div class="row">
                    <div class="col-md-2">
                        <label for="Username" class="sr-only " style="">Username</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Username" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="Valid" runat="server" Text="Validate" class="btn btn-md btn-primary btn-block" OnClick="Valid_Click" />
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
            </div>
            <br />
            <%-- password id=drop4 --%>

            <div id="drop4" style="display:none;">
                <div class="row">
                    <div class="col-md-2">
                        <label for="Password" class="sr-only " style="">Enter Password</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Password" runat="server" CssClass="nm2 input" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
                <br />
                <%-- Reenter Pass --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Password" class="sr-only " style="">Re-Enter Password</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="RePassword" runat="server" CssClass="nm2 input" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
                <br />
                <%-- security que --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Secu" class="sr-only " style="">Security Question</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Que" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
                <br />
                <%-- security ans --%>
                <div class="row">
                    <div class="col-md-2">
                        <label for="Secur" class="sr-only " style="">Security Answer</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="Ans" runat="server" CssClass="nm2 input"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
                <br />
                <%-- signup --%>
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>
                    <div class="col-md-4">
                        <asp:Button ID="SignUp" runat="server" Text="Sign Up" class="btn btn-lg btn-primary btn-block" OnClick="SignUp_Click" />
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
