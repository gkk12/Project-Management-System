<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">





    <%foreach (var item in projects){%>

     <ul class="gigs">
    <%--@foreach (var gig in Model)
    {--%>
        <li>
            <div class="date">
                <div class="month">
                    <%=Convert.ToDateTime(item.deadline).ToString("MMM")%> 
                </div>
                <div class="day">
                   <% =Convert.ToDateTime(item.deadline).ToString("d ")%>
                </div>
            </div>
            <div class="details">
                <span class="artist">
                    <%=item.title %>
                </span>


                <%if (isAdmin){%>
                     <span class="genre">
                    <a href="EditProject.aspx?Id=<%=item.id.ToString() %>">Edit</a> </br>
                </span> 
                  <%} %>
            <%--    <%if (!isAdmin){%>--%>
                     <span class="genre">
                    <a href="ProjectDetail.aspx?Id=<%=item.id.ToString() %>"> View Details</a>
                </span> 
           <%--       <%} %>--%>
                
            </div>
        </li>
<%--    }--%>
</ul>

          
    <%} %>   



    




   <%-- <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="WebForm1.aspx" runat="server">User Comments:</asp:HyperLink>

</asp:Content>
