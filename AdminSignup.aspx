<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSignup.aspx.cs" Inherits="HospitalManagementAdmin.AdminSignup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <main>
            <div class="container">
                <section class="section register d-flex flex-column align-items-center justify-content-center">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8 col-md-10 d-flex flex-column align-items-center justify-content-center">

                                <div class="d-flex justify-content-center py-4">
                                    <a href="index.html" class="logo d-flex align-items-center w-auto">
                                        <img src="assets/img/logo.png" alt="" />
                                        <span class="d-none d-lg-block">Hospital Management</span>
                                    </a>
                                </div>
                                <!-- End Logo -->

                                <div class="card mb-3">
                                    <div class="card-body">

                                        <div class="pt-4 pb-2">
                                            <h4 class="card-title text-center pb-0 fs-3">Create an Account</h4>
                                            <p class="text-center small fs-6">Enter your personal details to create account</p>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="form-label">Enter Name</label>
                                                <input type="text" name="name" class="form-control" runat="server" id="txtName" required="required" />

                                            </div>

                                            <div class="col-md-6">
                                                <label class="form-label">Enter Email</label>
                                                <input type="email" name="email" class="form-control" runat="server" id="txtEmail" required="required" />
                                            </div>
                                        </div>

                                        <div class="row mt-3 mb-3">
                                            <div class="col-md-6">
                                                <label for="yourName" class="form-label">Enter Mobile</label>
                                                <input type="text" name="name" class="form-control" runat="server" id="txtMobile" required="required" />

                                            </div>

                                            <div class="col-md-6">
                                                <label for="yourEmail" class="form-label">Enter Address</label>
                                                <input type="text" class="form-control" runat="server" id="txtAddress" required="required" />
                                            </div>
                                        </div>

                                        <div class="row mt-3 mb-3">
                                            <div class="col-md-6">
                                                <label for="yourName" class="form-label">Enter Password</label>
                                                <input type="text" name="name" class="form-control" runat="server" id="txtpassword" required="required" />

                                            </div>

                                            <div class="col-md-6">
                                                <label for="yourEmail" class="form-label">Confirm password</label>
                                                <input type="text" class="form-control" id="txtcpassword" runat="server" required="required" />
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <div class="form-check">
                                                <input class="form-check-input" name="terms" type="checkbox" value="" id="acceptTerms" required="required" />
                                                <label class="form-check-label" for="acceptTerms">I agree and accept the <a href="#">terms and conditions</a></label>
                                                <div class="invalid-feedback">You must agree before submitting.</div>
                                            </div>
                                        </div>
                                        <div class="col-12 mt-3 mb-3">
                                            <button class="btn btn-primary" type="submit" runat="server" id="BtnCreate" onserverclick="BtnCreate_ServerClick">Create Account</button>
                                        </div>
                                        <div class="col-12">
                                            <p class="small mb-0">Already have an account? <a href="AdminLogin.aspx">Log in</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="credits justify-content-center d-flex">
                            Designed by <a href="#">SSIT College Students</a>
                        </div>
                    </div>

                </section>
            </div>
        </main>
        <!-- End #main -->
    </form>
</body>
</html>
