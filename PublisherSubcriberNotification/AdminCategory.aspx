<%@ Page Title="" Language="C#" MasterPageFile="~/indexpage.Master" AutoEventWireup="true" CodeBehind="AdminCategory.aspx.cs" Inherits="PublisherSubcriberNotification.AdminCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header">Create Category</h3>
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
                                    <form role="form" runat="server">
                                        <div class="form-group">
                                            <label>Category Name</label>
                                            <asp:TextBox ID="txtCategoryname" class="form-control"  runat="server" placeholder="Category Name" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Category Name"
                ControlToValidate="txtCategoryname" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Category Description</label>
                                            <asp:TextBox ID="txtCategoryDescription" class="form-control"  runat="server" placeholder="Description" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Category Description"
                ControlToValidate="txtCategoryDescription" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" 
                                            onclick="btnSubmit_Click" ValidationGroup="A"/>
                                        <button type="reset" class="btn btn-default">Cancel</button>
                                    &nbsp;
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
