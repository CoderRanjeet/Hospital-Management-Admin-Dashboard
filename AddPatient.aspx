<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="HospitalManagementAdmin.AddPatient" %>

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

    <style>
        input, select {
            margin-top: 10px;
        }

        label {
            margin-top: 5px;
        }
    </style>
    <main id="main" class="main">
        <div class="row mb-4">
            <div class="col-lg-12">
                <h4 class="page-title text-center text-decoration-underline">Add Patient</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Full Name <span class="text-danger">*</span></label>
                    <input class="form-control" type="text" runat="server" id="txtfname" required="required">
                </div>
            </div>

            <div class="col-sm-6">
                <div class="form-group">
                    <label>Email <span class="text-danger">*</span></label>
                    <input class="form-control" type="email" runat="server" id="txtemail" required="required">
                </div>
            </div>

            <div class="col-sm-6">
                <div class="form-group">
                    <label>Date of Birth</label>
                    <input type="date" runat="server" class="form-control" id="txtdob" required="required">
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="gender">Gender:</label>
                    <select class="form-control" runat="server" id="ddlgender" required="required">
                        <option value="">-- select Gender --</option>
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                        <option value="other">Other</option>
                    </select>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label>Address</label>
                            <input type="text" runat="server" class="form-control" id="txtaddress" required="required">
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-3">
                <div class="form-group">
                    <label>City</label>
                    <input type="text" runat="server" class="form-control" id="txtcity" required="required">
                </div>
            </div>

            <div class="col-sm-3">
                <div class="form-group">
                    <label>Mobile No. </label>
                    <input class="form-control" type="text" runat="server" id="txtmobile" required="required">
                </div>
            </div>

        </div>
        <div class=" mt-4 text-center">
            <button class="btn btn-primary submit-btn" id="BtnAddPatient" onserverclick="BtnAddPatient_ServerClick" runat="server">Add Patient</button>
        </div>
    </main>
</asp:Content>
