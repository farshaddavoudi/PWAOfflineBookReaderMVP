registerOnlineStatusHandler = function (dotNetObjRef) {
    function onlineStatusHandler() {
        dotNetObjRef.invokeMethodAsync("SetOnlineStatusColor", navigator.onLine);
    };

    onlineStatusHandler();

    window.addEventListener("online", onlineStatusHandler);
    window.addEventListener("offline", onlineStatusHandler);
}

function isAppOnline() {
    return navigator.onLine;
}