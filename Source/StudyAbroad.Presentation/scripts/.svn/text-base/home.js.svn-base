var imageSearch = new Array();

google.load('search', '1');


function getRecom() {

    method = "GetRecommendedUnis";
    //workaround for asp bug
    if (window.location.pathname == "/")
        method = window.location.host + "/default.aspx/" + method;

    PageMethod(method, "", getRecomCallback, generalFail, true);
    $('#recom').html('<p class="muted">Recommendation system is loading... <img src="images/ajax-loading-transparent.gif"></img></p>');
}

function getRecomCallback(result) {
    
    var uni_list = result.d;
    var first_column = "";
    var second_column = "";
    var third_column = "";
    var uni_html;
    var modal_html = '';
    var img;
    
    for (var i=0; i < 10; i++) {

        img = uni_list[i].imageURL;
        // if we don't have the image get it from google
        if (img == 'No image' | img == null) {
            img = '';
            imageSearch[i] = new google.search.ImageSearch();
            imageSearch[i].setResultSetSize(1);
            imageSearch[i].setSearchCompleteCallback(this, searchComplete, [i]);
            imageSearch[i].execute(uni_list[i].name + ' logo');
        }

        uni_html = '<div class="row" id="rec_row">';
        uni_html += '<a href="' + uni_list[i].link + '"><img class="image" src="' + img + '" id="m_logo' + i + '"/></a><br/>';
        uni_html += '<b><a href="' + uni_list[i].link + '">' + uni_list[i].name + '</a><br/>';
        uni_html += ''+uni_list[i].city + ', ' + uni_list[i].country + '</b><br />';
        uni_html += '</div>';

        modal_html += '<div class="row" id="modal_row">';
        modal_html += '<div class="span2"><a href="' + uni_list[i].link + '"><img class="image" src="' + img + '" id="logo' + i + '"/></a></div>';
        modal_html += '<div class="span3"><b><a href="' + uni_list[i].link + '">' + uni_list[i].name + '</a><br/>';
        modal_html += '<small>' + uni_list[i].abstractDescr + '</small></div></div>';

        //put them in the main page
        if (i < 1)
            first_column += uni_html;
        else if (i < 2)
            second_column += uni_html;
        else if (i <3)
            third_column += uni_html;
    }

    
    $('#recom').html('<h2>Universities you may like...</h2>'
        + ' <div class="span4 nomargin">' + first_column + '</div><div class="span4 nomargin">' + second_column + '</div><div class="span4 nomargin">' + third_column + '</div>');
    $('#recom').append('<br/><div><a class="btn btn-small btn-primary" id="more_link" href="#reccModal" data-toggle="modal"><b>See more suggestions!</b></a></div>');
    
    $('#recom_addcontent').html(modal_html);
}


function searchComplete(param) {
    if (imageSearch[param].results && imageSearch[param].results.length > 0) {
        var img = new Image();
        img.onload = function () {
            if ($("#m_logo" + param).length > 0)
                $("#m_logo" + param).attr('src', imageSearch[param].results[0].url);

            $("#logo" + param).attr('src', imageSearch[param].results[0].url);
        }
        img.onerror = function () {
            if ($("#m_logo" + param).length > 0)
                $("#m_logo" + param).attr('src', imageSearch[param].results[0].tbUrl);
            $("#logo" + param).attr('src', imageSearch[param].results[0].tbUrl);
        }
        img.src = imageSearch[param].results[0].url;
    }
    else {
        if ($("#m_logo" + param).length > 0)
            $("#m_logo" + param).attr('src', '/images/no_image.png');
        $("#logo" + param).attr('src', '/images/no_image.png');
    }

   
}

//TODO
function generalFail() {
}

function showModal() {
}

function hideModal() {
    $("#reccModal").modal("hide");
}
