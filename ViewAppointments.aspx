<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewAppointments.aspx.cs" Inherits="HospitalManagementAdmin.ViewAppointments" %>

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
            <div class="row mb-4">
                <div class="col-lg-12">
                    <h4 class="page-title text-center text-decoration-underline">Appointments</h4>
                </div>
            </div>
            <div class="row">
                <asp:Repeater runat="server" ID="RptAppointments">
                    <HeaderTemplate>
                        <table id="tblCustomers" class="table table-hover table-responsive table-bordered">
                            <thead>
                                <tr>
                                    <th>Patient</th>
                                    <th>Mobile</th>
                                    <th>Gender</th>
                                    <th>Department</th>
                                    <th>DoctorName</th>
                                    <th>Appointment Date</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("PatientName")%></td>
                                <td><%#Eval("Mobile")%></td>
                                <td><%#Eval("Gender")%> </td>
                                <td><%#Eval("Department")%> </td>
                                <td><%#Eval("DoctorName")%> </td>
                                <td><%#Eval("AppointDate")%> </td>
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm">Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>
</asp:Content>
