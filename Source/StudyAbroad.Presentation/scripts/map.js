google.load('visualization', '1.1', {'packages': ['geochart']});
google.setOnLoadCallback(init);
var geocoder;
var map, options;
//Google Datatables
var dummy_world_data, dummy_country_data, cities_data, region_data, cityInfos, universities;
var lastcontinent, lastsubcontinent, lastcountry, lastusprovince;
var ajax_request_city, ajax_request_univ, ajax_request_topbyregion, ajax_request_unicount, ajax_request_restore;

function PageMethodL(request, g, b, d, f, handle) {

    /*Request states the kind of the request, consecutive requests must have different types: 
    C: city
    U: university
    L: location
    T: topbyregion
    N: uni count
    R: restore
    */
    var e = window.location.pathname, a = "";
    if (b.length > 0)
        for (var c = 0; c < b.length; c += 2) {
            if (a.length > 0) a += ","; a += '"' + b[c] + '":"' + b[c + 1] + '"'
        }
    a = "{" + a + "}";
    if (request == 'C') {
        ajax_request_city = $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else if (request == 'U') {
        ajax_request_univ = $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else if (request == 'L') {
        $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else if (request == 'T') {
        ajax_request_topbyregion = $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else if (request == 'N') {
        ajax_request_unicount = $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else if (request == 'R') {
        ajax_request_restore = $.ajax({
            type: "POST",
            url: e + "/" + g,
            contentType: "application/json; charset=utf-8",
            data: a,
            dataType: "json",
            success: d,
            error: f
        })
    }
    else {
        alert('Javascript error on the PageMethodL invocation... check your code!');
    }
}

function abortAjaxCalls()
{
    if (ajax_request_univ != null) ajax_request_univ.abort();
    if (ajax_request_city != null) ajax_request_city.abort();
    if (ajax_request_topbyregion != null) ajax_request_topbyregion.abort();
    if (ajax_request_unicount != null) ajax_request_unicount.abort();
}

function init()
{
  geocoder = new google.maps.Geocoder();
  map = new google.visualization.GeoChart(document.getElementById('map_div'));
  google.visualization.events.addListener(map,'regionClick', regionClick);
  //google.visualization.events.addListener(map,'ready', unsetMapLoading);
  google.visualization.events.addListener(map, 'select', markerClick);

  cities_data = new google.visualization.DataTable();

  cities_data.addColumn('number', 'latitude');
  cities_data.addColumn('number', 'longitude');
  cities_data.addColumn('string', 'name');
  cities_data.addColumn('number', 'Universities');

  cityInfos = new google.visualization.DataTable();
  cityInfos.addColumn('string', 'abstractDescr');
  cityInfos.addColumn('string', 'link');

  dummy_world_data = new google.visualization.DataTable();
  dummy_world_data.addColumn('string', 'Continent'); // Implicit domain label col.
  dummy_world_data.addColumn('number', 'Value'); // Implicit series 1 data col.
  //data.addColumn({type:'string', role:'tooltip'}); 

  

  dummy_country_data = new google.visualization.DataTable();
  dummy_country_data.addColumn('string', 'Country'); // Implicit domain label col.

  $("#universities_list").accordion(
      {
          event: 'mouseover',
          active: '.selected',
          selectedClass: 'active',
          animated: "bounceslide",
          heightStyle: "content",
          //change : yourFunction,
      });
  var iso = getUrlParameter('iso');
  if (iso == null) {
      showWorld();
  }
  else {
      //showWorld();
      //Init options
      setOptions('regions', 'continents', 'world', true);
      var parameters = ['isoRegionCode', iso];
      PageMethodL("R", "RestoreSession", parameters, restoreSession, failedAjaxRestoreFn);
  }
}

function restoreSession(res) {
    var iso = res.d[0];
    switch (res.d.length) {
        case 7:
            //us state
            document.getElementById("nav_country_link").innerHTML = res.d[1];
            lastcountry = res.d[2];
            document.getElementById("nav_subcontinent_link").innerHTML = res.d[3];
            lastsubcontinent = res.d[4];
            document.getElementById("nav_continent_link").innerHTML = res.d[5];
            lastcontinent = res.d[6];
            showUSProvince(iso);
            break;
        case 5:
            document.getElementById("nav_subcontinent_link").innerHTML = res.d[1];
            lastsubcontinent = res.d[2];
            document.getElementById("nav_continent_link").innerHTML = res.d[3];
            lastcontinent = res.d[4];
            showCountry(iso);
            break;
        case 3:
            document.getElementById("nav_continent_link").innerHTML = res.d[1];
            lastcontinent = res.d[2];
            showSubcontinent(iso);
            break;
        case 1:
            showContinent(iso);
            break;
    }
}

function setMapLoading() 
{
    //Code that alerts the user that the map is being loaded
    document.getElementById("map_loading").style.display = "inline";
}

function unsetMapLoading() 
{
    //Code that alerts the user that the map has loaded
    document.getElementById("map_loading").style.display = "none";
}

function setAjaxLoading()
{
    //Shows something to notify the user that the ajax call is in progress
    var value;
    value = '<h3>' + '<img id="ajax_loading" src="images/ajax_loader_blue.gif"/>Loading...' + '</h3><div>';
    value += '<p>' + 'Data is being fetched, please wait...' + '</p>';
    value += '</div>';
    
    var active = $('#universities_list').accordion('option', 'active');
    $('#universities_list').append(value)
      .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide"  });
}

function unsetAjaxLoading()
{
    //Alertrs that the ajax call is complete
    document.getElementById("universities_list").innerHTML = "";
}

function updateContinentName(result) {
    document.getElementById("nav_continent_link").innerHTML = result.d;
}

function updateSubcontinentName(result) {
    document.getElementById("nav_subcontinent_link").innerHTML = result.d;
}

function updateCountryName(result) {
    document.getElementById("nav_country_link").innerHTML = result.d;
}

function updateUSProvinceName(result) {
    document.getElementById("nav_province").innerHTML = result.d;
}

function updateNav(level)
{
    //clears eventual error notifications
    document.getElementById('map_error').style.display = 'none';
  if (level == 'world')
    {
      //Visibility properties
      document.getElementById('nav_world').style.display = 'inline';
      document.getElementById('nav_continent').style.display = 'none';
      document.getElementById('nav_subcontinent').style.display = 'none';
      document.getElementById('nav_country').style.display = 'none';
      document.getElementById('nav_province').style.display = 'none';
      
      document.getElementById('nav_world_link').removeAttribute('href');
    }
   else if (level == 'continent')
    {
      //Visibility properties
      document.getElementById('nav_world').style.display = 'inline';
      document.getElementById('nav_continent').style.display = 'inline';
      document.getElementById('nav_subcontinent').style.display = 'none';
      document.getElementById('nav_country').style.display = 'none';
      document.getElementById('nav_province').style.display = 'none';
      
      document.getElementById('nav_world_link').href = 'javascript:showWorld()';
      document.getElementById('nav_continent_link').removeAttribute('href');

      var parameters = ["isoLocationID", lastcontinent];
      //alert(lastcontinent);
      PageMethodL("L", "GetLocationNameByIsoCode", parameters, updateContinentName, failedAjaxLocationFn);
    }
  else if (level == 'subcontinent')
    {
      //Visibility properties
      document.getElementById('nav_world').style.display = 'inline';
      document.getElementById('nav_continent').style.display = 'inline';
      document.getElementById('nav_subcontinent').style.display = 'inline';
      document.getElementById('nav_country').style.display = 'none';
      document.getElementById('nav_province').style.display = 'none';
      
      document.getElementById('nav_world_link').href = 'javascript:showWorld()';
      document.getElementById('nav_continent_link').href = 'javascript:showLastContinent()';
      document.getElementById('nav_subcontinent_link').removeAttribute('href');

      var parameters = ["isoLocationID", lastsubcontinent];
      PageMethodL("L", "GetLocationNameByIsoCode", parameters, updateSubcontinentName, failedAjaxLocationFn);
    }
  else if (level == 'country')
    {
      //Visibility properties
      document.getElementById('nav_world').style.display = 'inline';
      document.getElementById('nav_continent').style.display = 'inline';
      document.getElementById('nav_subcontinent').style.display = 'inline';
      document.getElementById('nav_country').style.display = 'inline';
      document.getElementById('nav_province').style.display = 'none';
      
      document.getElementById('nav_world_link').href = 'javascript:showWorld()';
      document.getElementById('nav_continent_link').href = 'javascript:showLastContinent()';
      document.getElementById('nav_subcontinent_link').href = 'javascript:showLastSubcontinent()';
      document.getElementById('nav_country_link').removeAttribute('href');

      var parameters = ["isoLocationID", lastcountry];
      PageMethodL("L", "GetLocationNameByIsoCode", parameters, updateCountryName, failedAjaxLocationFn);
    }
  else if (level == 'province')
    {
      //Visibility properties
      document.getElementById('nav_world').style.display = 'inline';
      document.getElementById('nav_continent').style.display = 'inline';
      document.getElementById('nav_subcontinent').style.display = 'inline';
      document.getElementById('nav_country').style.display = 'inline';
      document.getElementById('nav_province').style.display = 'inline';
      
      document.getElementById('nav_world_link').href = 'javascript:showWorld()';
      document.getElementById('nav_continent_link').href = 'javascript:showLastContinent()';
      document.getElementById('nav_subcontinent_link').href = 'javascript:showLastSubcontinent()';
      document.getElementById('nav_country_link').href = 'javascript:showLastCountry()';

      var parameters = ["isoLocationID", lastusprovince];
      PageMethodL("L", "GetLocationNameByIsoCode", parameters, updateUSProvinceName, failedAjaxLocationFn);
    }
}

function showUniCount(isoCode) {
    var parameters = ['isoRegionCode', isoCode];
    PageMethodL('N', "GetUniCount", parameters, uniCountCallback, failedAjaxUniCountFn);
}

function uniCountCallback(res) {
    
    //alert(JSON.stringify(res.d));
    region_data = new google.visualization.DataTable();
    region_data.addColumn('string', 'Region'); // Implicit domain label col.
    region_data.addColumn('number', 'Universities'); // Implicit series 1 data col.
    //data.addColumn({type:'string', role:'tooltip'}); 

    for (var i in res.d) {
        //unicount_data.addRow([i, res.d[i]]);
        var t = i.split(',');
        region_data.addRow([{ v: t[0], f: t[1] }, res.d[i]]);
    }
    drawMap('unicount');
}

function showWorld()
{
  abortAjaxCalls();
  resetInfo();
  showUniCount('world');
  retrieveUnivByRegion('world');
  updateNav('world');
  setOptions('regions', 'continents', 'world', true);
  drawMap('dummy');
}

function showLastContinent()
{
    showContinent(lastcontinent);
}

function showContinent(continentID)
{
    abortAjaxCalls();
    resetInfo();
    showUniCount(continentID);
    retrieveUnivByRegion(continentID);
    lastcontinent = continentID;
    updateNav('continent');
    setOptions('regions', 'subcontinents', continentID, true);
    drawMap('dummy');
}

function showLastSubcontinent()
{
    showSubcontinent(lastsubcontinent);
}

function showSubcontinent(subcontinentID) {
    abortAjaxCalls();
    resetInfo();
    showUniCount(subcontinentID);
    retrieveUnivByRegion(subcontinentID);
    lastsubcontinent = subcontinentID;
    updateNav('subcontinent');
    setOptions('regions', 'countries', subcontinentID);
    drawMap('dummy');
}

function showLastCountry()
{
    //Should be used only for US, anyway a control can't hurt
    if (lastcountry == 'US') showCountry(lastcountry);
}

function showCountry(countryID)
{
    abortAjaxCalls();
    resetMarkers();
    resetInfo();
    lastcountry = countryID;
    updateNav('country');
    if (countryID == 'US')
    {
        showUniCount(countryID);
        var value;
        value = '<h3>' + 'Please select a state' + '</h3><div>';
        value += '<p>' + 'Click on one of the US states to continue' + '</p>';
        value += '</div>';
        //document.getElementById('universities_list').innerHTML += value; 

        var active = $('#universities_list').accordion('option', 'active');
        $('#universities_list').append(value)
          .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide", heightStyle: "content" });

        setOptions('regions', 'provinces', countryID, true);
    }
    else
    {
        lastusprovince = countryID;
        retrieveUnivByRegion(countryID);
        setOptions('markers', 'countries', countryID, false);
        showCities(countryID);
    }
    drawMap('dummy_country');
}

function showUSProvince(provinceID)
{
    abortAjaxCalls();
    resetMarkers();
    resetInfo();
    lastusprovince = provinceID;
    retrieveUnivByRegion(provinceID);
    updateNav('province');
    setOptions('markers', 'provinces', provinceID, false);
    showCities(provinceID);
    drawMap('dummy_country');
}

function userAborted(xhr) {
    return !xhr.getAllResponseHeaders();
}


function failedAjaxRestoreFn(result) {
    if (!userAborted(ajax_request_restore)) {
        //alert('ajax failed to retrieve the list of universitis: ' + result.responseText);
    }
}

function failedAjaxUniversitiesFn(result)
{
    //Fired if the getuniversitiesby... ajax call fails
    unsetAjaxLoading();
    resetInfo();
    if (!userAborted(ajax_request_univ)) {
        //alert('ajax failed to retrieve the list of universitis: ' + result.responseText);
        var value;
        value = '<h3>' + '<img id="ajax_loading" src="images/icon_alert_error.gif"/>Error listing universities' + '</h3><div>';
        value += '<p>' + 'There was an error with the universities; please try again later' + '</p>';
        value += '<p><b>Error description: </b>' + result.responseText + '</p>';
        value += '</div>';

        var active = $('#universities_list').accordion('option', 'active');
        $('#universities_list').append(value)
          .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide", heightStyle: "content" });
    }
}

function failedAjaxUniCountFn(result) {
    //Fired if the getuniversitiesby... ajax call fails
    if (!userAborted(ajax_request_unicount)) {
        //alert('ajax failed to retrieve the list of universitis: ' + result.responseText);
    }
}

function failedAjaxUniversitiesByRegionFn(result) {
    //Fired if the getuniversitiesby... ajax call fails
    unsetAjaxLoading();
    resetInfo();
    if (!userAborted(ajax_request_topbyregion)) {
        //alert('ajax failed to retrieve the list of universitis: ' + result.responseText);
        var value;
        value = '<h3>' + '<img id="ajax_loading" src="images/icon_alert_error.gif"/>Error listing universities' + '</h3><div>';
        value += '<p>' + 'There was an error with the universities; please try again later' + '</p>';
        value += '<p><b>Error description: </b>' + result.responseText + '</p>';
        value += '</div>';
        var active = $('#universities_list').accordion('option', 'active');
        $('#universities_list').append(value)
          .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide", heightStyle: "content" });
    }
}

function failedAjaxCitiesFn(result) {
    //Fired if the getcitiesbycountry ajax call fails
    unsetMapLoading();
    resetInfo();
    resetMarkers();
    if (!userAborted(ajax_request_city)) {
        //If we are here it's a real error; notify the user
        //alert('ajax failed to retrieve the list of cities: ' + result.responseText);
        document.getElementById('map_error').innerHTML = '<img src="images/icon_alert_error.gif"/>Error loading cities list';
        document.getElementById('map_error').style.display = 'inline';
    }
}

function failedAjaxLocationFn(result) {
    //Fired if the getlocationbyid ajax call fails
    //Here we can simply ignore the error; the only consequence will be a generic name like 'country' will be displayed instead of something like 'Italy' in the navigation bar

    //unsetAjaxLoading();
    //alert('ajax failed to convert the iso code to a name: ' + result.responseText);
}

function showCities(countryID)
{
    //Sets the markers on the map when a specific country or US province is selected and populates cityInfos
    //alert('showci ' + countryID);
    var parameters = ["isoCountryID", countryID, "limit", 20];
    setMapLoading();
  PageMethodL('C', "GetCitiesByCountry", parameters, setMarkers, failedAjaxCitiesFn);
}

function showCity(cityIndex)
{
    //Populates the city info div with the name, abstract... and the universities list
    resetInfo();
    //name is the third column
    var city_name = cities_data.getValue(cityIndex, 2);
    document.getElementById('city_name').innerHTML = city_name;
    document.getElementById('city_abstract').innerHTML = cityInfos.getValue(cityIndex, 0);
    document.getElementById('city_link').innerHTML = 'More details...';
    document.getElementById('city_link').setAttribute('href', cityInfos.getValue(cityIndex, 1));
    retrieveUnivByCity(city_name);
}

function resetMarkers()
{
    if (cityInfos != null && cityInfos.getNumberOfRows() > 0) cityInfos.removeRows(0, cityInfos.getNumberOfRows());
    if (cities_data != null && cities_data.getNumberOfRows() > 0) cities_data.removeRows(0, cities_data.getNumberOfRows());
    if (region_data != null && region_data.getNumberOfRows() > 0) region_data.removeRows(0, region_data.getNumberOfRows());
}

function resetInfo()
{
    //Clears all the divs below the map with info about cities and universities
  document.getElementById('city_name').innerHTML = '';
  document.getElementById('city_abstract').innerHTML = '';
  document.getElementById('city_link').innerHTML = '';
  document.getElementById('universities_list').innerHTML = '';
  if (universities != null && universities.getNumberOfRows() > 0) universities.removeRows(0, universities.getNumberOfRows());
}

function retrieveUnivByRegion(regionCode)
{
    setAjaxLoading();
  universities = new google.visualization.DataTable();
  universities.addColumn("string", "name");
  universities.addColumn("string", "abstract");
  universities.addColumn("string", "link");
  universities.addColumn("number", "rank");
  var parameters = ["isoRegionID", regionCode, "limit", 5];
  //alert('Top: ' + regionCode);
    // call WebMethod by providing its name, the parameters variable and callbacks for successfull and failure calls
  PageMethodL("T", 'GetTopUniversitiesByRegion', parameters, succeededAjaxGetUniversities, failedAjaxUniversitiesByRegionFn);
}

function succeededAjaxGetUniversities(result)
{
    unsetAjaxLoading();
    $.each(result.d, function () {
        universities.addRow([this.name, this.abstractDescr, this.link, this.rankingPosition]);
    });
    if (universities.getNumberOfRows() > 0) {
        showUniversities();
    }
    else {
        var value;
        value = '<h3>' + '<img id="ajax_loading" src="images/icon_alert_error.gif"/>No universities' + '</h3><div>';
        value += '<p>' + 'There are no universities in the selected region!' + '</p>';
        value += '</div>';

        var active = $('#universities_list').accordion('option', 'active');
        $('#universities_list').append(value)
          .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide", heightStyle: "content" });
    }
}

function retrieveUnivByCity(city)
{
  universities = new google.visualization.DataTable();
  universities.addColumn("string", "name");
  universities.addColumn("string", "abstract");
  universities.addColumn("string", "link");
  universities.addColumn("number", "rank");
  var parameters = ["cityName", city, "limit", 5];
    // call WebMethod by providing its name, the parameters variable and callbacks for successfull and failure calls
  setAjaxLoading();
  PageMethodL('U', "GetUniversitiesByCity", parameters, succeededAjaxGetUniversities, failedAjaxUniversitiesFn);
}

function addUnivToList(name, abstract, link, rank)
{
  var value;
  value = '<h3>' + name + '</h3><div>';
  value += '<p>' + abstract + '</p>';
  value += '<p><b>Rank: </b>' + rank + '</p>'; 
  value += '<a href="' + link + '">More details...</a>';
  value += '</div>';
    //document.getElementById('universities_list').innerHTML += value; 

  var active = $('#universities_list').accordion('option', 'active');
    $('#universities_list').append(value)
      .accordion('destroy').accordion({ active: active, event: 'mouseover', animated: "bounceslide", heightStyle: "content" });
}

function showUniversities()
{
  //Populates the list with the names of the universities and other nice infos...
  var i;
  for (i=0; i < universities.getNumberOfRows(); i++)
  {
    addUnivToList(universities.getValue(i, 0), universities.getValue(i, 1), universities.getValue(i, 2), universities.getValue(i, 3));
  }
}

function regionClick(eventData)
{
    //alert('regionclicked');
    //abortAjaxCalls();

  var reg = eventData.region;
  
  if (isNaN(reg))
    {
     if (reg.substring(0, 3)=='US-' && reg.length==5)
	{
	  //This is a US province
          showUSProvince(reg);
	}
      else 
     {
         //This is a country
          showCountry(reg);
	}
   }
  else
    {
      //Continent or subcontinent
      if (reg=='002' || reg=='150' || reg=='019' || reg=='142' || reg=='009') 
	{
	  //Continent
          showContinent(reg);
	}
      else
	{
	  //Subcontinent
          showSubcontinent(reg);
	}
    }    
}

function markerClick(eventData)
{
  //Here we must populate the city_name and city_description fields
  //And populate the accordion
    var selection = map.getSelection();
    //Selection has always 1 element
    if (selection.length > 0) {
        //The user clicked a city marker
        //Stop the method to retrieve universities, wether it's from gettopbyregion or getbycity
        if (ajax_request_univ != null) ajax_request_univ.abort();
        resetInfo();
        var item = selection[0];
        showCity(item.row);
    }
    else {
        //The user clicked a region with some data, the event should be handled by the regionclick event
        //alert('region with data click');
        //if (ajax_request_univ != null) ajax_request_univ.abort();
        //if (ajax_request_city != null) ajax_request_city.abort();
    }
}

function geocode_helper(i, a, b, c, d) {
    //need to set timeout to avoid to hit the google's querylimit, with as few as 10 requests in a loop... why, google?
    setTimeout(function () {
        geocoder.geocode({ 'address': a, 'region': lastcountry }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                cities_data.addRow([results[0].geometry.location.lat(), results[0].geometry.location.lng(), a, b]);
                cityInfos.addRow([c, d]);
                drawMap('city');
            }
            else {
                //Ok, if we're here it probably means that google couldn't geocode the given name... what to do?
                //ATM just put the error under the carpet, some cities won't be displayed (as example in South Africa)
                //alert('There was a problem geocoding ' + a + '; status: ' + status);
            }
        });
    }, 200 * i);
};

function setMarkers(result) 
{
    var citynum=0;
    unsetMapLoading();
    //clear the datatable
    cities_data.removeRows(0, cities_data.getNumberOfRows());

    $.each(result.d, function () {
        citynum++;
      var lat = this.latitude;
      var long = this.longitude;
      if (lat != null) lat = lat.replace(',', '.');
      if (long != null) long = long.replace(',', '.');
      if (lat == null || long == null || isNaN(lat) || isNaN(long)) {
          //http://stackoverflow.com/questions/3978806/attaching-parameters-with-javascript-closures-to-default-parameters-in-anonymous
          //setTimeout("addCityWithoutCoords(nocoordsname, nocoordsnumunivs, nocoordsabstract, nocoordslink, citynum)", 500*citynum);
          geocode_helper(citynum, this.name, this.numberOfUniversities, this.abstractDescr, this.link);
      }
      else {
          cities_data.addRow([parseFloat(lat), parseFloat(long), this.name, this.numberOfUniversities]);
          cityInfos.addRow([this.abstractDescr, this.link]);
      }
    });

    if (citynum > 0) {
      drawMap('city');
  }
  else {
      document.getElementById('map_error').innerHTML = '<img src="images/icon_alert_error.gif"/>No cities reported for this country!';
      document.getElementById('map_error').style.display = 'inline';
  }
}

function setOptions(type, resolution, region, interactivity)
{
  if (options == null)
    {
      options = {
	  region: 'world',
	  resolution: 'continents',
	  datalessRegionColor: '2FA4E7',
	  backgroundColor: 'white',
	  displayMode: 'regions',
	  colorAxis: { colors: ['2FA4E7', '033C73'] },
	  enableRegionInteractivity: interactivity,
	  legend: 'none',
      //tooltip: {trigger:'none'}
      };
   }
  else 
   {
     options.region = region;
     options.resolution = resolution;
     options.displayMode = type;
     options.enableRegionInteractivity = interactivity;
   }
}
      
function setColorScheme(theme)
{
    //We can easily change the color schemes from here and add new ones if needed
    switch(theme)
    {
        //white dataless
        case 'bluewhite':
            options.datalessRegionColor = '';
            options.colorAxis = { colors: ['2FA4E7', '033C73'] };
            break;
            //blue dataless
        case 'blueblue':
            //Default is the blue theme
            options.datalessRegionColor = '';
            options.colorAxis = { colors: ['2FA4E7', '033C73'] };
            break;
        case 'red':
            options.datalessRegionColor = '2FA4E7';
            options.colorAxis = { colors: ['033C73', '033C73'] };

            break;
        default:
            //Default is the blue theme
            options.datalessRegionColor = '2FA4E7';
            options.colorAxis = { colors: ['2FA4E7', '033C73'] };
    }
    
}

function drawMap(datatoshow) 
{
    if (datatoshow == 'dummy') 
    {
        setColorScheme('blueblue');
        map.draw(dummy_world_data, options);
    }
    else if (datatoshow == 'dummy_country')
    {
        //blue scheme
        setColorScheme('blueblue');
        //dummy country data avoids bogus visualization on the country map
        map.draw(dummy_country_data, options);
    }
    else if (datatoshow == 'region')
    {
        //blue scheme
        setColorScheme('blueblue');
        map.draw(region_data, options);
    }
    else if (datatoshow == 'city') {
        //set the markers red
        setColorScheme('red');
        map.draw(cities_data, options);
    }
    else if (datatoshow == 'unicount') {
        setColorScheme('bluewhite');
        map.draw(region_data, options);
    }
}    