<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyAbroad.Presentation.Account.Login" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
    <hgroup>
    <div id="pageTitle">
        <h1><%: Title %></h1>
    </div>
    </hgroup>

    <div id="loginForm">        
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" DisplayRememberMe="false" ValidateRequestMode="Enabled" VisibleWhenLoggedIn="False" ID="LoginUSer" OnLoggedIn="LoginUSer_LoggedIn">
            <LayoutTemplate>
                <p>
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>                    
                    <ul class="unstyled">
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName"><b>User name</b></asp:Label>
                            <asp:TextBox runat="server" ID="UserName" MaxLength="20" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="alert alert-error" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password"><b>Password</b></asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" MaxLength="20" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="alert alert-error" ErrorMessage="The password field is required." />
                        </li>                        
                    </ul>
                    <asp:Button runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Login" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <br />
        <p class="lead">
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </div>    
    </div>
</asp:Content>
