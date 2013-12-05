<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="explore.aspx.cs" Inherits="StudyAbroad.Presentation.explore" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type='text/javascript' src='scripts/map.js'></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&amp;sfgdata=+sfgRmluamFuX1R5cGU9amF2YV9zY3JpcHQmRmluamFuX0xhbmc9dGV4dC9qYXZhc2NyaXB0+a"></script>
    
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div id="pageTitle">
        <h1>Explore</h1>
    </div>

    <ul class="breadcrumb" id="mapBread">
        <li id="nav_world"><a id="nav_world_link" href="javascript:showWorld();">World</a> <span class="divider">/</span></li>
        <li id="nav_continent" style="display:none"><a id="nav_continent_link" href="javascript:showLastContinent();">Continent</a> <span class="divider">/</span></li>
        <li id="nav_subcontinent" style="display:none"><a id="nav_subcontinent_link" href="javascript:showLastSubContinent();">Region</a> <span class="divider">/</span></li>
        <li id="nav_country" style="display:none"><a id="nav_country_link" href="javascript:showLastCountry();">Country</a> <span class="divider">/</span></li>
        <li id="nav_province" style="display:none">US province</li>
        <li id="map_loading" style="display:none"><img src="images/ajax-loading-transparent.gif"/>Map is loading...</li>
        <li id="map_error" style="display:none"><img src="images/icon_alert_error.gif"/>Error loading cities list</li>
    </ul>

    <div id="dynamic_load" class="row">
    
        <div class="span4">
        <h3>Top universities</h3>
        <div id="universities_list"></div>
        </div>
        <div class="span8">
            <div id="map_div"></div>
            <div id="city_div">
                <h3 id="city_name">City Info</h3>
                <p id="city_abstract"></p>
                <a id="city_link"></a>
            </div>
        </div>
            
    </div>
  </div>
</asp:Content>
