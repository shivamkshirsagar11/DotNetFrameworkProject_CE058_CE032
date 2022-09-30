<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="ExpenseTracker.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:GridView ID="History1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="164px" Width="500px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    <br /><hr />
       <table>
          <tr><th class="auto-style1">ID(ReadOnly)</th> <td class="auto-style1"><asp:TextBox ID="eid" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
          <tr><th>Expense Name</th> <td><asp:TextBox ID="ename" runat="server"></asp:TextBox></td></tr>
          <tr><th class="auto-style1">Expense Details</th> <td class="auto-style1"><asp:TextBox ID="edetails" runat="server"></asp:TextBox></td></tr>
          <tr><th>Expense Amount</th> <td><asp:TextBox ID="eamount" runat="server"></asp:TextBox></td></tr>
          <tr><th>Expense Date</th> <td><asp:TextBox ID="edate" runat="server" TextMode="Date"></asp:TextBox></td></tr>
            
           </table><br />
        <asp:Button ID="editEx" runat="server" Text="Update" OnClick="editEx_Click"/>
    </form><br />
    <a href="Home.aspx">Home</a>
    </body>
</html>
