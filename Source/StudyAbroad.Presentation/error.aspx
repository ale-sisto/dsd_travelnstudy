<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="StudyAbroad.Presentation.Error" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div id="pageTitle">
    <h1>
        Error
    </h1>
    </div>
    <p class="lead">
        Sorry, an error has occurred during the current request.
    </p>	
    <p>You can either:</p>
    <ul>
     <li>
	   Return to the <asp:HyperLink ID="HyperLinkHome" runat="server" NavigateUrl="~/Default.aspx" Text="Home Page"></asp:HyperLink>.
     </li>
     <li>
       Contact the administrator.
     </li>
    </ul>
    </div>

</asp:Content>
