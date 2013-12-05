<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="suggestion.aspx.cs" Inherits="StudyAbroad.Presentation.suggestion" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div id="pageTitle">
    <h1>Suggestion system</h1>
    </div>
    <div id="subTitle">
         <h2>We'll help you find the right university!</h2>
    </div>  
   
    <div id="question_map"></div>
    <div id="loading_map"></div>
    <div id="error" class="row"></div>    
    <div id="question_text" class="row">
        <div id="wrapper" class="span6 well">
            <div id="question_current"></div>
            <div id="questions_but">
                <span id="explain_menu"></span>
                <span id="question_menu"></span>
           </div>
        </div>
         <div id="question_history" class="span4"></div>
    </div>
         
    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type="text/javascript" src="scripts/suggestion.js"></script>
   <script  type="text/ecmascript"> $('#explain').popover("toggle"); </script>
    </div>
</asp:Content>
