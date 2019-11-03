<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ProjectManagementSystem.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="forCenter">
    <div class="form-horizontal">
        <h2 style="text-align:center">Create a New Project.</h2><br />
        
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
                <asp:TextBox ID="projectDeadline" CssClass="form-control" runat="server" Text=""  ></asp:TextBox>
            </div>
        </div>
		
		<div class="form-group">
            <label class="col-md-4 control-label" > Client</label>
            <div class="col-md-6">
                <asp:TextBox ID="clientName" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>

<%--<div class="form-group">
            <label class="col-md-2 control-label" > Project Type</label>
            <div class="col-md-10">
                <asp:TextBox ID="projectType" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            </div>
        </div>--%>

        <div class="form-group">
            <label class="col-md-4 control-label" > Project Type</label>
            <div class="col-md-6">
            <asp:DropDownList ID="DropDownListProjectTypes" CssClass="dropdown form-control drop" runat="server"></asp:DropDownList>
                </div></div>
          <%--  <div class="col-md-10">
                      <select class="form-control" style="width: 277px;" id="projType">
  <option value="volvo">Volvo</option>
  <option value="saab">Saab</option>
  <option value="opel">Opel</option>
  <option value="audi">Audi</option>
</select>
            </div>--%>
        
 
  
		
		
		<div class="form-group">
            <label class="col-md-4 control-label" > Description</label>
            <div class="col-md-6" style="width:50%">
<asp:TextBox id="projectDescription" TextMode="multiline" Columns="25" Rows="5" runat="server" CssClass="form-control" />
            </div>
        </div>
		
				
		
		

     

        <div class="form-group">
            <div class="col-md-offset-4 col-md-6">
                <%--<asp:Button runat="server" OnClick="CreateUser_Click"Text="Save" CssClass="btn btn-default" />--%>
                 <asp:Button runat="server"  Text="Save" CssClass="btn"  OnClick="CreateButton_Click"/>
            </div>
        </div>
    </div>


        </div>
  
</asp:Content>
