<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplePage.aspx.cs" Inherits="StudyAbroad.Presentation.SamplePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample page</title>
    <link rel="shortcut icon" href="images/studyabroad_logo.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript">
        function pageLoad() {
            window.$addHandler(window.$get("topUnis"), "click", getTopUnis);
            window.$addHandler(window.$get("dbtestfull"), "click", dbTestFull);
            window.$addHandler(window.$get("dbtestempty"), "click", dbTestEmpty);
            window.$addHandler(window.$get("dbtestsession"), "click", dbTestSession);
        }
        
        function dbTest(reCreate, initData) {
            showLoading();
            window.PageMethods.DataBaseTest(reCreate, initData, dbtestSuceeds);
        }
        
        function suggTest() {
            showLoading();
            window.PageMethods.GetNextQuestion(dbtestSuceeds);
        }

        function dbTestFull() {
            dbTest(true, true);
        }
        
        function dbTestEmpty() {
            dbTest(true, false);
        }
        
        function dbTestSession() {
            suggTest();
        }

        function dbtestSuceeds() {
            hideLoading();
        }

        function showLoading() {
            var image = window.$get("loading");
            image.style.visibility = "visible";
        }

        function hideLoading() {
            var image = window.$get("loading");
            image.style.visibility = "hidden";
        }

        function getTopUnis() {
            window.$get("univList").innerHTML = "";
            showLoading();
            var code = window.$get("code").value;
            window.PageMethods.GetTopUnis(code, listUniversities, getUnivFail);
        }
      
        function listUniversities(result) {
            hideLoading();
            var univDiv = window.$get("univList");
            for (var i = 0; i < result.length; i++) {
                univDiv.innerHTML += "<p>";
                univDiv.innerHTML += "<b>";
                univDiv.innerHTML += result[i].Rank;
                univDiv.innerHTML += ".</b>";
                univDiv.innerHTML += "       ";
                univDiv.innerHTML += result[i].Name;
                if (result[i].EnglishName != null && result[i].EnglishName != "")
                    univDiv.innerHTML += " ("+result[i].EnglishName+") ";
                if (result[i].CityName != null)
                    univDiv.innerHTML += " - "+result[i].CityName + "   ";
                if (result[i].CountryName != null)
                    univDiv.innerHTML += " - "+result[i].CountryName + "   ";
                univDiv.innerHTML += "</p>";
            }
        }

        function getUnivFail(error) {
            window.$get("univList").innerHTML = error.get_message();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Sample page test</h1>

        Top universities in (enter location code): <input type="text" name="code" id="code" value="world">
        <button type="button" id="topUnis">Click Me!</button> <br/>
        (World - 'world' | 
        Africa - '002' | 
        Europe - '150' | 
        Americas - '019' | 
        Asia - '142' | 
        Oceania - '009') <br/>
        <a href="https://developers.google.com/chart/interactive/docs/gallery/geochart">Find more location codes here!</a> | 
        <a href="http://en.wikipedia.org/wiki/ISO_3166-1">Here!</a> | 
        <a href="http://en.wikipedia.org/wiki/ISO_3166-2:US">And here!</a><br/>

        
        <button type="button" id="dbtestfull">DB test (full recreate)</button>
        <button type="button" id="dbtestempty">DB test (empty recreate)</button>
        <button type="button" id="dbtestsession">DB test (just session)</button>

        <h2>Universities: </h2>
        
        <div id="univList"></div>
        <img id="loading" style="visibility:hidden" src="images/ajax-loader.gif" alt="Loading..."/>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    </div>
    </form>
</body>
</html>
