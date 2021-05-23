<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamForm.aspx.cs" Inherits="SportsWebApplication1.TeamForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Current Available Personnel to Hire:</div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">
            <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PersonnelName">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Salary">
                <ItemTemplate>
                    <asp:Label ID="lblSal" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="viewPersonnel" TypeName="SportsClassLibrary2.Class3"></asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="ButtonAdd_Click" Text="Add to Team" />
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getPersonnel" TypeName="SportsClassLibrary2.Class1"></asp:ObjectDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="ButtonHome_Click" Text="Home" />
    </form>
</body>
</html>
