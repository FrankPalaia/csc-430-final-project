<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduledMeetings.aspx.cs" Inherits="SportsWebApplication1.ScheduledMeetings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView2" runat="server" SourceID="ObjectDataSource7">
            <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkDelete" runat="server" AutoPostBack="false" />
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="MeetingsObjectDataSource7" runat="server" SelectMethod="viewMeetings" TypeName="SportsClassLibrary2.Class4"></asp:ObjectDataSource>
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete Appointment" />
        </div>
        <p>
        <asp:Button ID="Button2" runat="server" OnClick="ButtonHome2_Click" Text="Home" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Browse Available Personnel" Font-Size="Medium" />
            </p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Schedule Meetings" />
    </form>
</body>
</html>
