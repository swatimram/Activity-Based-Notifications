<%@ Page Title="" Language="C#" MasterPageFile="~/Publisher.Master" AutoEventWireup="true" CodeBehind="PublisherUserProfile.aspx.cs" Inherits="PublisherSubcriberNotification.PublisherUserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    User Profile</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="Form1" role="form" runat="server">
                                <div class="form-group">
                                    <label>
                                        Email ID</label>
                                    <asp:TextBox ID="txtEmailID" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter EmailID"
                                        ControlToValidate="txtEmailID" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailID"
                                        ErrorMessage="Email ID Incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Mobile No</label>
                                    <asp:TextBox ID="txtMobileNo" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter MobileNo"
                                        ControlToValidate="txtMobileNo" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Only 10 Digits" ForeColor="#FF3300" ValidationExpression="[0-9]{10}"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Address</label>
                                    <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Address"
                                        ControlToValidate="txtAddress" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" ValidationGroup="A"
                                    OnClick="btnSubmit_Click" />
                                <button type="reset" class="btn btn-default">
                                    Cancel</button>
                                &nbsp;&nbsp;
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                </form>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
