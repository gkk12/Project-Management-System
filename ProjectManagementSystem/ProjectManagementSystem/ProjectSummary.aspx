<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectSummary.aspx.cs" Inherits="ProjectManagementSystem.ProjectSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


       <table class="table table-striped" id="datatable">
           <thead class="thead-dark">
               <tr>
                   <th>Title</th>
                    <th>Description</th>
                   <th>Starting Date</th>
                    <th>Time left</th>
                    <th>Number Of Revisions</th>
                        <th>Current Status</th>
                  <%-- <th>Action</th>--%>
               </tr>
           </thead>
         

       </table>
   
    <script>
        //function myFunction(param) {
        //    alert(param.value);
        //}


        function myFunction(param) {
            console.log('before');
            $.ajax({
                type: "POST",
                url: "PendingComments.aspx/Approve",
                data: '{Id:"' + param.value + '"}',
                // data: '{eventurl:"' + txtbox1 + '",ticketType:"' + tictype + '",price:"' + price + '",sect:"' + text + '",area:"' + value + '",Qty:"' + minqty + '",eventname:"' + eventname.val() + '",eventvenue:"' + eventvenue.val() + '",eventdate:"' + eventdate.val() + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);

                },
                failure: function (response) {
                    console.log("fail");
                    console.log(response);

                },
                error: function (response) {
                    console.log("error");
                    console.log(response);
                }

            });
            console.log('after');
            location.reload();
        }



        $(document).ready(function () {


            $.ajax({
                url: 'ProjectSummary.asmx/GetProjectSummary',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                var table=    $('#datatable').DataTable({

                        data: data,
                        columns: [
                            { 'data': 'title' },
                            { 'data': 'Description' },
                            { 'data': 'createdOn' },
                            { 'data': 'remaingDays' },
                            { 'data': 'reviews' },
                             { 'data': 'status' },
                              //{ 'data': 'markCompleteBtn' },
                        ],
                       


                    });

                }
            });
            var table = $('#datatable');//.DataTable();
            var tableTools = new $.fn.dataTable.TableTools(table);
            $(tableTools.fnContainer()).insertBefore('#datatable_wrapper');
        });

     


</script>

</asp:Content>
