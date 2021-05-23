<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentTeam.aspx.cs" Inherits="SportsWebApplication1.CurrentTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Current Team:<asp:GridView ID="GridView2" runat="server"  ShowFooter="true" OnRowDataBound="GridView2_RowDataBound">
                <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkDelete" runat="server" AutoPostBack="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PersonnelName">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("PersonnelName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Salary">
                <ItemTemplate>
                    <asp:Label ID="lblSal" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalSalary" runat="server" ></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </div>
        <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
        </p>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="viewPersonnel" TypeName="SportsClassLibrary2.Class3"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="viewPersonnel" TypeName="SportsClassLibrary2.Class3"></asp:ObjectDataSource>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Remove from Team" />
    </form>
</body>
</html>
