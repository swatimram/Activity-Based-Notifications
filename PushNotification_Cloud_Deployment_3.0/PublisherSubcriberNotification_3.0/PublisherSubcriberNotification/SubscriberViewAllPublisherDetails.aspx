﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Subscriber.Master" AutoEventWireup="true" CodeBehind="SubscriberViewAllPublisherDetails.aspx.cs" Inherits="PublisherSubcriberNotification.SubscriberViewAllPublisherDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                
                <h3 class="page-header">
                    Publish Content Count Details</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <form id="Form1" role="form" runat="server">
               <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label>
                                        Select Category</label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" autofocus
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                             <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                            </asp:Table>
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                           
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
               
                </form>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
