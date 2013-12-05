//GLOBAL VARIABLES
var current_question; //Global variable used for storing the question
var current_list; //Global variable used for storing the university list
var question_index = 1; // used to check if it's the first question
var map; // global var to store the map
var result_bool = false; // global var to indicate that result are shown

//HTML Snippets
var back_button_html = "<a id='back' onclick='undoQuestion()' class='btn btn-primary'>Back</a>\n";
var next_button_html = "<a id='next' onclick='executeQuestion()' class='btn btn-primary'>Next</a>\n";
var instruction_content = "The process we use to make suggestions is actually really simple! We match your preferences with almost all the universities in the world, retrieving their up to date information in real time. "
    +"If there are a lot of universities that match your tastes, we sort them by ranking and we show the top 10.";
var data_content_explain = " data-title='Instructions' data-content='"+instruction_content+"'";
var explain_button_html = "<a id='explain'class='btn btn-primary' "+ data_content_explain+">?</a>\n";
var result_description = "According with your answers we selected the following universities for you:";
var finished_question_message = "<b>WARNING: </b>There are a lot of universities that fullfil your preferences.\n"
                                + "We have limited our suggestion list to the 10 top ranked universities." ;
var empty_message = "<b>WARNING: </b>There are no universities that fullfil the preference you expressed!"
                    + " Please try again with different answers";

//Start the suggestion process
google.load('visualization', '1.1', { 'packages': ['geochart'] });
$("#explain_menu").html(explain_button_html);


google.setOnLoadCallback(function() {
    geochart = new google.visualization.GeoChart(document.getElementById('question_map'));
    $(document).ready(nextStep(true));
});
    ;

    //This method update the page retrieving dynamic info from the server
    //it doesn't check for termination conditions
    function nextStep(bool_first) {

        populateHistory(); 
        nextQuestion();
        updateMap();
        display_back_button = true;
        if (bool_first) display_back_button = false; // if you are the first question you can't go back
        displayMenu(display_back_button, true);
    }

    //wrapper method for the general Pagemethod
    //It asks the new question from the server
    function nextQuestion() {

        PageMethod("GetNextQuestion", [], nextQuestionCallback, generalFailCallback, false);    
    }

    //this method is used to insert question html
    function nextQuestionCallback(question_obj) {

        //clear the div and add the question text
        $("#question_current").html("<p><b>Please answer to the following question: </b></p>\n");
        $("#question_current").append("<p class='lead'>"+question_obj.d.QuestionText+"</p>\n");
        //add answers into html
        var answers_html;
        $("#question_current").append("<b>Choose your answer:</b>\n");
        for (var index in question_obj.d.AnswerChoices) {
            answers_html += "<option value='" + index
            + "' >"+ question_obj.d.AnswerChoices[index] + "</option>\n";
        }
        $("#question_current").append("<select id='answer_list'>\n"+answers_html+"</select>");
    }

    function executeQuestion() {

        //retrieve the selected option
        var parameter = ["answer", $('#answer_list option:selected').html()]
        PageMethod("ProvideAnswer", parameter, executeQuestionCallback, generalFailCallback, true);
        $("#question_current").html("<h4>We're currently processing you request. It can take up to one minute!</h4>\n")
        $("#question_current").append("\n<div id='loader_div'> <img id='loader' src='images/ajax-loading-big.gif'></img></div>")
        $("#question_menu").html("");
    }

    function executeQuestionCallback(return_status) {
     
        question_index++;

        // return status is a bool parameter
        // true ==> i can procede with the next question
        if (return_status.d == true) {
            nextStep(false);
        }
        else
            //false: there is some problem and i get the exact status
            PageMethod("GetStatus", [], getStatusCallback, generalFailCallback, false);
    }

    function getStatusCallback(return_status) {

        //good case 
        //display the next questions
        if (return_status.d == 0)
            nextStep(false);
        //empty case 
        // ==> DISPLAY WARNING
        if (return_status.d == 2) {
            displayWarning(empty_message);
            $("#question_current").html("<h4>There are no universities that match your preferences!</h4><h2>Please try again!</h2>");
            result_bool = true;
        }

        //result size is 0 < x < N, termination condition is met
        // ==> DISPLAY SUGGESTIONS
        if (return_status.d == 3) {
            displayResults();
            result_bool = true;
        }

        //finished questions 
        //==> DISPLAY SUGGESTIONS AND WARNING
        if (return_status.d == 4) {     
            displayWarning(finished_question_message)
            displayResults();
            result_bool = true;
        }
        populateHistory();
        updateMap();

    }

    //this method is used to display an error message if something goes wrong
    // error message is passed into "text" parameter
    // call the method with null to remove the box
    function displayWarning(text) {

        if (!text) {
            $("#error").clear();
            $("#error").removeClass("alert alert-warning");
        }
        else {
            $("#error").html(text);
            $("#error").addClass("alert alert-warning");
        }
    }

    //wrapper method for the general Pagemethod
    //it retrieve the current result list and displays it
    function displayResults() {

        PageMethod("getResults", [], displayResultsCallback, generalFailCallback,false);
    }

    //populate the current_list object with the actual list on the server
    //and display it
    function displayResultsCallback(suggestions_list) {

        // set the title text   
        //clear the div and add description
        current_list = suggestions_list.d;

        $("#question_current").html("<h4>" + result_description + "</h4>\n");

        for (var index in current_list) {
            $("#question_current").append(
                "<h5>"+ (parseInt(index)+1) +") <a href='" + current_list[index].Link + "'>" + current_list[index].Name + "</a></h5>\n");
            $("#question_current").append(
                "<h6><a href='city.aspx?name=" + current_list[index].City + "&country=" + current_list[index].Country + "'>" + current_list[index].City + ",</a> "
                + current_list[index].Country + "</h6>\n");    
        }

        displayMenu(false, false);
    }

    //method used to dinamically display buttons into the menu
    //put true to display it!
    function displayMenu(bool_back, bool_next) {

        $("#question_menu").html("");
        // remove all the html from the div and the explain button

        if (bool_back == true)
            $("#question_menu").append(back_button_html);

        if (bool_next == true)
            $("#question_menu").append(next_button_html);
        
    }

    //update suggestion system status Undoing the last question
    //wrapper for page method UndoLastQuestion
    function undoQuestion() {

        PageMethod("UndoLastQuestion",[], undoQuestionCallback, generalFailCallback,false);

    }

    //after updating server status, reload informations
    function undoQuestionCallback() {

        question_index--;
        if (question_index < 2)
            nextStep(true);
        else
            nextStep(false);
    }

    function populateHistory() {
    
        PageMethod("RetrieveHistory",[], populateHistoryCallback, generalFailCallback, false);

    }

    function populateHistoryCallback(history_list) {

        $("#question_history").html("<h3>Question History</h3>");

        if (history_list.d.length > 0) {
            for (var index in history_list.d) {
                var humanreadable_index = 
                $("#question_history").append("<h5>" + (parseInt(index)+1) + ") " + history_list.d[index].QuestionText + "</h5>\n");
                $("#question_history").append("<p><b>Your answer: </b>" + history_list.d[index].UserAnswer + "</p>\n");
            }
        }
        else
            $("#question_history").append("<h4>Nothing to show right now </h4>\n");

    }

    function updateMap() {
    
        if (question_index > 1) {
            PageMethod('GetFullCountryList', [], updateMapCallback, generalFailCallback);
            $('#loading_map').html("Map is loading...<img src='images/ajax-loading-transparent.gif'> </img>");
            }
        else
            updateMapCallback([]);
    }
    // Set data and option then call drawMap
    function updateMapCallback(country_set) {

        var data, options;
        $('#loading_map').html("");
        if (question_index > 1) { // from second question to infinity case

            result_bool = false;
            var formatted_country;
            if (result_bool) {
                // IT WILL NEVER ENTER IN THIS BRANCH WITH THE ACTUAL CODE!!!
                formatted_country = [['Country', 'University#','Universities']];
                for (var index in country_set.d)
                        formatted_country.push([country_set.d[index].Name, country_set.d[index].UniNumber, country_set.d[index].UniNames]);
                
            }
            else {
                formatted_country = [['Country', 'Universities']];
                for (var index in country_set.d)
                    formatted_country.push([country_set.d[index].Name, country_set.d[index].UniNumber]);
            }

            data = google.visualization.arrayToDataTable(formatted_country);
        
       } 
        else { // first question case

            data = google.visualization.arrayToDataTable([['Country','Universities']]); // empty_array
        }

        options = {
            region: 'world',
            resolution: 'countries',
            datalessRegionColor: 'F2F2F2', // gray background
            backgroundColor: 'white',
            displayMode: 'regions',
            colorAxis: { colors: ['2FA4E7', '033C73'] },
            //enableRegionInteractivity: false,
            magnifyingGlass: { enable: true, zoomFactor: 5 },
        };

        geochart.draw(data, options);
    }

    // server error handling
    function generalFailCallback() {
        //#TODO
    }

