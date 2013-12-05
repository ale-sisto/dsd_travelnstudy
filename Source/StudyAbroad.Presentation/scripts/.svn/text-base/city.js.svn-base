var city;
var city_name, country_name;
var climate_data, climate_options, climate_done = false, climate_drawn = false, climate_open = false;
var timeout;

$(window).load(function () {
    timeout = setTimeout(function () { $('#loaderModal').modal('show'); }, 250);
});

google.load("visualization", "1", { packages: ["corechart"] });
$(document).ready(function () {
    city_name = getUrlParameter("name");
    country_name = getUrlParameter("country");
    if (city_name && country_name) {
        var par = ["cityName", city_name, "countryName", country_name];
        PageMethod("GetUniversities", par, successGetUniversities, generalFail, true);
        PageMethod("GetCityData", par, successPopulateCallback, generalFail, true);
    }
    
});


//general fail callback handler
//we use this method to handle server errors
function generalFail() {
    //#TODO       
}


function successPopulateCallback(res) {
    clearTimeout(timeout);
    $("#content_page_header").css("display", "block");
    $("#cityContainer").css("display", "table");

    city = res.d;
    makeHeader();
    
    setAddressForPlaces(city_name, city.countryISOCode);
    var par = ["cityName", city_name, "countryName", country_name];
    
    PageMethod("GetCostOfLife", par, successGetCostsCallback, generalFail, true);
    PageMethod("GetClimate", par, successClimateCallback, generalFail, true);
    makeReviewSection();
    $('#loaderModal').modal('hide');
}


function successGetUniversities(res) {
    var value = '';
    for (var i = 0; i < res.d.length; i++) {
        value += '<li><a href="' + res.d[i].link + '"><h5>' + res.d[i].name + '</h5></a></li>';
    }
    $("#universitiesList").html('<h3>Universities List:</h3><p>Go to the university page and find all the information you need to make your choice!</p><ul id="uni_list" class="unstyled well"></ul>');
    $("#uni_list").html(value);
}

function makeHeader() {
   
    //title
    $("#tit").html(city.name);
    $("#sub").html(city.country);

    $("#mapBread").html(
      '<li><a href="/explore.aspx?iso=' + city.continentISOCode + '">' + city.continent + '</a><span class="divider">/</span></li>' +
      '<li><a href="/explore.aspx?iso=' + city.regionISOCode + '">' + city.region + '</a><span class="divider">/</span></li>' +
      '<li><a href="/explore.aspx?iso=' + city.countryISOCode + '">' + city.country + '</a><span class="divider">/</span></li>' +
      '<li class="active">' + city.name + '</li>'
      );


    //tab 0
    var code = city.countryISOCode;
    if (code.startsWith('us')) {
        code = 'us';
        $("#sub").append(', United States');
        $("#country").html('<p class="lead"><b>Country: </b>' + city.country + ', United States' +
        ' <img id="flag" /></p>');
    }
    else {
        $("#country").html('<p class="lead"><b>Country: </b>' + city.country +
        ' <img id="flag" /></p>');
    }
    $("#map1").html('<img src="http://maps.googleapis.com/maps/api/staticmap?zoom=4&size=640x250&markers=' + city.name + ',' + city.country + '&sensor=false&style=feature:road|visibility:simplified|color:0xe6f3ff&style=feature:water|lightness:63|color:0xffffff&style=feature:landscape|color:0x2FA4E7"></img>');
    
    $("#flag").attr('src', 'http://www.geonames.org/flags/x/' + code + '.gif');

    $("#population").html('<p class="lead"><b>Population: </b>' + city.populationCount + '</p>');
    
    var area = city.surfaceArea;
    area = area.replace(",", ".");
    if (area.indexOf(".") !== -1)
        area = area.substring(0, area.indexOf('.'));
    
    if (area.length > 0 && !isNaN(area)) {
        $("#area").html('<p class="lead"><b>Area: </b>' + area + ' Km<sup>2</sup></p>');
    }
    else {
        $("#area").html('<p class="lead"><b>Area: </b> Not reported');
    }

    $("#density").html();
 

    // General Page
    $("#abstract").html(city.abstractDescr);
    if (city.wikiUrl != null) {
        $("#wiki").html(
            '<a href="' + city.WikiUrl + '">Read the full description on Wikipedia</a>');
    }

    $("#panoramio").html('<h3> Photos from the city</h3>' +
        '<iframe id="iframe1" class="margin-top" frameborder="0" width="550" height="400" scrolling="no" marginwidth="50" marginheight="200">' +
        '</iframe>');
    var f = document.getElementById('iframe1');
    f.src = 'http://www.panoramio.com/wapi/template/photo_list.html?tag=' + city.name + '&amp;width=550&amp;height=400&amp;list_size=8&amp;position=right&amp;bgcolor=%2FFFFFF';
}



//Build the climate chart
function successClimateCallback(res) {
    document.getElementById('climate_classification').innerHTML = '<b>Climate classification: ' + res.d.classification + '</b>';
    climate_data = new google.visualization.DataTable();
    climate_data.addColumn("string", "Month");
    climate_data.addColumn("number", "Min temp");
    climate_data.addColumn("number", "Max temp");
    climate_data.addColumn("number", "Rainfall");
    var i = 0;
    for (i = 0; i < res.d.climate.length; i++) {
        climate_data.addRow([res.d.climate[i].Month, res.d.climate[i].AvgMinTemp, res.d.climate[i].AvgMaxTemp, res.d.climate[i].AvgRainfall]);
    }

    climate_options = {
        height: '350',
        //width: 0.9 * getActiveTabWidth(),
        chartArea: { left:50, width: '85%'},
        legend: { position: 'bottom', textStyle: { color: 'black', fontSize: 17 } },
        //colors: ['4D89F9'],
        title: 'Minimum and maximum temperatures (°C) - Average rainfall (mm)',
        hAxis: { title: 'Month', titleTextStyle: { color: 'black' } },
        backgroundColor: { fill: 'transparent' },
        seriesType: "bars",
        series: [
                { targetAxisIndex: 0 },
                { targetAxisIndex: 0 },
                { targetAxisIndex: 1, type: "line" },
                ],
        vAxes: [
            {}, // Left axis
            {} // Right axis
        ]
    };
    climate_done = true;
    if (climate_open) climate_draw();
}

function climateClosed() {
    climate_open = false;
}

function climateOpened() {
    climate_open = true;
}

function weather_draw() {
    var geocoder = new google.maps.Geocoder();
    var latlng;
    if (city.latitude != null && city.longitude != null) {
        latlng = new google.maps.LatLng(city.latitude.replace(',', '.'), city.longitude.replace(',', '.'));
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[0]) {
                    //alert(results[0].formatted_address);
                    var country = '';
                    var city = '';
                    //alert(JSON.stringify(results, null, 4));

                    for (var i = 0; i < results[0].address_components.length; i++) {
                        //alert(JSON.stringify(results[0].address_components, null, 4));
                        for (var j = 0; j < results[0].address_components[i].types.length; j++) {
                            if (results[0].address_components[i].types[j] == 'country') {
                                country = results[0].address_components[i].long_name;
                            }
                            else if (results[0].address_components[i].types[j] == 'locality') {
                                city = results[0].address_components[i].long_name;
                            }
                            //alert(results[0].formatted_address);

                        }
                    }

                } else {
                    alert("Geocoder failed due to: " + status);
                }
            }
            //alert(city); alert(country);
            weather_draw_callback(city, country);
        }
        );
    }
    else {
        weather_draw_callback(city.name, city.country);
    }
}

function weather_draw_callback(cty, ctr) {
    $.simpleWeather({
        location: cty +', ' + ctr,
        unit: 'c',
        success: function (weather) {
            html = '<p class="lead"><b>Location: </b>' + weather.city + ', ' + weather.region + ' ' + weather.country + '</p>';
            html2 = '<img class="img-rounded" src="' + weather.image + '">';
            html += '<p ><strong>Today\'s High</strong>: ' + weather.high + '&deg; ' + weather.units.temp + ' - <strong>Today\'s Low</strong>: ' + weather.low + '&deg; ' + weather.units.temp + '</p>';
            html += '<p ><strong>Current Temp</strong>: ' + weather.temp + '&deg; ' + weather.units.temp + ' (' + weather.tempAlt + '&deg; F)</p>';
            html += '<p ><strong>Wind</strong>: ' + weather.wind.direction + ' ' + weather.wind.speed + ' ' + weather.units.speed + ' <strong>Wind Chill</strong>: ' + weather.wind.chill + '</p>';
            html += '<p ><strong>Currently</strong>: ' + weather.currently + ' - <strong>Forecast</strong>: ' + weather.forecast + '</p>';
            html += '<p ><strong>Humidity</strong>: ' + weather.humidity + ' <strong>Pressure</strong>: ' + weather.pressure + ' <strong>Rising</strong>: ' + weather.rising + ' <strong>Visibility</strong>: ' + weather.visibility + '</p>';
            html += '<p ><strong>Heat Index</strong>: ' + weather.heatindex + '</p>';
            html += '<p ><strong>Sunrise</strong>: ' + weather.sunrise + ' - <strong>Sunset</strong>: ' + weather.sunset + '</p>';
            html += '<p ><br /><strong>Tomorrow\'s High/Low</strong>: ' + weather.tomorrow.high + '/' + weather.tomorrow.low + '<br /><strong>Tomorrow\'s Forecast</strong>: ' + weather.tomorrow.forecast + '</p>';
            //html += '<p><strong>Last updated</strong>: ' + weather.updated + '</p>';
            //html += '<p><a href="' + weather.link + '">View forecast at Yahoo! Weather</a></p>';

            $("#weather").html(html);
            $("#weather_img").html(html2);
        },
        error: function (error) {
            $("#weather").html('<p>' + error + '</p>');
        }
    });
}

function climate_draw() {
    if (climate_done && !climate_drawn) {
        var chart = new google.visualization.ComboChart(document.getElementById('climate_chart'));
        chart.draw(climate_data, climate_options);
        climate_drawn = true;

        //Weather!!!
        weather_draw();
        
    }
}

//Build the table with the costs of items
function successGetCostsCallback(res) {
    var value;
    value = '<tr><th>Item name</th><th>Average price</th><th>Minimum price</th><th>Maximum price</th></tr>';
    //alert(res.d[0].ItemName);
    var i = 0;
    for (i = 0; i < res.d.length; i++) {
        value += '<tr>';
        value += '<td>' + res.d[i].ItemName + '</td>' + '<td>' + res.d[i].AvgPrice.toFixed(2) + '</td>' + '<td>' + res.d[i].MinPrice.toFixed(2) + '</td>' + '<td>' + res.d[i].MaxPrice.toFixed(2) + '</td>';
        value += '</tr>'
    }
    $('#costs_table').html(value);
}
