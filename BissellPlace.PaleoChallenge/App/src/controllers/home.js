(function (defaultModel) {
    var app = angular.module('paleo');
    app.value('model', defaultModel);
    app.controller('home', [
        '$scope',
        '$q',   
		'$filter',
        'restService',
        'chartDataProvider',
        'model',
        function ($scope, $q, $filter, restService, chartDataProvider, model) {
            var rest = restService('Entry');
            $scope.y1axislabeltext = "Challange Points";
            $scope.y2axislabeltext = "Weight";

            $scope.xAxisTickFormat = function() {
                return function(d) {
                    return d3.time.format('%x')(new Date(d)); //uncomment for date format
                }
            }

            $scope.y1AxisTickFormat = function() {
                return function(d) {
                    return d3.format(',f')(d);
                }
            }

            $scope.y2AxisTickFormat = function() {
                return function(d) {
                    return '$' + d3.format(',.2f')(d);
                }
            }

            $scope.record = { Id: undefined, Type: 'Points' };
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

            $scope.save = function(entry) {
            	var noop = $q.defer();
            	noop.resolve();
            	$q.all([
                    entry.Data ? rest.set(entry) : noop.promise,
					entry.Weight ? rest.set({ Type: "Weight", Data: entry.Weight }) : noop.promise,
                    entry.Comment ? rest.set({ Type: "Comment", Data: entry.Comment }) : noop.promise
            	]).then(get);

            }
			$scope.initTab = function(){
                $scope.tabs = [
                    {
                        title: "Points",
                        url: "tab.points.html"
                    },
                    {
                        title: "Weight",
                        url: "tab.weight.html"
                    },
                    {
                    	title: "Comments",
                    	url: "tab.comments.html"
                    },
                    {
                    	title: "Date",
                    	url: "tab.date.html"
                    }
                ];

                $scope.currentTab = "tab.points.html";

                $scope.onClickTab = function(tab) {
                    $scope.currentTab = tab.url;
                };

                $scope.isActiveTab = function(tabUrl) {
                    return tabUrl == $scope.currentTab;
                };

                $scope.OnEnterTab = function (keyEvent) {
                	
                	if (keyEvent.which === 13) {

                		var tab = $filter("filter")($scope.tabs, { url: $scope.currentTab })[0];
                		var index = $scope.tabs.indexOf(tab);
                		$scope.currentTab = $scope.tabs[index % 4 + 1].url;

                	}
                }
                $scope.Today = function () {
                	return new Date();
                }
                
			}
			$scope.initTab();
        }
    ]);
})(defaultModel);
