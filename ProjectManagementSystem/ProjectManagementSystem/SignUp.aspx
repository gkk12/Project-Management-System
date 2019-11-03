<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ProjectManagementSystem.SignUp" Theme="Red" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="forCenter">
    <div class="form-horizontal">
        <h3 style="text-align:center" >Sign Up/Register</h3><br />
        
        <asp:ValidationSummary runat="server" CssClass="text-danger" />


        <div class="form-group">
            <label class="col-md-4 control-label" > Name</label>
            <div class="col-md-6">
                <asp:TextBox ID="nameTextBox" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>

<div class="form-group">
            <label class="col-md-4 control-label" > Email</label>
            <div class="col-md-6">
                <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
		
		   <div class="form-group">
            <label class="col-md-4 control-label" > Password</label>
            <div class="col-md-6">
                <asp:TextBox ID="PasswordTextBox" CssClass="form-control" runat="server" Text="" TextMode="Password"></asp:TextBox>
            </div>
        </div>

<div class="form-group">
            <label class="col-md-4 control-label" > Designation</label>
            <div class="col-md-6">
                <asp:TextBox ID="DesignationTextBox" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
		
		
     

        <div class="form-group">
            <div class="col-md-offset-4 col-md-6">
                <%--<asp:Button runat="server" OnClick="CreateUser_Click"Text="Sign Up" CssClass="btn btn-default" />--%>
                 <asp:Button runat="server" ID="SignUpButton" Text="Sign Up" CssClass="btn" OnClick="SignUpButton_Click" />
            </div>
        </div>
    </div>
    </div>


     
		
		
		
		
		
		
		
		
		
		
		
		

</asp:Content>
