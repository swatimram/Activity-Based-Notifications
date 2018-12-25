<%@ Page Title="" Language="C#" MasterPageFile="~/Publisher.Master" AutoEventWireup="true"
    CodeBehind="PublishContentDetailsView.aspx.cs" Inherits="PublisherSubcriberNotification.PublishContentDetailsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Publish Content Details</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <form id="Form1" role="form" runat="server">
                <!-- /.panel -->
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4>
                            <b>Title: </b>
                            <%=HttpContext.Current.Session["PublishContentTitle"]%></h4>
                        <h5>
                            <b>Sub Title: </b>
                            <%=HttpContext.Current.Session["PublishContentSubTitle"]%></h5>
                    </div>
                    <div class="panel-body">
                        <%=HttpContext.Current.Session["PublishContentDescp"]%>
                    </div>
                    <div class="panel-footer">
                        <!--Panel Footer-->
                        <div class="pull-right" style="margin-top: -10px;">
                            <asp:LinkButton ID="lnkEdit" data-toggle="modal" data-target="#myModal" runat="server">Edit</asp:LinkButton>
                            |
                            <asp:LinkButton ID="lnkDelete" data-toggle="modal" data-target="#DeleteModal" runat="server">Delete</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <!-- /.panel -->
                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Edit Publish Content</h4>
                            </div>
                            <div class="modal-body">
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
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" ValidationGroup="A" OnClick="btnSubmit_Click"/>
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="DeleteModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Delete Publish Content</h4>
                            </div>
                            <div class="modal-body">
                                <h5>Are you sure delete publish content?</h5>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btndelete" class="btn btn-default" runat="server" Text="Submit" OnClick="btndelete_Click"/>
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                </form>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
