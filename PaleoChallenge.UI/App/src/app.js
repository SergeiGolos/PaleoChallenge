(function() {
    var app = angular.module('paleo', ['rx']);

    app.controller('test', [
        '$scope',
        function($scope) {
            $scope.text = 'test';
        }
    ]);

})();