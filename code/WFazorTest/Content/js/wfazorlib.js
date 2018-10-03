function WFazor() {

}

WFazor.callAction = function (actionName, controllerName, data) {
    alert(document.head);
    //try {
    //    $('[data-model]').each(function (element, index) {
    //        var data_bind = $(element).data('model');
    //        alert(data_bind);
    //    });

    //    window.external.CallAction(actionName, controllerName, data);
    //}
    //catch (err) {
    //    alert(err);
    //}
};

WFazor.init = function (runtimePath) {
    alert(runtimePath);
    // Immediately-invoked function expression
    (function () {
        // Load the script
        var script = document.createElement("SCRIPT");
        script.src = '';
        script.type = 'text/javascript';
        script.onload = function () {
            var $ = window.jQuery;
            // Use $ here...
        };
        document.getElementsByTagName("head")[0].appendChild(script);
    })();
};

