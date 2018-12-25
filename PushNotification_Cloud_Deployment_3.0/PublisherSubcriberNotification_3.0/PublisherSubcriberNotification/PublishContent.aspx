﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Publisher.Master" AutoEventWireup="true"
    CodeBehind="PublishContent.aspx.cs" Inherits="PublisherSubcriberNotification.PublishContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                   Publish Content</h3>
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
                                        Select Category</label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" autofocus>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlCategory"
                                        ForeColor="#FF3300" InitialValue="0" ValidationGroup="A" runat="server" ErrorMessage="Please User Type"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Title</label>
                                    <asp:TextBox ID="txtTitle" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Title"
                                        ControlToValidate="txtTitle" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Sub Title</label>
                                    <asp:TextBox ID="txtSubTitle" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Sub Title"
                                        ControlToValidate="txtSubTitle" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Description</label>
                                    <textarea id="txtDespcription" name="content" runat="server"></textarea>
                                    <%--<asp:TextBox ID="txtDespcription" class="form-control" runat="server"></asp:TextBox>--%>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Description"
                                        ControlToValidate="txtDespcription" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
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
