<%@ Page Title="" Language="C#" MasterPageFile="~/Subscriber.Master" AutoEventWireup="true"
    CodeBehind="SubscriberDashBoard.aspx.cs" Inherits="PublisherSubcriberNotification.SubscriberDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Dashboard</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-comments fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">
                                    <asp:Label ID="lblTotalUsers" runat="server" Text=""></asp:Label></div>
                                <div>
                                    Members</div>
                            </div>
                        </div>
                    </div>
                    <%--<a href="#">
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                            </i></span>
                            <div class="clearfix">
                            </div>
                        </div>
                    </a>--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-green">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-tasks fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">
                                    <asp:Label ID="lblPublisherCount" runat="server" Text=""></asp:Label></div>
                                <div>
                                    Publishers</div>
                            </div>
                        </div>
                    </div>
                    <%--<a href="#">
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                            </i></span>
                            <div class="clearfix">
                            </div>
                        </div>
                    </a>--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-yellow">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-shopping-cart fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">
                                    <asp:Label ID="lblOverallPublishContentCount" runat="server" Text=""></asp:Label></div>
                                <div>
                                    Publish Contents</div>
                            </div>
                        </div>
                    </div>
                    <%--<a href="#">
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                            </i></span>
                            <div class="clearfix">
                            </div>
                        </div>
                    </a>--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-red">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-support fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">
                                    <asp:Label ID="lblTotalSubscribe" runat="server" Text=""></asp:Label></div>
                                <div>
                                    Total Subscribe</div>
                            </div>
                        </div>
                    </div>
                    <%-- <a href="#">
                        <div class="panel-footer">
                            <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                            </i></span>
                            <div class="clearfix">
                            </div>
                        </div>
                    </a>--%>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-clock-o fa-fw"></i>Rate Publish Content's
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <ul class="">
                            <li>
                                <div class="timeline-badge">
                                    <i class=""></i>
                                </div>
                                <div class="">
                                    <div class="timeline-heading">
                                        <h4 class="timeline-title">
                                            Publisher Rating System</h4>
                                      <%--  <p>
                                            <small class="text-muted"><i class="fa fa-clock-o"></i>
                                                </small>
                                        </p>--%>
                                    </div>
                                    <div class="timeline-body">
                                        <p>
                                            Rate the Publisher based on Publish Contents</p>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-8 -->
            <div class="col-lg-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-bell fa-fw"></i>Rating Points 
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <asp:Repeater ID="rptrating" runat="server">
                            <ItemTemplate>
                                <div class="list-group">
                                    <a href="#" class="list-group-item"><i class="fa fa-user"></i>
                                        <%#Eval("Name")%>
                                        <span class="pull-right text-muted small"><i class="fa fa-thumbs-o-up"></i><em>
                                            <%#Eval("Rating")%></em> </span></a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- /.list-group -->
                        <a href="UpdatePublisherRatings.aspx" class="btn btn-default btn-block">View All Alerts</a>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
                <%-- <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-bar-chart-o fa-fw"></i> Donut Chart Example
                        </div>
                        <div class="panel-body">
                            <div id="morris-donut-chart"></div>
                            <a href="#" class="btn btn-default btn-block">View Details</a>
                        </div>
                        <!-- /.panel-body -->
                    </div>--%>
                <!-- /.panel -->
                <!-- /.panel .chat-panel -->
            </div>
            <!-- /.col-lg-4 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
