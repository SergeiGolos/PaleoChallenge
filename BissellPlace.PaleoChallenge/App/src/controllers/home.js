﻿(function (defaultModel) {
    var app = angular.module('paleo');
    app.value('model', defaultModel);
    app.controller('home', [
        '$scope',
        '$q',        
        'restService',
        'chartDataProvider',
        'model',
        function ($scope, $q, restService, chartDataProvider, model) {
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

            $scope.record = { Id: undefined , Type : 'Points' };
            $scope.records = model;
            $scope.chart = [
                {
                    "key": "Points",
                    "bar": true,
                    "values": chartDataProvider.weekSummary(model, "Points")
                },
                {
                    "key": "Weight",
                    "values": chartDataProvider.weekSummary(model, "Weight")
                }
            ];

            $scope.save = function (entry) {
                var noop = $q.defer();
                noop.resolve();
                $q.all([
                    entry.Data ? rest.set(entry) : noop.promise,
                    entry.Weight ? rest.set({ Type: "Weight", Data: entry.Weight }) : noop.promise
                ]).then(get);
            }            
        }
    ]);
})(defaultModel);