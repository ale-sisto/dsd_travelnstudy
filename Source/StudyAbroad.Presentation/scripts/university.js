//Probably it should be better if we don't use a global variable
// to store the DTO. 
var uni; // global variable used to store university DTO

var tab_open = false;
var students_options, students_data, students_chart, students_done=false, students_drawn=false;
var costs_options, costs_data, costs_chart, costs_done = false, costs_drawn = false;
var rank1_options, rank1_data, rank1_chart, rank1_done = false, rank1_drawn = false;
var rank2_options, rank2_data, rank2_chart, rank2_done = false, rank2_drawn = false;
var admission_options, admission_data, admission_chart, admission_done = false, admission_drawn = false;
var timeout;
var imageSearch;


$(window).load(function () {
    timeout = setTimeout(function () { $('#loaderModal').modal('show'); }, 250);
});

google.load("visualization", "1", { packages: ["corechart"] });
google.load('search', '1');

$(document).ready(populatePage());

//This method is used to actually call GetuniversityData
//method from the server with the university name as parameter
function populatePage() {
    var uni_name = getUrlParameter("name");
    if (uni_name) {
        uni_name = ["universityName", uni_name];
        PageMethod("GetUniversityData", uni_name, successPopulateCallback, generalFail, true);        
    }
}

function searchComplete() {

    // Check that we got results
    if (imageSearch.results && imageSearch.results.length > 0) {
        var img = new Image();

        img.onload = function () {
            uni.imageUrl = imageSearch.results[0].url;
            makeHeader();
        }
        img.onerror = function () {
            uni.imageUrl = imageSearch.results[0].tbUrl;
            makeHeader();
        }
        img.src = imageSearch.results[0].url;
    }
}


function getLogo() {
    imageSearch = new google.search.ImageSearch();
    //we only want the 1st image
    imageSearch.setResultSetSize(1);
    imageSearch.setSearchCompleteCallback(this, searchComplete, null);

    // Find me a beautiful car.
    imageSearch.execute(uni.name + ' logo');
        
    // Include the required Google branding
    //google.search.Search.getBranding('branding');
}


// CALLBACK HANDLERS
//########################################################################
function successPopulateCallback(result) {
        
        uni = result.d;
        //getLogo calls the makeHeader when the url is available (avoids drawing the wrong picture because we're late with the search)
        if (uni.imageUrl == 'images/no_image.png') {
            getLogo();
        }
        else {
            makeHeader();
        }

        $('#loaderModal').modal('hide');

        makeAreasOfStudies();
        makeAdmissionChart();
        makeStudentsTypeChart();
        makingIntroduction();        
       
        //Ok, the page has been drawn... start with avdanced widgets
        //Give an address for google places
        setAddressForPlaces(uni.address);
        var parameter = ["uniName", uni.name];
        //Fetch average rank info
        PageMethod("GetAVGRanks", parameter, successRanksCallback, generalFail, true);
        //Fetch average costs info
        PageMethod("GetAVGCosts", parameter, successCostsCallback, generalFail, true);
        //Fetch rank info about locations related
        PageMethod("GetRegionRanks", parameter, successRelativeRanksCallback, generalFail, true);
        makeReviewSection();
    }

    function successCostsCallback(res) {
        if (uni.controlType != 'Not reported') {
            document.getElementById('controlType_p').innerHTML = 'This is a <b>' + uni.controlType.toLowerCase() + '</b> university';
        }
        costs_data = new google.visualization.DataTable();
        costs_data.addColumn("string", "Region");
        costs_data.addColumn("number", "Undergraduates (US $)");
        costs_data.addColumn("number", "Postgraduates (US $)");
        var i = 0;
        var avgundergraduate = uni.intStudentsGradPrice;
        var b = uni.intStudentsPostGradPrice;
        costs_data.addRow([uni.name, parseCostString(uni.intStudentsGradPrice), parseCostString(uni.intStudentsPostGradPrice)]);
        for (i = 0; i < res.d.length; i += 3) {
            costs_data.addRow([res.d[i], parseInt(res.d[i + 1]), parseInt(res.d[i + 2])]);
        }

        costs_options = {
            height: '500',
            //width: getActiveTabWidth(),
            chartArea: {width: '70%'},
            colors: ['2FA4E7', '033C73'],
            title: 'Costs Comparison (US $)',
            hAxis: { title: 'Region averages', titleTextStyle: { color: 'black' } },
            backgroundColor: { fill:'transparent' }
        };
            
        costs_done = true;
        if (tab_open) {
            charts_show();
        }
    }

    function successRelativeRanksCallback(res) {
        rank1_data = new google.visualization.DataTable();
        rank1_data.addColumn("string", "Region");
        rank1_data.addColumn("number", "Rank");
        rank1_options = {
            height: '500',
            //width: getActiveTabWidth(),
            chartArea: { width: '70%' },
            colors: ['2FA4E7'],
            title: 'Relative ranks',
            hAxis: { title: 'Rank position within regions', titleTextStyle: { color: 'black' } },
            backgroundColor: { fill: 'transparent' }
        };
        //alert(res.d);
        rank1_data.addRow([uni.name, uni.rank]);
        for (var i = 0; i < res.d.length; i++) {
            rank1_data.addRow([res.d[i].regionName, res.d[i].rank]);
        }
        rank1_done = true;
        if (tab_open) {
            charts_show();
        }
    }

    function successRanksCallback(res) {
        rank2_data = new google.visualization.DataTable();
        rank2_data.addColumn("string", "Region");
        rank2_data.addColumn("number", "Rank");
        var i = 0;
        rank2_data.addRow([uni.name, uni.globalRank]);
        for (i = 0; i < res.d.length; i += 2) {
            rank2_data.addRow([res.d[i], parseInt(res.d[i + 1])]);
        }

        rank2_options = {
            height: '500',
            //width: getActiveTabWidth(),
            chartArea: { width: '70%' },
            colors: ['2FA4E7'],
            title: 'Average rank comparison',
            hAxis: { title: 'Region averages', titleTextStyle: { color: 'black' } },
            backgroundColor: { fill: 'transparent' }
        };

        rank2_done = true;
        if (tab_open) {
            charts_show();
        }
}

//general fail callback handler
//we use this method to handle server errors
    function generalFail() {
        //#TODO       
    }


//HTML POPULATIONS: Functions used to populate page html with dynamic data
//########################################################################
    function makeHeader() {

        // use standard name if english one is not available
        // when i try to debug these lines are not existing :/
        var uni_name = uni.englishName;
        if (uni_name == "") uni_name = uni.name;

        clearTimeout(timeout);
        $("#content_page_header").css("display", "block");
        $("#uniContainer").css("display", "table");

        //Create the breadcrumb
        $("#mapBread").html("<li><a href='city.aspx?name=" + uni.cityName + '&country=' + uni.countryLink +
            "'>" + uni.cityName + "</a> <span class='divider'>/</span></li>" +
                   "<li class='active'>" + uni_name + "</li>");
        

        //Title
        $("#uni_title").html(uni_name);

        //foundation
        if (uni.foundationYear != "Not Reported")
            $("#foundation").html("<b>Foundation year: </b>" + uni.foundationYear);

        //Subtitle ( city + nation )
        $("#location").append("<a href='city.aspx?name=" + uni.cityName + '&country=' + uni.countryLink + "'>"
            + uni.cityName + "</a>, " + uni.countryName);
       
        //Motto 
        if (uni.motto != "Not reported") {
            $("#motto").html('"' + uni.motto + '"\n<small>University Motto</small>');
        }

        $("#global_rank").append(uni.globalRank + " ");

        //Website
        $("#web_link").attr("href", uni.officialWebUrl);
        $("#city").attr("href", "city.aspx?name=" + uni.cityName + '&country=' + uni.countryLink);
        $("#city").html("<b>" + uni.cityName + " City Page</b>");

        //Image
        $("#title_image").html("<img src='" + uni.imageUrl + "' />");
    }

    function isIn(val, ar) {
        for (var i in ar) {
            if (ar[i] == val) return true;
            else if (ar[i] > val) return false;
        }
        return false;
    }

    function getTableRow(ar, name) {
        var value = '<tr><td>' + name + '</td>';
        for (var i = 0; i <= 4; i++) {
            value += '<td><p align="center">';
            if (isIn(i, ar)) value += '<img class="uni_checkbox" src="images/university/check-box.jpg" width=32 height=32></img>';
            else value += '';
            value += '</p></td>';
        }
        
        value += '</tr>';
        return value;
    }

    function makeAreasOfStudies() {
        
        var value = '';
        value += '<table class="table table-striped">';
        value += '<tr><th></th><th>Certificates or diplomas</th><th>Associate degrees</th><th>Bachelor degrees</th><th>Master degrees</th><th>Doctorate degrees</th></tr>';

        value += getTableRow(uni.areasOfStudies.ArtsHumanities, 'Arts and humanities');
        value += getTableRow(uni.areasOfStudies.BusinessSocialSciences, 'Business and social sciences');
        value += getTableRow(uni.areasOfStudies.LanguageCulturalStudies, 'Language and cultural studies');
        value += getTableRow(uni.areasOfStudies.MedicineHealth, 'Medicine');
        value += getTableRow(uni.areasOfStudies.Engineering, 'Engineering');
        value += getTableRow(uni.areasOfStudies.ScienceTechnology, 'Science & Technology');

        value += '</table>';
        document.getElementById('studies').innerHTML = value;

        value = '<b>Faculties: </b>';
        for (var d in uni.academicStructure) {
            value += uni.academicStructure[d];
            if (d < uni.academicStructure.length - 1) value += ', ';
        }
        document.getElementById('structure').innerHTML = value;
    }

    function getHTMLForGender(str) {
        var value='';
        if (str == 'Men and Women') {
            value += '<img href="#" rel="tooltip" data-placement="top" title="Women are admitted" src="images/university/fy.png"><img href="#" rel="tooltip" data-placement="top" title="Men are admitted" src="images/university/my.png">';

        }
        else if (str == 'Women Only') {
            value += '<img href="#" rel="tooltip" data-placement="top" title="Women are admitted" src="images/university/fy.png"><img href="#" rel="tooltip" data-placement="top" title="Men are NOT admitted" src="images/university/mn.png">';
        }
        else if (str == 'Men Only') {
            value += '<img href="#" rel="tooltip" data-placement="top" title="Women are NOT admitted" src="images/university/fn.png"><img href="#" rel="tooltip" data-placement="top" title="Men are admitted" src="images/university/my.png">';
        }

        return value;
    }

    function getHTMLCodeForInternational(str) {
        var value = '';
        if (str == 'Yes') {
            value += '<img href="#" rel="tooltip" data-placement="top" title="International students are admitted" src="images/university/world.png">';
        }
        else if (str == 'No') {
            value += '<img href="#" rel="tooltip" data-placement="top" title="International students are NOT admitted" src="images/university/world_bn.png">';
        }
        return value;
    }

    function makeAdmissionChart() {
        var value = '';
        value += '<p><b>Students selection applied: </b>' + uni.admissionSelection + '</p>';
        value += getHTMLForGender(uni.gender);
        /* value += '<br />'; */
        value += getHTMLCodeForInternational(uni.admissionInternational);
        document.getElementById('admission_gender').innerHTML = value;
        var percentage = parsePercentage(uni.admittedPercentage);
        if (percentage <= 0) {
            document.getElementById('admission_chart_div').innerHTML='Data not available';
        }
        else {
            admission_data = google.visualization.arrayToDataTable([
              ['Admission', 'Percentage'],
              ['Admitted', percentage],
              ['Not admitted', 100 - percentage],
            ]);

        
            admission_options = {
                height: '500',
                //width: getActiveTabWidth(),
                chartArea: { width: '100%' },
                colors: ['2FA4E7', '033C73'],
                title: 'Admitted students percentage',
                backgroundColor: { fill: 'transparent' }
            };

            admission_done = true;
            if (tab_open) {
                charts_show();
            }
        }
    }

    function tabClosed() {
        tab_open = false;
    }

    function tabOpened() {
        tab_open = true;
    }
 
    function makeStudentsTypeChart() {
        var undergraduate = uni.numOfUndergraduate;
        var postgraduate = uni.numOfPostgraduate;

        if (undergraduate <= 0 || postgraduate <= 0) {
            document.getElementById('students_chart_div').innerHTML = 'Data not available';
        }
        else {
            students_data = google.visualization.arrayToDataTable([
              ['Students', 'Total'],
              ['Undergraduated', undergraduate],
              ['Postgraduated', postgraduate],
            ]);

            students_options = {
                height: '500',
                //width: getActiveTabWidth(),
                chartArea: { width: '100%' },
                colors: ['2FA4E7', '033C73'],
                title: 'Number of under/post graduated students',
                backgroundColor: { fill: 'transparent' }
            };
           
            students_done = true;
            if (tab_open) {
                charts_show();
            }
        }
    }

    function charts_show() {
        if (costs_done && !costs_drawn) {
            costs_chart = new google.visualization.ColumnChart(document.getElementById('costs_chart_div'));
            costs_chart.draw(costs_data, costs_options);
        }

        if (students_done && !students_drawn) {
            students_chart = new google.visualization.PieChart(document.getElementById('students_chart_div'));
            students_chart.draw(students_data, students_options);
        }

        if (rank1_done && !rank1_drawn) {
            rank1_chart = new google.visualization.ColumnChart(document.getElementById('relativeranks_chart_div'));
            rank1_chart.draw(rank1_data, rank1_options);
        }

        if (rank2_done && !rank2_drawn) {
            rank2_chart = new google.visualization.ColumnChart(document.getElementById('ranks_chart_div'));
            rank2_chart.draw(rank2_data, rank2_options);
        }

        if (admission_done && !admission_drawn) {
            admission_chart = new google.visualization.PieChart(document.getElementById('admission_chart_div'));
            admission_chart.draw(admission_data, admission_options);
        }
    }

    



    function makingIntroduction() {

        //Description plus wiki link
        $("#description").html(" <h3 id='description-header'>Description</h3>\n");
        if (uni.abstractDescr != null) {
            $("#description").append("<p id='descrption-text'>" + uni.abstractDescr + "</p>");
            //if the sentence is cut in the middle
            // add ...
            if (uni.abstractDescr.charAt(uni.abstractDescr.length - 1) != ".")
                $("#description-text").append("...");
        }
        else
            $("#description").append("<p id='descrption-text' class='lead'>Not Reported</p>");

        if (uni.wikiUrl != null)
            $("#description").append(
                "<a href='" + uni.wikiUrl + "' >Read full description on Wikipedia</a>");


        // Add social media links
        $("#socialmedia").html("<h3 id='socialmedia-header'>Other online resources</h3>\n");
        $("#socialmedia").append("<div id='socialmedia-links'></div>");
        if (uni.facebookUrl != "Not reported") {
            $("#socialmedia-links").append("<a href='" + uni.facebookUrl + "'><img src='images/icons/facebook.png'></img></a>");
        }
        else {
            $("#socialmedia-links").append("<a href=#><img src='images/icons/facebook_bn.png'></img></a>");
        }
        if (uni.linkedinUrl != "Not reported") {
            $("#socialmedia-links").append("<a href='" + uni.linkedinUrl + "'><img src='images/icons/linkedin.png'></img></a>");
        }
        else {
            $("#socialmedia-links").append("<a href=#><img src='images/icons/linkedin_bn.png'></img></a>");
        }
        if (uni.twitterUrl != "Not reported") {
            $("#socialmedia-links").append("<a href='" + uni.twitterUrl + "'><img src='images/icons/twitter.png'></img></a>");
        }
        else {
            $("#socialmedia-links").append("<a href=#><img src='images/icons/twitter_bn.png'></img></a>");
        }
        if (uni.youtubeUrl != "Not reported") {
            $("#socialmedia-links").append("<a href='" + uni.youtubeUrl + "'><img src='images/icons/youtube.png'></img></a>");
        }
        else {
            $("#socialmedia-links").append("<a href=#><img src='images/icons/youtube_bn.png'></img></a>");
        }

        // add contact informations
        $("#contacts").html("<h3>Contacts</h3>\n");
        $("#contacts").append("<p><b>Phone: </b>" + uni.phone + "</p>\n");
        $("#contacts").append("<p><b>Adress: </b>" + uni.address + "</p>\n");
        
        // GOOGLE STATIC MAP
        $("#contacts").append("<div id='contacts-image' class='row'></div>");
        //prepare parameter for google API
        var uni_addr = uni.name.split(" ").join("+");
        $("#contacts-image").append("<div class=''><img src='http://maps.googleapis.com/maps/api/staticmap?zoom=15&size=600x160&markers=icon:images/places/university.png|" + uni_addr + "&sensor=false&style=feature:road|visibility:simplified|color:0xd3d3d6&style=feature:landscape|color:0xf5f5f5&style=feature:poi|element:labels.text.fill|color:0x033c73&style=feature:administrative|element:labels.text.fill|color:0x2fa4e7'></img></div>");
        $("#contacts-image").append("<div class=''><img src='http://maps.googleapis.com/maps/api/staticmap?zoom=11&size=600x160&markers=icon:images/places/university.png|" + uni_addr + "&sensor=false&style=feature:road|visibility:simplified|color:0xd3d3d6&style=feature:landscape|color:0xf5f5f5&style=feature:poi|element:labels.text.fill|color:0x033c73&style=feature:administrative|element:labels.text.fill|color:0x2fa4e7'></img></div>");
    }


/*################# UTILITIES ##################*/
    //Returns an integer representing the percentage; as example (string) 70% -> (int) 70
    function parsePercentage(str) {
        var index = str.indexOf("%");
        if (index == -1) {
            return 0;
        }
        else {
            return parseInt(str.substring(0, index));
        }
    }

    //Parse a cost string of the db: return one integer; 
    //it's the average of the 2 values if the string gives a range, 
    //it's the punctual value if the string says over,
    //it's 0 if the string is "not reported".
    function parseCostString(str) {
        if (str.lastIndexOf("Not ", 0) === 0) { return 0; /* Nothing to do here */ }
        else if (str.lastIndexOf("over", 0) === 0) {
            var index = str.indexOf(" ");
            var index2 = str.indexOf("U");
            var value = str.substring(index + 1, index2).replace(",", "");
            return parseInt(value);
        }
        else {
            var index = str.indexOf("-");
            var index2 = str.indexOf("U");
            var min = str.substring(0, index).replace(",", "");
            var max = str.substring(index + 1, index2).replace(",", "");
            return (parseInt(min) + parseInt(max)) / 2;
        }
    }