(function(angular) {
    var app = angular.module('paleo');
    app.directive('chartProgressWeight', function () {
        return {
            restrict: 'A',
            scope: {
                chart: '='
            },
            //templateUrl: 'views\directives\chartProgressWeight.html',
            link : function(scope, element, attrs) {
                element.addClass = scope.$id;
                nv.addGraph(function () {
                    var chart = nv.models.multiBarChart()
                      .transitionDuration(350)
                      .reduceXTicks(true)   //If 'false', every single x-axis tick label will be rendered.
                      .rotateLabels(0)      //Angle to rotate x-axis labels.
                      .showControls(false)   //Allow user to switch between 'Grouped' and 'Stacked' mode.
                      .groupSpacing(0.1)    //Distance between each group of bars.
                    ;

                    chart.xAxis
                        .tickFormat(d3.format(',f'));

                    chart.yAxis
                        .tickFormat(d3.format(',.1f'));

                    d3.select('#' + attrs.id + ' svg' )
                        .datum(scope.chart)
                        .call(chart);

                    nv.utils.windowResize(chart.update);

                    return chart;
                });              
            }
        };
    });
})(angular)