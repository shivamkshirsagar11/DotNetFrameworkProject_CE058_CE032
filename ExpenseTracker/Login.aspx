<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExpenseTracker.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
</head>
<body>
    <div class="container my-5">
    <form id="form1" runat="server">
        <table class="table table-striped-columns">
            <tbody>
            <tr>
            <th>Username</th><td><asp:TextBox ID="uname" runat="server" AutoCompleteType="Disabled" AutoPostBack="True" CssClass="auto-style1" MaxLength="14"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uname" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>

           <tr><th> Password</th><td><asp:TextBox ID="pass" runat="server" AutoCompleteType="Disabled" AutoPostBack="True" CssClass="auto-style1" MaxLength="14" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
                </tbody>
        </table>
        <asp:Button ID="loginbtn" runat="server" class="btn btn-success" Text="Login" />
    </form>
        </div>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-u1OknCvxWvY5kfmNBILK2hRnQC3Pr17a+RTT6rIHI7NnikvbZlHgTPOOmMi466C8" crossorigin="anonymous"></script>
</body>
</html>
