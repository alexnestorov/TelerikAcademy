<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="WebFormsControlsApp.Homework.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRegistration" runat="server">
        <div class="form-group">
            <asp:Label ID="LabelFirst" runat="server" Text="First Name" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="form-control" Width="300px" placeholder="First name">
                </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="Please enter first name"
                    ControlToValidate="TextBoxFirstName" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelMiddle" runat="server" Text="Middle Name" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxMiddleName" runat="server" CssClass="form-control" Width="300px" placeholder="Middle name">
                </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter middle name"
                    ControlToValidate="TextBoxMiddleName" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelLast" runat="server" Text="Last name" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="form-control" Width="300px" placeholder="Last name">
                </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter last name"
                    ControlToValidate="TextBoxLastName" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelGrossSalary" runat="server" Text="Gross salary" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxGrossSalary" runat="server" CssClass="form-control" Width="300px" placeholder="460">
                </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter gross salary"
                    ControlToValidate="TextBoxGrossSalary" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelJobs" runat="server" Text="Jobs" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="DropDownListJobs" runat="server" Width="300px" CssClass="form-control">
                    <asp:ListItem Text="Choose job" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Senior dev">Senior dev</asp:ListItem>
                    <asp:ListItem Value="Junior dev">Junior dev</asp:ListItem>
                    <asp:ListItem Value="Devops">Devops</asp:ListItem>
                    <asp:ListItem Value="System administrator">System administrator</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please choose a job offer"
                    ControlToValidate="DropDownListJobs" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCompanies" runat="server" Text="Companies" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="DropDownListCompanies" runat="server" CssClass="form-control" Width="300px">
                    <asp:ListItem Text="Select company" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Google">Google</asp:ListItem>
                    <asp:ListItem Value="Facebook">Facebook</asp:ListItem>
                    <asp:ListItem Value="Twitter">Twitter</asp:ListItem>
                    <asp:ListItem Value="TU SOFIA">TU SOFIA - It is a joke :)</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter specialty"
                    ControlToValidate="DropDownListCompanies" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary" />
        <br />
        <asp:PlaceHolder ID="PlaceHolderStudent" runat="server"></asp:PlaceHolder>
        <asp:Panel ID="PanelStudent" runat="server" BackColor="Green"></asp:Panel>
    </form>
</body>
</html>
