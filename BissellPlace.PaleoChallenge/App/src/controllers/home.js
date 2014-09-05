(function() {
    var app = angular.module('paleo');
    app.controller('home', [
        '$scope',
        '$q',        
        'restService',
        function ($scope, $q, restService) {
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
                var list = _.chain(data)
                    .filter(function (item) { return item.Type == type; })
                    .forEach(function (item) {
                        item.TimeStamp = moment(item.TimeStamp, moment.ISO_8601);
                        item.CheckDate = item.TimeStamp.format('l');
                    })
                    .value();

                var result = _.chain(_.range(5))
                    .map(function (item) { return moment().subtract(item, 'days'); })
                    .map(function (item) {
                        var check = item.format('l');
                        return _.find(list, function (i) {
                            return i.CheckDate == check;
                        }) || { Type: type, TimeStamp: item, CheckDate: check, Data: 0 };
                    })
                .map(function (item) {
                    return [item.TimeStamp.utc(), item.Data];
                }).value();


                //var result = 
                //        var date = 
                //        console.log(date, date.date().uc);
                //        return ;
                //    })
                //    .value();
                return result;
            }

            function get() {
                rest.get().then(function(data) {                    

                    $scope.exampleData = [
                        {
                            "key": "Points",
                            "bar": true,
                            "values": loadType(data, "Points")
                        },
						{
							"key": "Comment",
							"values": loadType(data, "Comment")
						},
                        {
                            "key": "Weight",
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
                    entry.Weight ? rest.set({ Type: "Weight", Data: entry.Weight }) : noop.promise,
					entry.Comment ? rest.set({ Type: "Comment", Data: entry.Comment}): noop.promise
                ]).then(get);
            }
            get();

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
				}];
            $scope.currentTab = 'tab.points.html';
			
            $scope.onClickTab = function (tab) {            	
            	$scope.currentTab = tab.url;
            };

            $scope.isActiveTab = function (tabUrl) {            	
            	return tabUrl == $scope.currentTab;
            };
        }
    ]);
})();