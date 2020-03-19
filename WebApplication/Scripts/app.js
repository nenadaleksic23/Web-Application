var DefaultComplete = function (object) {
    if (object) {
        switch (object.Status){
            case "Ok":
                AjaxSuccess(object);
                break;
            case "error":
                AjaxError
                break;
        } 
    }
}
function AjaxSuccess(response) {
    if (response.Callback.length) {
        if (typeof (window[response.Callback]) == 'function') {
            window[response.Callback].call(response.CallbackParameter);
        }
    }
}
function AjaxError(response) {
    window.alert(response.Message);
}
function RefreshProducts(path) {
    Response.redirect(path);
}
