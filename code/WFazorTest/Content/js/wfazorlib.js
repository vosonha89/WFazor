function WFazor() {
}

WFazor.callAction = function (actionName, controllerName, data) {
    window.external.CallAction(actionName, controllerName, data);
}
