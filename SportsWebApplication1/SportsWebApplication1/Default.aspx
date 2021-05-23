<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SportsWebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Meetings" Font-Size="Medium" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Current Team Roster" Font-Size="Medium" />
        </h1>
        <h1>Sports Franchise Personnel</h1>
        <p class="lead">There are many available personnel including players, coaches, and medical staff to add to your team! Contact their agents before they are signed by another team!</p>
        <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource1" Height="16px" Width="188px">
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="viewPayroll" TypeName="SportsClassLibrary2.Class5"></asp:ObjectDataSource>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>List of Sports Personnel</h2>
            <p>
                Below are listed personnel with associated agents that represent them. Salaries listed will help determine if your team has the budget to afford them.
            </p>
        </div>
        <div class="col-md-4">
            <h2><asp:GridView ID="GridView1" runat="server" DataSourceID="SportsDBObjectDataSource">
                </asp:GridView>
                <asp:ObjectDataSource ID="SportsDBObjectDataSource" runat="server" SelectMethod="GetAgents" TypeName="SportsClassLibrary1.Class1"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SportsObjectDataSource" runat="server"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SportsObjectDataSource1" runat="server"></asp:ObjectDataSource>
            &nbsp;</h2>
        </div>
        <div class="col-md-4">
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
