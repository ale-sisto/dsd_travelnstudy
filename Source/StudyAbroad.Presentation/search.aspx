<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="StudyAbroad.Presentation.search" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="searchResults" runat="server">
        <div class="container">
            <hgroup>
                <div id="pageTitle">
                    <h1><%: Title %> for <%: Cache["q"] %></h1>
                </div>
            </hgroup>
            <br />
            <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" EmptyDataText="No search terms were provided" AllowPaging="True" OnPageIndexChanging="gvResults_PageIndexChanging" Visible="true">
                <Columns>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <ItemTemplate>
                            <div id="searchResult">
                                <img src='<%# Eval("Type") %>' />
                                <h3 class="result">
                                    <a href='<%# Eval("Link") %>'><%# Eval("ResultString") %></a>
                                </h3>
                                <h5>
                                    <ul class="breadcrumb" style="background-color: white">
                                        <li><%# Eval("Continent") %> <span class="divider">/</span></li>
                                        <li><%# Eval("Region") %> <span class="divider">/</span></li>
                                        <li><%# Eval("Country") %> <span class="divider">/</span></li>
                                        <li><%# Eval("City") %></li>
                                    </ul>
                                </h5>
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <p class="lead">No results containing all your search terms were found.</p>
                </EmptyDataTemplate>
                <PagerSettings NextPageText="&amp;gt;  " PreviousPageText="&amp;lt;  " />
                <PagerTemplate>
                    <div id="pagination" class="pagination pagination-large">
                        <ul>
                            <!-- <li id="previousLink" class="disabled"><asp:LinkButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server" ID="btnPrev"/></li> -->
                            <li>
                                <asp:LinkButton Text="1" CommandName="Page" CommandArgument="1" runat="server" /></li>
                            <li>
                                <asp:LinkButton Text="2" CommandName="Page" CommandArgument="2" runat="server" /></li>
                            <!-- <li><asp:LinkButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server" ID="btnNext" /> -->
                        </ul>
                </PagerTemplate>
            </asp:GridView>
            <br />
        </div>
    </asp:PlaceHolder>
</asp:Content>
