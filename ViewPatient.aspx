<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewPatient.aspx.cs" Inherits="HospitalManagementAdmin.ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link rel="stylesheet" href="sweetalert2.min.css" />
    <script type="text/javascript">
        function AlertMessage(Title, message, MessageType) {
            Swal.fire
                (
                    Title, message, MessageType
                )
        }
    </script>

    <main id="main" class="main">
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="RptPatients">
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>
</asp:Content>
