<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ProjectManagementSystem.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


      <div class="forCenter">
    <div class="form-horizontal">
        <h2 style="text-align:center">Log In</h2><br />
        
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <%if (wrongLogin) {%>
        
      <div class="form-group">
            <label class="col-md-3 control-label" style="color:red; font-weight:bold"> Email or password is incorrect</label>
           
        </div>
        
        
         <%} %>

        <div class="form-group" >
            <label class="col-md-4 control-label" > Email</label>
            <div class="col-md-6">
                <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>

<div class="form-group">
            <label class="col-md-4 control-label" > Password</label>
            <div class="col-md-6">
                <asp:TextBox ID="passwordTextBox" CssClass="form-control" runat="server" Text="" TextMode="Password"></asp:TextBox>
            </div>
        </div>
		
		
     

        <div class="form-group">
            <div class="col-md-offset-4 col-md-6">
                <%--<asp:Button runat="server" OnClick="CreateUser_Click"Text="Save" CssClass="btn btn-default" />--%>
                 <asp:Button runat="server" ID="LoginButton" Text="Login" CssClass="btn" OnClick="LoginButton_Click" />
            </div>
        </div>
    </div>


        </div>


</asp:Content>
