var map;
var globaladdress='', globalregion;
var places_service;
var pyrmont;
var infowindow;
var allmarkers;
var markertype;
var zero_results_types;
//var lastaddedtype;
var togglestatus;
var enabled = false;
var bound;
//Is this the places page for the university or for the city?
var parentPage;

var styles = [
  {
      "featureType": "road",
      "stylers": [
        { "visibility": "simplified" },
        { "color": "#d3d3d6" }
      ]
  },  {
      "featureType": "landscape",
      "stylers": [
        { "color": "#f5f5f5" }
      ]
  }, {
      "featureType": "poi",
      "elementType": "labels.text.fill",
      "stylers": [
        { "color": "#033c73" }
      ]
  }, {
      "featureType": "administrative",
      "elementType": "labels.text.fill",
      "stylers": [
        { "color": "#2fa4e7" }
      ]
  }, {
  }
];

google.load("maps", "3", { other_params: "sensor=false&libraries=places&language=en" });


function setAddressForPlaces(addr) {
    globaladdress = addr;
}

function setAddressForPlaces(cityName, regionName) {
    globaladdress = cityName;
    globalregion = regionName;
}

function places_init(what) {
    if (globaladdress != '' && !enabled) {
        parentPage = what;
        initialize();
        enabled = true;
    }
}

function alreadyenabled(what) {
  var i;
    for (i=0; i<allmarkers.length; i++) {
    if (markertype[i]==what) return true;
    }
  return false;
}

function isVisible(what) {
    var i;
    for (i = 0; i < allmarkers.length; i++) {
        if (markertype[i] == what)
            return allmarkers[i].getVisible();
    }
    return false;
}

function hadZeroResults(what) {
    var i;
    for (i = 0; i < zero_results_types.length; i++) {
        if (zero_results_types[i] == what)
            return true;
    }
    return false;
}

function toggle(what) {
    clearPage();
    if (hadZeroResults(what)) return;

    if (alreadyenabled(what)) {
        var i;
        if (isVisible(what)) {
            //alert('enabled and visible');
            for (i = 0; i < allmarkers.length; i++) {
                if (markertype[i] == what) allmarkers[i].setVisible(false);
            }
        }
        else {
            //alert('enabled and not visible');
            for (i = 0; i < allmarkers.length; i++) {
                if (markertype[i] == what) allmarkers[i].setVisible(true);
            }
        }
    }
    else {

        if (parentPage == 'univ') {
            var request = {
                location: pyrmont,
                radius: '1000',
                types: [what],
            };
        }
        else if (parentPage == 'city') {
            var request = {
                location: pyrmont,
                radius: '9000',
                types: [what],
            };
        }
        
        (function (type) {
            places_service.nearbySearch(request, function (results, status) {
                if (status == google.maps.places.PlacesServiceStatus.OK) {
                    for (var i = 0; i < results.length; i++) {
                        createMarker(results[i], type);
                    }
                    updateResultCount(type, results.length);
                }
                else if (status == google.maps.places.PlacesServiceStatus.ZERO_RESULTS) {
                    updateResultCount(type, 0);
                    zero_results_types.push(type);
                }
                else {
                    alert('There was an error with the request');
                }
            });
        })(what);
    }
}

function geocodingError() {
    document.getElementById("life").innerHTML = "<h3>Geocoding for this address has failed, the map isn't available. Sorry.</h3>";
}

function initialize() {
    //Hide everything below the map
    document.getElementById("place_details_header").style.visibility = "hidden";
    document.getElementById("place_details").style.visibility = "hidden";
    document.getElementById("place_reviews_header").style.visibility = "hidden";
    document.getElementById("place_reviews").style.visibility = "hidden";

    $("#reviews_accordion").accordion(
      {
          active: '.selected',
          selectedClass: 'active',
          //change : yourFunction,
      });

    
  zero_results_types = new Array();
  togglestatus = new Array();
  allmarkers = new Array();
  markertype = new Array();
    //infowindow = new google.maps.InfoWindow();
  bound = new google.maps.LatLngBounds();
  geocoder = new google.maps.Geocoder();
    if (parentPage == 'univ') {
        geocoder.geocode({ 'address': globaladdress,/*'region': lastcountry },*/ }, function (results, status) {
          if (status == google.maps.GeocoderStatus.OK) {
              pyrmont = new google.maps.LatLng(results[0].geometry.location.lat(), results[0].geometry.location.lng());

              map = new google.maps.Map(document.getElementById('map'), {
                  mapTypeId: google.maps.MapTypeId.ROADMAP,
                  disableDefaultUI: true,
                  center: pyrmont,
                  zoom: 14
              });
              places_service = new google.maps.places.PlacesService(map);

              map.setOptions({ styles: styles });

              var myicon = 'images/places/university.png';

              var placeLoc = pyrmont;
              bound.extend(placeLoc);
              var marker = new google.maps.Marker({
                  animation: google.maps.Animation.DROP,
                  map: map,
                  position: placeLoc,
                  icon: myicon
              });

              google.maps.event.addListener(marker, 'click', function () {
                  //infowindow.setContent("univ name here");
                  //infowindow.open(map, this);
              });
          }
          else {
              //Geocoding failed
              geocodingError();
          }
      });
      }
      else if (parentPage == 'city') {
          geocoder.geocode({ 'address': globaladdress, 'region': globalregion }, function (results, status) {
              if (status == google.maps.GeocoderStatus.OK) {
                  pyrmont = new google.maps.LatLng(results[0].geometry.location.lat(),results[0].geometry.location.lng());
                  
                      map = new google.maps.Map(document.getElementById('map'), {
                          mapTypeId: google.maps.MapTypeId.ROADMAP,
                          disableDefaultUI: true,
                          center: pyrmont,
                          zoom: 12
                      });
                      places_service = new google.maps.places.PlacesService(map);
    
                      map.setOptions({styles: styles});
                      var myicon = '';
                      var placeLoc = pyrmont;
                      bound.extend(placeLoc);
                      var marker = new google.maps.Marker({
                          animation: google.maps.Animation.DROP,
                          map: map,
                          position: placeLoc,
                          icon: myicon,
                      });

                      google.maps.event.addListener(marker, 'click', function() {
                          //infowindow.setContent("univ name here");
                          //infowindow.open(map, this);
                      });
              }
              else {
                  //Geocoding failed
                  geocodingError();
              }
          });
      }
}

function getHTMLForRating(rate, max) {
    if (rate < 0 || rate > max) return '';
    var value = '';
    for (var i = 0; i < rate; i++) {
        value += '<img src="images/places/full_star.png" width=16 height=16>';
    }
    for (var i = rate; i < max; i++) {
        value += '<img src="images/places/empty_star.png" width=16 height=16>';
    }
    return value;
}

function getDayName(num) {
    var res='';
    switch (num) {
        case 0:
            res = 'Sunday';
            break;
        case 1:
            res = 'Monday';
            break;
        case 2:
            res = 'Tuesday';
            break;
        case 3:
            res = 'Wednesday';
            break;
        case 4:
            res = 'Thursday';
            break;
        case 5:
            res = 'Friday';
            break;
        case 6:
            res = 'Saturday';
            break;
        default:
            res = 'Unknown day';
            break;
    }
    return res;
}

function getFormattedTime(time) {
    return time.substring(0, 2) + ':' + time.substring(2, 4);
}

function details_Callback(a, status) {
  if (status == google.maps.places.PlacesServiceStatus.OK) {
    //alert(a.reviews[0].text);
      document.getElementById('place_name').innerHTML = a.name;


      /*#####################################   BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC BASIC ############################*/
      document.getElementById("place_details_header").style.visibility = "visible";
      document.getElementById("place_details").style.visibility = "visible";
    var value='';
    var i;
    if (a.rating) value += '<p><b>Average rating:</b> ' + a.rating + ' / 5 </p>';
    if (a.formatted_phone_number) value += '<p><b>Phone number:</b> ' + a.formatted_phone_number + '</p>';
    if (a.website)  value += '<p><b>Website:</b> <a href="' + a.website + '">' + a.website + '</a></p>';
    if (a.opening_hours && a.opening_hours.periods) {
        value += '<p><b>Opening hours:</b></p>';
        for (i = 0; i < a.opening_hours.periods.length; i++) {
            value += '<p>' + getDayName(a.opening_hours.periods[i].open.day) +
                ': Open from ' + getFormattedTime(a.opening_hours.periods[i].open.time) +
                ' to ' + getFormattedTime(a.opening_hours.periods[i].close.time) + '</p>';
        }
    }
    document.getElementById('place_details').innerHTML = value;


      /*#####################################   REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS REVIEWS ############################*/
    if (a.reviews) {
        document.getElementById("place_reviews_header").style.visibility = "visible";
        document.getElementById("place_reviews").style.visibility = "visible";
        value = ''; 

        for (i = 0; i < a.reviews.length; i++) {
        /*    value += '<p>';
            value += '<b>' + a.reviews[i].author_name + '</b>';
            value += '</p>';
            */
        var ratings_string = '';
            for (var j = 0; j < a.reviews[i].aspects.length; j++) {
                ratings_string += '<br><b>' + a.reviews[i].aspects[j].type + ' ' + getHTMLForRating(a.reviews[i].aspects[j].rating, 3) + ' </b>';
                //ratings_string += '';
            }
            addReviewToList(a.reviews[i].author_name, ratings_string, a.reviews[i].text);
        /*
            value += '<p>';
            value += a.reviews[i].text;
            value += '</p>';
            */
        }
    }
    //document.getElementById('place_reviews').innerHTML = value;


      /*#####################################   PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS PHOTOS ############################*/
      /*    Commented out waiting for the decision about the Google API key */


    if (a.photos) {
        value = '';
        for (i = 0; i < a.photos.length; i++) {
            //alert(JSON.stringify(photos[i]));
            //url = 'https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=' + photos[i].raw_reference + '&sensor=false&key=AIzaSyCFALjT7z9i7mAsrvAW4Dvh6wNDDiWKfvM';
            
            value += '<a class="image" href="' + a.photos[i].raw_reference.fife_url + '" rel="lightbox" ">';
            value += '<img src="' + a.photos[i].raw_reference.fife_url + '"/>';
            value += '</a>';
            //value += '<div class="carousel-caption">';

        }
        document.getElementById('image_div').innerHTML = value;

        


       /* document.getElementById('places_carousel_inner').innerHTML = value;
        $('.carousel').carousel();
        //https://github.com/twitter/bootstrap/issues/3248... but should be fixed in boostrap 2.1... what's going on?
        $('.carousel').show();
        $('.carousel div.item').removeClass('left').removeClass('next'); */
    }
    //alert(document.getElementById('places_carousel_inner').innerHTML);
    /**/
  }
}

function clearPage() {
    document.getElementById('place_name').innerHTML = '';
    document.getElementById('place_details').innerHTML = '';
    document.getElementById('reviews_accordion').innerHTML = '';
    //Can't clear the carousel -> it would stop working
    //document.getElementById('places_carousel_inner').innerHTML = '';
    document.getElementById("place_details_header").style.visibility = "hidden";
    document.getElementById("place_details").style.visibility = "hidden";
    document.getElementById("place_reviews_header").style.visibility = "hidden";
    document.getElementById("place_reviews").style.visibility = "hidden";
    document.getElementById('image_div').innerHTML = "";
    //infowindow.close();
}

function addReviewToList(name, ratings, text) {
    var value;
    value = '<h3>' + name + '' + ratings + '</h3><div>';
    value += '<p>' + text + '</p>';
    value += '</div>';
    //document.getElementById('universities_list').innerHTML += value; 

    var active = $('#reviews_accordion').accordion('option', 'active');
    $('#reviews_accordion').append(value)
      .accordion('destroy').accordion({ active: active, collapsible: true, heightStyle: "content" });
}

function showDetails(ref) {

    var request = {
    reference: ref,
    };

    places_service.getDetails(request, details_Callback);
}

function createMarker(place, type) {
    //var myicon='museum.gif';
    var placeLoc = place.geometry.location;
    var myIcon = new google.maps.MarkerImage(place.icon, null, null, null, new google.maps.Size(25, 25));
    bound.extend(placeLoc);
    map.fitBounds(bound);
        var marker = new google.maps.Marker({
          map: map,
          position: place.geometry.location,
          animation: google.maps.Animation.DROP,
	      icon: myIcon,
        });
	allmarkers.push(marker);
	markertype.push(type);

	google.maps.event.addListener(marker, 'click', function () {
   	      clearPage();
          //infowindow.setContent(place.name);
          //infowindow.open(map, this);
	      showDetails(place.reference);
    });
}

function updateResultCount(type, cnt) {
    document.getElementById('btn_' + type).innerHTML += ' [' + cnt + ']';
}
      
