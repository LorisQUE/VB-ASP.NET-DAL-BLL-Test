<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Wdr_Test.Master" CodeBehind="frmTest.aspx.vb" Inherits="Wdr_Tests_IHM.frmTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <script type="text/javascript">

            $(function () {
                $("#ctl00_ContentPlaceHolder1_table").DataTable();
            });

     </script>

    <!--<datatable id="example" class="display" style="width:100%" runat="server">
        <thead>
            <tr>
                <th>UniqueId</th>
                <th>Libelle</th>
            </tr>
        </thead>
        
        <tfoot>
            <tr>
                <th>UniqueId</th>
                <th>Libelle</th>
            </tr>
        </tfoot>
    </datatable>-->

    <asp:Table ID="table" runat="server" Width="100%">
        <asp:TableRow>
          <asp:TableCell>UniqueId</asp:TableCell>
           <asp:TableCell>Libl</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>