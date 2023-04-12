<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamPaper.aspx.cs" Inherits="StudentExamPortal.ExamPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Give Exam</title>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/Images/icons8-login-64.png">
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sign-in/">
    
    <link href="../CSS/WholeCss.css" rel="stylesheet" />
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    
</head>
<body style="background-color:gainsboro">

    <form id="form1" runat="server">
    <div style="margin:auto;">  
        
        <div style="">

        
    <div class="container"  style="margin-top:10%;border:2px solid black;padding-top:5%;padding-bottom:5%;border-radius:20px;background-color:white;width:70%">
        

                <%--Question Number and Question Text--%>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align:center"> <h3 class="mb-5">Exam</h3></div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-1"> <asp:Label ID="Label1" runat="server" Text="Label" class="form-label" for="Question_No"></asp:Label></div>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control form-control-sm" ReadOnly="true" TextMode="MultiLine" style = "resize:none; font-size:medium" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-2"></div>
        </div>
  
        
        <br />
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-1"></div>
            <div class="col-md-7"> <asp:RadioButton ID="RadioButton1" runat="server" GroupName="option" Width="" /></div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-1"></div>
            <div class="col-md-7">  <asp:RadioButton ID="RadioButton2" runat="server" GroupName="option" /></div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-1"></div>
            <div class="col-md-7"> <asp:RadioButton ID="RadioButton3" runat="server" GroupName="option" /></div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-1"></div>
            <div class="col-md-7"><asp:RadioButton ID="RadioButton4" runat="server" GroupName="option" /></div>
            <div class="col-md-2"></div>
        </div>
        <br />
        <div class="row">
        <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align:center"> 
                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary btn-lg btn-block mb-3" style="width:50%;" OnClick="Button1_Click" />

            </div>
            <div class="col-md-4"></div>
            </div>
        </div>
   
    </div>
    </div>

           
               

                 <%--List of Questions Answer--%>
                 


                <%--Submit Button--%>
                
</form>
</body>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    
</html>
