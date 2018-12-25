<%@ Page Title="" Language="C#" MasterPageFile="~/Subscriber.Master" AutoEventWireup="true" CodeBehind="SubscriberViewPublishContent.aspx.cs" Inherits="PublisherSubcriberNotification.SubscriberViewPublishContent" %>
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
                            <asp:LinkButton ID="lnkSubscribe" runat="server" onclick="lnkSubscribe_Click">Subscribe</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <!-- /.panel -->
               
                </form>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
