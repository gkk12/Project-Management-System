<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectManagementSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="commentText" HeaderText="commentText" SortExpression="commentText" />
        <asp:BoundField DataField="userId" HeaderText="userId" SortExpression="userId" />
        <asp:BoundField DataField="projectId" HeaderText="projectId" SortExpression="projectId" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectManagmentConnectionString %>" SelectCommand="SELECT [commentText], [userId], [projectId] FROM [comments]"></asp:SqlDataSource>

</asp:Content>
