<%@ Page   EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="ProjectManagementSystem.ProjectDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<!------ Include the above in your HEAD tag ---------->

<div class="container">
	<div class="row">
		
       <div class="col-md-7 ">

<div class="panel panel-default" style="width: 153%;">
  <div class="panel-heading">  <h4 >Project Details</h4></div>
   <div class="panel-body">
       
    <div class="box box-info">
        
            <div class="box-body">
                     <div class="col-sm-6">
                   
                
                     
                     </div>
              
              <br>
    
              <!-- /input-group -->
            </div>
            <div class="col-sm-6">
            <h4 style="color:#0fb26c"><%=proj.title %> </h4></span>
                      
            </div>
            <div class="clearfix"></div>
            <hr style="margin:5px 0 5px 0;">
    
            
        <div class="col-sm-5 col-xs-6 tital " >Client Name:</div><div class="col-sm-7 col-xs-6 "><% =proj.client%></div>
     <div class="clearfix"></div>
<div class="bot-border"></div>
          
<div class="col-sm-5 col-xs-6 tital " >Project Type:</div><div class="col-sm-7 col-xs-6 "><% =proj.projectType%></div>
     <div class="clearfix"></div>
<div class="bot-border"></div>

<div class="col-sm-5 col-xs-6 tital " >Dead Line:</div><div class="col-sm-7"> <% =proj.deadline%></div>
  <div class="clearfix"></div>
<div class="bot-border"></div>

<div class="col-sm-5 col-xs-6 tital " >Current Status:</div><div class="col-sm-7">  <% =proj.status%></div>
  <div class="clearfix"></div>
<div class="bot-border"></div>



  <div class="clearfix"></div>
<div class="bot-border"></div>


  <div class="clearfix"></div>
<div class="bot-border"></div>



 <div class="clearfix"></div>
<div class="bot-border"></div>



 <div class="clearfix"></div>
<div class="bot-border"></div>



            <!-- /.box-body -->
          </div>
          <!-- /.box -->

        </div>
       
            
    </div> 
    </div>
</div>  
   
       
       
       
      
       
       
       
   </div>



    
     <form>

  <div class="form-group">
    <label for="exampleFormControlTextarea1">Comment</label>
    <textarea runat="server" class="form-control" id="commentBox" rows="2" placeholder="Leave a comment.." style="width: 87.5%;"></textarea>
  </div>
           <div class="form-group">
  <%-- <button class="btn btn-default" style="float: right;margin-right: 12%;margin-bottom: 1%;" runat="server"   OnClick="Comment_Click">Submit</button>--%>
               <asp:Button runat="server"  Text="Save" CssClass="btn"  OnClick="Comment_Click"/>
  </div>
</form>
       




         
    <%try {%>

      
     


   <% foreach (var item in Comments ){%>
      
           <div class="card border-light mb-3 comment-margin" style="max-width: 100rem;">
  <div class="card-header"><h5><b><%=item.DevName %></b></h5></div>
  <div class="card-body">
    <h5 class="card-title"><b> <%=item.DevDesignation %></b></h5>
    <p class="card-text"><% =item.commentText%>.</p>
      <em> <%=item.commentTime %></em>
  </div>
</div>
    <br />
      <%  }}%>

    <% catch{}%>
      
</asp:Content>
