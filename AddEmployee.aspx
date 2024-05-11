<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="HospitalManagementAdmin.AddEmployee" %>

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
        <div class="row mb-4">
            <div class="col-lg-12">
                <h4 class="page-title text-center text-decoration-underline">Add Employee</h4>
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
            <div class="col-sm-3 col-md-3 col-lg-3">
                <div class="form-group">
                    <label>State</label>
                    <select id="ddlstate" runat="server" class="form-control" required="required">
                        <option value="0">-- Select State --</option>
                        <option value="Andhra Pradesh">Andhra Pradesh</option>
                        <option value="Andaman and Nicobar">Andaman and Nicobar</option>
                        <option value="Arunachal Pradesh">Arunachal Pradesh</option>
                        <option value="Assam">Assam</option>
                        <option value="Bihar">Bihar</option>
                        <option value="Chandigarh">Chandigarh</option>
                        <option value="Chhattisgarh">Chhattisgarh</option>
                        <option value="Dadar and Nagar Haveli">Dadar and Nagar Haveli</option>
                        <option value="Daman and Diu">Daman and Diu</option>
                        <option value="Delhi">Delhi</option>
                        <option value="Lakshadweep">Lakshadweep</option>
                        <option value="Puducherry">Puducherry</option>
                        <option value="Goa">Goa</option>
                        <option value="Gujarat">Gujarat</option>
                        <option value="Haryana">Haryana</option>
                        <option value="Himachal Pradesh">Himachal Pradesh</option>
                        <option value="Jammu and Kashmir">Jammu and Kashmir</option>
                        <option value="Jharkhand">Jharkhand</option>
                        <option value="Karnataka">Karnataka</option>
                        <option value="Kerala">Kerala</option>
                        <option value="Madhya Pradesh">Madhya Pradesh</option>
                        <option value="Maharashtra">Maharashtra</option>
                        <option value="Manipur">Manipur</option>
                        <option value="Meghalaya">Meghalaya</option>
                        <option value="Mizoram">Mizoram</option>
                        <option value="Nagaland">Nagaland</option>
                        <option value="Odisha">Odisha</option>
                        <option value="Punjab">Punjab</option>
                        <option value="Rajasthan">Rajasthan</option>
                        <option value="Sikkim">Sikkim</option>
                        <option value="Tamil Nadu">Tamil Nadu</option>
                        <option value="Telangana">Telangana</option>
                        <option value="Tripura">Tripura</option>
                        <option value="Uttar Pradesh">Uttar Pradesh</option>
                        <option value="Uttarakhand">Uttarakhand</option>
                        <option value="West Bengal">West Bengal</option>
                    </select>
                </div>
            </div>
            <div class="col-sm-3 col-md-3 col-lg-3">
                <div class="form-group">
                    <label>Postal Code</label>
                    <input type="text" class="form-control" runat="server" id="txtpostalcode" required="required">
                </div>
            </div>

            <div class="col-sm-3">
                <div class="form-group">
                    <label>Mobile No. </label>
                    <input class="form-control" type="text" runat="server" id="txtmobile" required="required">
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Photo</label>
                    <input type="file" class="form-control" runat="server" id="txtphoto" required="required">
                </div>
            </div>
        </div>
        <div class=" mt-4 text-center">
            <button class="btn btn-primary submit-btn" id="BtnAddEmployee" runat="server" onserverclick="BtnAddEmployee_ServerClick">Add Employee</button>
        </div>
    </main>
</asp:Content>
