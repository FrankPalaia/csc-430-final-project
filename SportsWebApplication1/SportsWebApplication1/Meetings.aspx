<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Meetings.aspx.cs" Inherits="SportsWebApplication1.Meetings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Text="Even number = Agent wants to meet" Width="278px">Even number = Agent wants to meet</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Text="Odd number = Agent doesn't want to meet" Width="328px"></asp:TextBox>
        </div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AgentName">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Client">
                <ItemTemplate>
                    <asp:Label ID="lblCl" runat="server" Text='<%# Eval("Client") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="MeetingsObjectDataSource2" runat="server" SelectMethod="viewAgents" TypeName="SportsClassLibrary2.Class2"></asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Schedule Meeting" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
    </form>
</body>
</html>
