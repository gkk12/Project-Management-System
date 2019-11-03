<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="ProjectManagementSystem.EditProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <div class="forCenter">
    <div class="form-horizontal">
        <h2 style="text-align:center">Edit.</h2><br />
        
        <asp:ValidationSummary runat="server" CssClass="text-danger" />


        <div class="form-group">
            <label class="col-md-4 control-label" > Project Title</label>
            <div class="col-md-6">
                <asp:TextBox ID="projectTitle" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>

<div class="form-group">
            <label class="col-md-4 control-label" > Project Deadline</label>
            <div class="col-md-6">
                <asp:TextBox ID="projectDeadline" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
		
		<div class="form-group">
            <label class="col-md-4 control-label" > Client</label>
            <div class="col-md-6">
                <asp:TextBox ID="clientName" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>

<div class="form-group">
            <label class="col-md-4 control-label" > Project Type</label>
            <div class="col-md-6">
                <asp:TextBox ID="projectType" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
		
		
		<div class="form-group">
            <label class="col-md-4 control-label" > Description</label>
            <div class="col-md-6" style="width:50%">
<asp:TextBox id="projectDescription" TextMode="multiline" Columns="25" Rows="5" runat="server" CssClass="form-control" />
            </div>
        </div>
		
				
		
		

     

        <div class="form-group">
            <div class="col-md-offset-4 col-md-6">
                <%--<asp:Button runat="server" OnClick="CreateUser_Click"Text="Save" CssClass="btn btn-default" />    OnClick="updateButton_Click"--%>
                 <asp:Button runat="server"  Text="Save" CssClass="btn" OnClick="updateButton_Click"/>
            </div>
        </div>
    </div>


        </div>

</asp:Content>
