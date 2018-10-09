function WFazor() {
    
}

WFazor.submit = function (form) {
    try {
        var actionName = $(form).data('action');
        var controllerName = $(form).data('controller');
        var data = new Object();

        $(form).children('[data-bind]').each(function (index, element) {
            var dataBind = $(element).data('bind');
            data[dataBind] = $(element).val();
        });

        window.external.CallAction(actionName, controllerName, JSON.stringify(data));
    }
    catch (err) {
        alert("Error : " + err);
    }
};

WFazor.callAction = function (action, controller, data) {
    try {
        return JSON.parse(window.external.CallAction(action, controller, JSON.stringify(data)));
    }
    catch (err) {
        alert("Error : " + err);
    }
};
