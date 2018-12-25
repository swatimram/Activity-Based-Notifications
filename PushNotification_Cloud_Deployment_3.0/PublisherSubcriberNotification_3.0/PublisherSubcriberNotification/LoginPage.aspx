<%@ Page Title="" Language="C#" MasterPageFile="~/LoginPage.Master" AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs" Inherits="PublisherSubcriberNotification.LoginPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" runat="server">
    <fieldset>
        <div class="form-group">
            <label>
                UserType</label>
            <asp:DropDownList ID="ddlLoginUserType" runat="server" class="form-control" autofocus>
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Publisher</asp:ListItem>
                <asp:ListItem Value="3">Subscriber</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlLoginUserType" ForeColor="#FF3300" InitialValue="0" ValidationGroup="A" runat="server" ErrorMessage="Please User Type"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtLoginEmail" class="form-control" runat="server" placeholder="E-mail"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Email ID"
                ControlToValidate="txtLoginEmail" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLoginEmail"
                ErrorMessage="Email ID Incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtLoginPassword" class="form-control" runat="server" placeholder="Password"
                TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password"
                ControlToValidate="txtLoginPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
        </div>
        <label>
            <a href="#" class="" data-toggle="modal" data-target="#myModal">Create New Account</a>
        </label>
        <%-- <div class="checkbox">
            <label>
                <input name="remember" type="checkbox" value="Remember Me">Remember Me
            </label>
        </div>--%>
        <!-- Change this to a button or input when using this as a form -->
        &nbsp;
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnLogin" class="btn btn-lg btn-success btn-block" runat="server"
            Text="Login" OnClick="btnLogin_Click" ValidationGroup="A" />
        <%--<a href="DashBoard.aspx" class="btn btn-lg btn-success btn-block">Login</a>--%>
    </fieldset>
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Create New Account</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>
                            User Name</label>
                        <asp:TextBox ID="txtUserName" class="form-control" runat="server" placeholder="Enter text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Name"
                ControlToValidate="txtUserName" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <label id="lblUserName" class="errorMsg" style="color:Red">Enter User Name</label>
                    </div>
                    <div class="form-group">
                        <label>
                            Password</label>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Password"
                            TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Password"
                ControlToValidate="txtPassword" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                <label id="lblPassword" class="errorMsg" style="color:Red">Enter Password</label>
                    </div>
                    <div class="form-group">
                        <label>
                            UserType</label>
                        <asp:DropDownList ID="ddlUserType" runat="server" class="form-control" onchange="GetSelectedTextValue(this)">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Publisher</asp:ListItem>
                            <asp:ListItem Value="2">Subscriber</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlUserType" ForeColor="#FF3300" ValidationGroup="B" InitialValue="0" runat="server" ErrorMessage="Please User Type"></asp:RequiredFieldValidator>
                   <label id="lblUserType" class="errorMsg"  style="color:Red">Select User Type</label>
                    </div>
                    <div class="form-group">
                        <label>
                            Email ID</label>
                        <asp:TextBox ID="txtEmailID" class="form-control" runat="server" placeholder="Enter text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Email ID"
                ControlToValidate="txtEmailID" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailID"
                ErrorMessage="Email ID Incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="B"></asp:RegularExpressionValidator>
                <label id="lblEmailId" class="errorMsg" style="color:Red">Enter EmailId</label>
                    </div>
                    <div class="form-group">
                        <label>
                            Mobile No</label>
                        <asp:TextBox ID="txtMobileNo" class="form-control" runat="server" placeholder="Enter text"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtMobileNo" ErrorMessage="Only 10 Digits" ForeColor="#FF3300" 
                    ValidationExpression="[0-9]{10}" ValidationGroup="B"></asp:RegularExpressionValidator>
                     <label id="lblMobileNo" class="errorMsg" style="color:Red">Enter Mobile No</label>
                    </div>
                    <div class="form-group">
                        <label>
                            Address</label>
                        <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Enter text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Address"
                ControlToValidate="txtAddress" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                <label id="lblAddress" class="errorMsg" style="color:Red">Enter Address</label>
                    </div>
                    <div class="form-group">
                       <%-- <asp:Label ID="" runat="server" Text="Device Id" Font-Bold="True"></asp:Label>--%>
                        <%--<asp:TextBox ID="txtDeviceId" class="form-control" runat="server" placeholder="Enter Device Id"></asp:TextBox>--%>
                        <label id="lblDeviceID" class="errorMsg">Device Id</label>
                        <input type="text" class="form-control" id="txtDeviceId" runat="server" value="" placeholder="Enter Device Id" />
                       <label id="lbldevicemsg" class="errorMsg" style="color:Red">Enter Device ID</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" OnClick="btnSubmit_Click" OnClientClick="return YourJavaScriptFunction();"
                        Text="Submit" ValidationGroup="B" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#lblDeviceID').hide();
            $('#lblDeviceID').next().hide();
            $('#lblUserName').hide();
            $('#lblPassword').hide();
            $('#lblUserType').hide();
            $('#lblEmailId').hide();
            $('#lblMobileNo').hide();
            $('#lblAddress').hide();
            $('#lbldevicemsg').hide();
        });
        function GetSelectedTextValue(ddlUserType) {
            var selectedText = ddlUserType.options[ddlUserType.selectedIndex].innerHTML;
            if (selectedText == 'Subscriber') {
                $('#lblDeviceID').show();
                $('#lblDeviceID').next().show();
            }
            else {
                $('#lblDeviceID').hide();
                $('#lblDeviceID').next().hide();
                
            }
        }
        function YourJavaScriptFunction() {
            $('#lblUserName').hide();
            $('#lblPassword').hide();
            $('#lblUserType').hide();
            $('#lblEmailId').hide();
            $('#lblMobileNo').hide();
            $('#lblAddress').hide();
            $('#lbldevicemsg').hide();
            if ($('#lblUserName').prev().prev().val() == "") {
                $('#lblUserName').show();
                return false;
            }
            else if ($('#lblPassword').prev().prev().val() == "") {
                $('#lblPassword').show();
                return false;
            }
            else if ($('#lblUserType').prev().prev().val() == "0") {
                $('#lblUserType').show();
                return false;
            }
            else if ($('#lblEmailId').prev().prev().prev().val() == "") {
                $('#lblEmailId').show();
                return false;
            }
            else if ($('#lblMobileNo').prev().prev().val() == "") {
                $('#lblMobileNo').show();
                return false;
            }
            else if ($('#lblAddress').prev().prev().val() == "") {
                $('#lblAddress').show();
                return false;
            }
            else if ($('#lblUserType').prev().prev().val() == "2") {
                if ($('#lblDeviceID').next().val() == "") {
                    $('#lbldevicemsg').show();
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
</script>
</asp:Content>
