<%@ Page Title="" Language="C#" MasterPageFile="~/Publisher.Master" AutoEventWireup="true" CodeBehind="PublisherPasswordChange.aspx.cs" Inherits="PublisherSubcriberNotification.PublisherPasswordChange" %>
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
                                        Old Password</label>
                                    <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Old Password"
                                        ControlToValidate="txtPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    
                                </div>
                                <div class="form-group">
                                    <label>
                                        New Password</label>
                                    <asp:TextBox ID="txtNewPassword" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New Password"
                                        ControlToValidate="txtNewPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    
                                </div>
                                <div class="form-group">
                                    <label>
                                        Confirm Password</label>
                                    <asp:TextBox ID="txtConPassword" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Address"
                                        ControlToValidate="txtConPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="txtNewPassword" ControlToValidate="txtConPassword" 
                                        ErrorMessage="Password MisMatch" ForeColor="#FF3300" ValidationGroup="A"></asp:CompareValidator>
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
