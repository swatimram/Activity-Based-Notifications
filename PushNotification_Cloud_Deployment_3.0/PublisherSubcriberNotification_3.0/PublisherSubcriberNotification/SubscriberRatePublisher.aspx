<%@ Page Title="" Language="C#" MasterPageFile="~/Subscriber.Master" AutoEventWireup="true"
    CodeBehind="SubscriberRatePublisher.aspx.cs" Inherits="PublisherSubcriberNotification.SubscriberRatePublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Subscriber Rate Publisher</h3>
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
                                        Rate Publisher (1 - 10)
                                    </label>
                                    <asp:TextBox ID="txtRating" class="form-control" runat="server" placeholder="1 - Immediate Response,10 - Delay"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Rating"
                                        ControlToValidate="txtRating" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtRating" ErrorMessage="Only Digits" ForeColor="#FF3300" 
                    ValidationExpression="[0-9]" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </div>
                                <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                    ValidationGroup="A" />
                                <button type="reset" class="btn btn-default">
                                    Cancel</button>
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
