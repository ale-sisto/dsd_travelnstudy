<%@ Page Title="Profile and Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="StudyAbroad.Presentation.test" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup>
        <h1><%: Title %></h1>        
    </hgroup>
    <br />
<section id="dataForm">
    <br />
    <p>Profile data for <strong><%: User.Identity.Name %></strong>.</p>
    <asp:GridView ID="gvPreferences" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" AllowPaging="False" OnRowEditing="gvPreferences_RowEditing" OnRowDataBound="gvPreferences_RowDataBound" OnRowCancelingEdit="gvPreferences_RowCancelingEdit" OnRowUpdating="gvPreferences_RowUpdating" EnableModelValidation="False" >                        
        <Columns>
            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                <EditItemTemplate>
                    <table class="table">
                        <tbody>
                            <tr>
                                <td>First Name</td>
                                <td>
                                    <asp:TextBox runat="server" ID="FirstName" MaxLength="40" Text='<%# Eval("FirstName") %>' />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" CssClass="alert alert-error"
                                        ErrorMessage="The first name field is required." />
                                </td>
                            </tr>
                            <tr>
                                <td>Last Name</td>
                                <td>
                                    <asp:TextBox runat="server" ID="LastName" MaxLength="60" Text='<%# Eval("LastName") %>'/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" CssClass="alert alert-error"
                                        ErrorMessage="The last name field is required." />
                                </td>
                            </tr>
                            <tr>
                                <td>Country</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="Country" DataTextField="Name" DataValueField="Name" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Country" CssClass="alert alert-error"
                                        ErrorMessage="The country field is required." />
                                </td>
                            </tr>
                        </tbody>
                    </table>       
                    <asp:Button ID="btnSave" runat="server" CommandName="Update" CssClass="btn btn-primary" Text="Save" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-primary" Text="Cancel" />
                </EditItemTemplate>
                <ItemTemplate>
                    <table class="table">
                        <tbody>
                            <tr>
                                <td>First Name</td>
                                <td><%# Eval("FirstName") %></td>
                            </tr>
                            <tr>
                                <td>Last Name</td>
                                <td><%# Eval("LastName") %></td>
                            </tr>
                            <tr>
                                <td>Country</td>
                                <td><%# Eval("CountryName") %></td>
                            </tr>
                        </tbody>                        
                    </table>    
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-primary" Text="Edit" />                             
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>    
</section>
<br />
<section id="passwordForm">
<asp:PlaceHolder runat="server" ID="changePassword" Visible="true">
            <h3>Change password</h3>            
            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessText="Your password has been changed.">
                <ChangePasswordTemplate>
                    <p>
                        <asp:Label runat="server" ID="ErrorMessage" EnableViewState="False" CssClass="alert alert-error" Visible="false" />
                    </p>
                    <fieldset>                       
                        <ul class="unstyled">
                            <li>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CurrentPassword" CssClass="alert alert-error"
                                   ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="NewPassword">New password</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="NewPassword" CssClass="alert alert-error"
                                    ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ConfirmNewPassword" CssClass="alert alert-error"
                                    Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" CssClass="alert alert-error"
                                    Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ul>
                        <asp:Button ID="btnChange" runat="server"  CssClass="btn btn-primary" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
</section>
<br /> 
<section id="accountForm">
    <h3>Account Settings</h3> 
    <asp:Button ID="btnRemove" data-toggle="modal" runat="server" CssClass="btn btn-primary" Text="Delete account" OnClick="btnRemove_Click" OnClientClick="if(confirm('Format the hard disk?'))
return true;
else return false;" CausesValidation="False" />
<p><a data-toggle="modal" href="#example" role="button" class="btn btn-primary btn-large">Launch demo modal</a></p>   
<div id="example" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="windowTitleLabel" aria-hidden="true" style="display: none; ">
	<div class="modal-header">
		<a href="#" class="close" data-dismiss="modal">&times;</a>
		<h3>Confirm account deletion</h3>
	</div>
	<div class="modal-body">
		<div class="divDialogElements">
			<h4>Are you sure you want to delete account <strong><%: User.Identity.Name %></strong></h4>
            <p>Note: After removal you will be redirected to the home page</p>
		</div>
	</div>
	<div class="modal-footer">
		<a href="#" class="btn btn-danger" onclick="<%= Page.ClientScript.GetPostBackEventReference(this.btnRemove, string.Empty) %>">Yes</a>
        <a href="#" class="btn btn-success" data-dismiss="modal">No</a>		
	</div>
</div>
</section>
<br />
</asp:Content>
