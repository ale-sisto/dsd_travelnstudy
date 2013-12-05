<%@ Page Title="Profile and Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="StudyAbroad.Presentation.Account.Profile" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div id="pageTitle">
            <hgroup>
                <h1><%: Title %></h1>
            </hgroup>
        </div>
        <br />
        <section id="dataForm">     
            <h3>Profile data for <strong><%: Session["profileUsername"].ToString() %></strong></h3>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <p>
                        <asp:Label runat="server" ID="profError" EnableViewState="False" CssClass="alert alert-error" Visible="false" />
                        <asp:Label runat="server" ID="profSuccess" EnableViewState="False" CssClass="alert alert-success" Text="The profile has been updated." Visible="false" />
                    </p>
                    <asp:GridView ID="gvPreferences" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" AllowPaging="False" OnRowEditing="gvPreferences_RowEditing" OnRowDataBound="gvPreferences_RowDataBound" OnRowCancelingEdit="gvPreferences_RowCancelingEdit" OnRowUpdating="gvPreferences_RowUpdating" EnableModelValidation="False">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <td><b>First Name</b></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="FirstName" MaxLength="40" Text='<%# Eval("FirstName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" CssClass="alert alert-error"
                                                        ErrorMessage="The first name field is required." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Last Name</b></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="LastName" MaxLength="60" Text='<%# Eval("LastName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" CssClass="alert alert-error"
                                                        ErrorMessage="The last name field is required." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Country</b></td>
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
                                                <td><b>First Name</b></td>
                                                <td><%# Eval("FirstName") %></td>
                                            </tr>
                                            <tr>
                                                <td><b>Last Name</b></td>
                                                <td><%# Eval("LastName") %></td>
                                            </tr>
                                            <tr>
                                                <td><b>Country</b></td>
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
                </ContentTemplate>
                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="gvPreferences" EventName="RowDataBound" />

                </Triggers>
            </asp:UpdatePanel>
            <br />
            <a runat="server" id="btnBack" class="btn btn-primary workaround" href="~/Account/Manage.aspx" visible="false">Back</a>
            <br />
        </section>
        <br />        
        <asp:PlaceHolder ID="ChangePassword" runat="server">
            <section id="passwordForm">            
                <h3>Change password</h3>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <p>
                        <asp:Label runat="server" ID="passError" EnableViewState="False" CssClass="alert alert-error" Visible="false" />
                        <asp:Label runat="server" ID="passSuccess" EnableViewState="False" CssClass="alert alert-success" Text="Your password has been changed." Visible="false" />
                    </p>
                    
                    <fieldset>
                        <ul class="unstyled">
                            <li>
                                <asp:Label runat="server" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" CssClass="alert alert-error"
                                    ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="NewPassword">New password</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" CssClass="alert alert-error"
                                    ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" CssClass="alert alert-error"
                                    Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" CssClass="alert alert-error"
                                    Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ul>
                        <asp:Button ID="btnChange" runat="server" CssClass="btn btn-primary" Text="Change password" ValidationGroup="ChangePassword" OnClick="btnChange_Click" />
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnChange" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            </section>
        </asp:PlaceHolder>        
        <br />        
        <asp:PlaceHolder ID="DeleteUser" runat="server">
            <section id="Section1">
                <h3>Account Settings</h3>
                <asp:Button ID="btnRemove" data-toggle="modal" runat="server" CssClass="btn btn-primary" Text="Delete account" OnClick="btnRemove_Click" OnClientClick="$('#cdialog').modal('show')" CausesValidation="False" />
                <div id="cdialog" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="windowTitleLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-header">
                        <a href="#" class="close" data-dismiss="modal">&times;</a>
                        <h3>Confirm account deletion</h3>
                    </div>
                    <div class="modal-body">
                        <div class="divDialogElements">
                            Are you sure you want to delete account <strong><%: User.Identity.Name %></strong> ?
                <p>Note: After removal you will be redirected to the home page</p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a href="#" class="btn btn-danger">Yes</a>
                        <a href="#" class="btn btn-primary"  data-dismiss="modal">No</a>
                    </div>
                </div>
            </section>
        </asp:PlaceHolder>
        <br />
    </div>
    
    <script>
        
        $('#cdialog a.btn-danger').click(function () {
            $('#cdialog').modal('hide');
            <%= Page.ClientScript.GetPostBackEventReference(this.btnRemove, string.Empty) %>;
        });

    </script>
</asp:Content>
