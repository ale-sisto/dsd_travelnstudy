<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="StudyAbroad.Presentation._default" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <!--Adobe Edge Runtime-->
    <script type="text/javascript" charset="utf-8" src="/scripts/dsd_home_edgePreload.js"></script>
    <style>
        .edgeLoad-EDGE-731251 { visibility:hidden; }
    </style>
<!--Adobe Edge Runtime End-->
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="container">
        <div id="pageTitle"><h1>Find the right university for you!</h1>
	    </div>
    </div>
    <div class="container-fluid">
        

        <div class="row">
            <div class=" span3" id="button-menu">
                <a href="suggestion.aspx"class="btn btn-primary btn-block">Suggestion</a>
                <a href="explore.aspx" class="btn btn-primary btn-block">Explore</a>
                <a href="about.aspx" class="btn btn-primary btn-block">About</a>
            </div>   
            <div class="span8">
            <div id="Stage" class="EDGE-731251"></div>

            </div>    
	    </div> 
    </div>
    

    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type="text/javascript" src="scripts/home.js"></script>


    <asp:LoginView runat="server"  ViewStateMode="Disabled" EnableViewState="False">
        <AnonymousTemplate>    
        <script type="text/javascript">$(document).ready(function () { $("#topUni").css('display', 'block'); }); </script>            
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>
                 <script type="text/javascript">$(document).ready(function() { $("#topUni").css('display','block'); }); </script>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="User">
                <ContentTemplate>
                          <div class="container">
                              <div id="recom" class="row">    
                              </div>
                              <div id="reccModal" class="modal hide fade active" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                   <div class="modal-header">
                                        <h3 id="myModalLabel" style="text-align:center">Other Suggestions</h3>
                                    </div>
                                    <div id="recom_addcontent"class="modal-body" style="">
                                    </div> 
                                    <div class="modal-footer" style="">
                                        <a data-dismiss="modal" aria-hidden="true"><i class="icon-remove"></i> <b>Close</b><a/>
                                    </div>
                                </div>
                              <script type="text/javascript">$(document).ready(getRecom())</script>
                          </div>  
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>


    <div class="container">
        <div class="row" id="topUni">
            <h2>Top Universities</h2>
		    <div class= "row">
			    <div class= "span4"> 
				    <h4>North America</h4>
				    <ol class="dinamicGenerated">
                        <asp:Repeater id="naRepeater" runat="server">						
                            <ItemTemplate>
                                <li><a href="<%# DataBinder.Eval(Container.DataItem,"Link") %>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
				    </ol>
			    </div>
			    <div class= "span4"> 
				    <h4>Worldwide</h4>
				    <ol class="dinamicGenerated">
					    <asp:Repeater id="worldRepeater" runat="server">						
                            <ItemTemplate>
                                <li><a href="<%# DataBinder.Eval(Container.DataItem,"Link") %>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
				    </ol>
			    </div>
			    <div class= "span4"> 
				    <h4>Europe</h4>
				    <ol class="dinamicGenerated">
					    <asp:Repeater id="euRepeater" runat="server">						
                            <ItemTemplate>
                                <li><a href="<%# DataBinder.Eval(Container.DataItem,"Link") %>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
				    </ol>
			    </div>
		    </div> 
        </div>
    </div>    

</asp:Content>
