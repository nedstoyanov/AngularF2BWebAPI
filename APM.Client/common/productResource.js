(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("productResource",
                 ["$resource", "appSettings", productReource])

    function productResource($resource, appSettings) 
    {
        return $resource(appSettings.serverPAth + "/api/products/:id");
    }

}());