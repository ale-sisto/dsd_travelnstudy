<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudyAbroad.Presentation.Account.Register" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container"> 
        <hgroup>
        <div id="pageTitle">
            <h1><%: Title %></h1> 
        </div>       
        </hgroup>
    <p>
        <asp:Label runat="server" ID="ErrorMessage" EnableViewState="False" CssClass="alert alert-error" Visible="false" />
    </p>
    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Enabled" LoginCreatedUser="False" RequireEmail="False" OnCreateUserError="RegisterUser_CreateUserError" OnCreatingUser="RegisterUser_CreatingUser" ValidateRequestMode="Enabled" DuplicateUserNameErrorMessage="The user name already exists. Please enter a different user name." InvalidPasswordErrorMessage="Invalid password. The minimum lengh is {0}. " UnknownErrorMessage="The user creation request has been canceled. Please verify your entry and try again.">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />            
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep" ViewStateMode="Enabled">
                <ContentTemplate>                    

                    <fieldset>                        
                        <ul class="unstyled">
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" MaxLength="20" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="alert alert-error"
                                    ErrorMessage="The user name field is required." />                               
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="FirstName">First Name</asp:Label>
                                <asp:TextBox runat="server" ID="FirstName" MaxLength="40" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" CssClass="alert alert-error"
                                    ErrorMessage="The first name field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="LastName">Last Name</asp:Label>
                                <asp:TextBox runat="server" ID="LastName" MaxLength="60"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" CssClass="alert alert-error"
                                    ErrorMessage="The last name field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" MaxLength="20" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password" CssClass="alert alert-error"
                                    ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword" CssClass="alert alert-error"
                                    Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="alert alert-error"
                                     Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Country">Country</asp:Label>
                                <asp:DropDownList runat="server" ID="Country" DataTextField="Name" DataValueField="Name" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Country" CssClass="alert alert-error"
                                    ErrorMessage="The country field is required." />
                            </li>
                        </ul>
                        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" CommandName="MoveNext" Text="Register" OnClick="btnRegister_Click" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep runat="server" ID="RegisterUserWizardComplete">
            <ContentTemplate>
                <p class="lead">The user was registered successfully. <a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a> to continue.</p>
            </ContentTemplate>
            <CustomNavigationTemplate />
        </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    <br />
    </div>
</asp:Content>
