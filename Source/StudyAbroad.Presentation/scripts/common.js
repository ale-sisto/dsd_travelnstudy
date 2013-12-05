// COMMON UTILITY FUNCTIONS
// ################################################################

// retrieve the value of the given parameter of the GET request
function getUrlParameter(param_name) {
    var search_string = window.location.search.substring(1),
        i, val, params = search_string.split("&");

    for (i = 0; i < params.length; i++) {
        val = params[i].split("=");
        if (val[0] == param_name) {
            return decodeURIComponent(val[1]);
        }
    }
    return null;
}

// general ajax syncronous or asyncronous page methods handler
// true => async
// false => sync
function PageMethod(method_name, params, success_callback, fail_callback, async_flag) {
    var method_url = window.location.pathname + "/" + method_name;
    var serialized_list = "";
    if (params.length > 0)
        for (var c = 0; c < params.length; c += 2) {
            if (serialized_list.length > 0) serialized_list += ","; serialized_list += '"' + params[c] + '":"' + params[c + 1] + '"'

        }
    serialized_list = "{" + serialized_list + "}";
    $.ajax({
        type: "POST",
        url: method_url,
        contentType: "application/json; charset=utf-8",
        data: serialized_list,
        dataType: "json",
        success: success_callback,
        error: fail_callback,
        async: async_flag
    });
}
