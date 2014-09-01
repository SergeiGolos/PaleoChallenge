(function() {
    var app = angular.module('paleo');
    app.controller('home', [
        '$q',
        '$scope',
        'restService',
        function($q, $scope, restService) {
            var rest = restService('Entry');
            $scope.y1axislabeltext = "Challange Points";
            $scope.y2axislabeltext = "Weight";              

            $scope.xAxisTickFormat = function () {
                return function (d) {
                    return d3.time.format('%x')(new Date(d));  //uncomment for date format
                }
            }

            $scope.y1AxisTickFormat = function () {
                return function (d) {
                    return d3.format(',f')(d);
                }
            }
            $scope.y2AxisTickFormat = function () {
                return function (d) {
                    return '$' + d3.format(',.2f')(d);
                }
            }
            function loadType(data, type) {
                return _.chain(data)
                    .filter(function(item) { return item.Type == type; })
                    .map(function (item) { return [item.TimeStamp, item.Data]; })
                    .value();
            }


            function get() {
                rest.get().then(function(data) {                    

                    $scope.exampleData = [
                        {
                            "key": "Quantity",
                            "bar": true,
                            "values": loadType(data, "Points")
                        },
                        {
                            "key": "Price",
                            "values": loadType(data, "Weight")
                        }
                    ];

                    $scope.entries = data;
                    $scope.record = { Id: undefined , Type : 'Points' };
                });
            };

            $scope.save = function (entry) {
                var noop = $q.defer();
                noop.resolve();
                $q.all([
                    entry.Data ? rest.set(entry) : noop.promise,
                    entry.Weight ? rest.set({ Type: "Weight", Data: entry.Weight }) : noop.promise
                ]).then(get);
            }
            get();
        }
    ]);
})();