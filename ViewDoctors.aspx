<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewDoctors.aspx.cs" Inherits="HospitalManagementAdmin.ViewDoctors" %>

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
                <asp:Repeater runat="server" ID="RptDoctors">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="card border-4">
                                <div class="card-body text-center">
                                    <div class="mt-3 mb-4">
                                        <img src='<%#Eval("Photo") %>' class="rounded-circle img-fluid" style="width: 100px;" />
                                    </div>
                                    <h4 class="mb-2"><%#Eval("FullName") %></h4>
                                    <p class="text-muted mb-1"><%#Eval("Email") %></p>
                                    <p class="text-muted mb-1"><%#Eval("Mobile") %></p>

                                    <div class="d-flex justify-content-between text-center mt-3 mb-2">
                                        <div>
                                            <p class="mb-2">City</p>
                                            <p class="text-muted mb-0">Chandrapur</p>
                                        </div>
                                        <div class="px-3">
                                            <p class="mb-2">Country</p>
                                            <p class="text-muted mb-0">India</p>
                                        </div>
                                        <div>
                                            <p class="mb-2">Address</p>
                                            <p class="text-muted mb-0">Chandrapur</p>
                                        </div>
                                    </div>

                                    <button type="button" class="btn btn-primary btn-rounded mt-2 btn-sm">
                                        View More
                                    </button>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>

</asp:Content>
