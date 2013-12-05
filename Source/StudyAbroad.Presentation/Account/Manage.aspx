<%@ Page Title="Manage Accounts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="StudyAbroad.Presentation.Account.Manage" EnableEventValidation="false" %>

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
        <section id="loginsForm">
            <br />            
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" GridLines="None" EnableModelValidation="False" OnRowDataBound="gvUsers_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="First Name" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Surname" HeaderText="Last Name" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <a href="../Account/Profile.aspx?u=<%# Eval("Username") %>" class="btn btn-primary">Modify</a>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkDelete" CssClass="btn btn-primary" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                    
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkMasterDelete" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            
            <asp:LinkButton ID="lnkMasterDelete" runat="server" OnClick="lnkMasterDelete_Click" style="display:none;" />
            <div id="cdialog" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="windowTitleLabel" aria-hidden="true" style="display: none;">
                <div class="modal-header">
                    <a href="#" class="close" data-dismiss="modal">&times;</a>
                    <h3>Confirm account deletion</h3>
                </div>
                <div class="modal-body">
                    <div class="divDialogElements">
                        Are you sure you want to delete the account ?            
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" class="btn btn-danger">Yes</a>
                    <a href="#" class="btn btn-primary" data-dismiss="modal">No</a>
                </div>
            </div>
        </section>
        <br />
    </div>

    <script>
        
        $('#cdialog a.btn-danger').click(function () {
            __doPostBack("<%= this.lnkMasterDelete.UniqueID %>", username); 
            $('#cdialog').modal('hide');
        });

    </script>
</asp:Content>
