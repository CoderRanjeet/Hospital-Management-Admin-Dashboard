<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HospitalManagementAdmin.Home" %>

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
        <div class="pagetitle">
            <h1>Dashboard</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
                    <li class="breadcrumb-item active">Dashboard</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section dashboard">
            <div class="row">

                <!-- Left side columns -->
                <div class="col-lg-12">
                    <div class="row">

                        <!-- Sales Card -->
                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card sales-card">
                                <div class="card-body">
                                    <h5 class="card-title">Appointments <span>| Today</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-cart"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <label runat="server" id="lblappointment"></label>
                                            </h6>
                                            <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">Our Appointments</span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <!-- End Sales Card -->

                        <!-- Revenue Card -->
                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card revenue-card">
                                <div class="card-body">
                                    <h5 class="card-title">Revenue <span>| This Month</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-currency-dollar"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>3,264</h6>
                                            <span class="text-success small pt-1 fw-bold">8%</span> <span class="text-muted small pt-2 ps-1">increase</span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <!-- End Revenue Card -->

                        <!-- Customers Card -->
                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card customers-card">
                                <div class="card-body">
                                    <h5 class="card-title">Patients <span>| This Year</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-people"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <label runat="server" id="lblpatients"></label>
                                            </h6>
                                            <span class="text-danger small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">decrease</span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- End Customers Card -->
                        <!-- Customers Card -->
                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card customers-card">
                                <div class="card-body">
                                    <h5 class="card-title">Doctors <span>| This Year</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-people"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <label runat="server" id="lbldoctors"></label>
                                            </h6>
                                            <span class="text-muted small pt-2 ps-1">Our Doctors</span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- End Customers Card -->
                    </div>

                    <!-- Recent Sales -->
                    <div class="col-12">
                        <div class="card recent-sales overflow-auto">

                            <div class="filter">
                                <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>

                            <div class="card-body">
                                <h5 class="card-title">Appoinments <span>| Today</span></h5>
                                <asp:Repeater runat="server" ID="RptAppointments" OnItemCommand="RptAppointments_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-borderless datatable">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Patient</th>
                                                    <th scope="col">Mobile</th>
                                                    <th scope="col">Gender</th>
                                                    <th scope="col">Department</th>
                                                    <th scope="col">DoctorName</th>
                                                    <th scope="col">Appointment Date</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tbody>
                                            <tr>
                                                <th scope="row"><%#Eval("PatientName")%></th>
                                                <td><%#Eval("Mobile")%></td>
                                                <td><%#Eval("Gender")%> </td>
                                                <td><%#Eval("Department")%> </td>
                                                <td><%#Eval("DoctorName")%> </td>
                                                <td><%#Eval("AppointDate")%> </td>
                                                <td>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("Mobile")%>'>Edit</asp:LinkButton>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("Mobile")%>'>Delete</asp:LinkButton>
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
                    </div>
                    <!-- End Recent Sales -->

                    <!-- Top Selling -->
                    <div class="col-12">
                        <div class="card recent-sales overflow-auto">

                            <div class="filter">
                                <a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>

                            <div class="card-body">
                                <h5 class="card-title">Doctors <span>| All</span></h5>
                                <asp:Repeater runat="server" ID="RptDoctors" OnItemCommand="RptDoctors_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-borderless datatable">
                                            <thead>
                                                <tr>
                                                    <th scope="col">FullName</th>
                                                    <th scope="col">Email</th>
                                                    <th scope="col">DOB</th>
                                                    <th scope="col">Gender</th>
                                                    <th scope="col">Address</th>
                                                    <th scope="col">Mobile Number</th>
                                                    <th scope="col">Action</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tbody>
                                            <tr>
                                                <th scope="row"><%#Eval("FullName")%></th>
                                                <td><%#Eval("Email")%></td>
                                                <td><%#Eval("DOB")%> </td>
                                                <td><%#Eval("Gender")%> </td>
                                                <td><%#Eval("Address")%> </td>
                                                <td><%#Eval("Mobile")%> </td>
                                                <td>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("Email")%>'>Edit</asp:LinkButton>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("Email")%>'>Delete</asp:LinkButton>
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
                    </div>
                    <!-- End Top Selling -->
                </div>
                <!-- End Left side columns -->
            </div>
        </section>

    </main>
    <!-- End #main -->
</asp:Content>
