(function() {
    var app = angular.module('paleo');
    app.controller('home', [
        '$scope',
        'restService',
        function($scope, restService) {
            var rest = restService('Entry');
            rest.get().then(function(data) {
                $scope.entries = data;
            });
        }
    ]);
})();