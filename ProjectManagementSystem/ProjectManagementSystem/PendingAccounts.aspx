<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PendingAccounts.aspx.cs" Inherits="ProjectManagementSystem.PendingAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    


  

       <table class="table table-striped" id="datatable">
           <thead class="thead-dark">
               <tr>
                   <th>Developer Name</th>
                    <th>Designation</th>
                   <th>Date</th>
                    <th>Action</th>
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
                url: "PendingAccounts.aspx/ApproveAccount",
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
                url: 'Accounts.asmx/PendingAccounts',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    $('#datatable').DataTable({

                        data: data,
                        columns: [
                            { 'data': 'DevName' },
                            { 'data': 'Designation' },
                            { 'data': 'CreatedOn' },
                            { 'data': 'ApproveButton' },
                        ]


                    });

                }
            });

        });




</script>



</asp:Content>
