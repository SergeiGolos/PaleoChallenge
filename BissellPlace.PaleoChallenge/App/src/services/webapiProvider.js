(function () {
    var app = angular.module('paleo');
    app.factory('webapiProvider', [
        '$http',
        'errorProvider',
        function ($http, errorProvider) {
            return {
                get : function(url) {
                    return $http.get(url).then(errorProvider.validateHttp);
                },
                set: function (url, item) {
                    return $http[item.Id ? "put" : "post"](url, item).then(errorProvider.validateHttp);
                },
                remove : function(url) {
                    return $http["delete"](url).then(errorProvider.validateHttp);
                }
            };            
        }
    ]);
})();