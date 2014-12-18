/// <reference path="~/Scripts/angular.js"/>
/// <reference path="~/Scripts/angular-mocks.js"/>
/// <reference path="~/Scripts/d3.js" />
/// <reference path="~/Scripts/lodash.js" />
/// <reference path="~/Scripts/moment.js" />
/// <reference path="~/Scripts/nv.d3.js" />
/// <reference path="~/Scripts/rx.js" />
/// <reference path="~/Scripts/rx.lite.js" />
/// <reference path="~/Scripts/rx.angular.js" />
/// <reference path="~/Scripts/angularjs-nvd3-directives.js" />
/// <reference path="~/App/src/app.js"/>
/// <reference path="~/App/src/controllers/home.js"/>
/// <reference path="~/App/src/services/errorProvider.js"/>
/// <reference path="~/App/src/services/chartDataProvider.js"/>
/// <reference path="~/App/src/services/eventService.js"/>
/// <reference path="~/App/src/services/restService.js"/>
/// <reference path="~/App/src/services/webapiProvider.js"/>

(function (beforeEach, describe, it) {
    describe("Error Provider Unit Test", function () {
        var provider;
        var defaultModel;
        beforeEach(module('paleo'));            

        beforeEach(inject(function (chartDataProvider) {
            provider = chartDataProvider;
        }));

        function defaultItem(id, daysBack) {
            return { "Id":id, "Record": { "Challenger": { "Id": 1, "UserName": "SingleUser", "LastAccess": "\/Date(1410213236164)\/" }, "Id": id, "TimeStamp": moment().subtract(daysBack, 'days').toDate() } };
        }

        function defaultPoints(id, daysBack, point, bonus) {
            return _.assign(defaultItem(id, daysBack), { "Points": point, "Bonus": bonus, "Type": "PointEntry" });
        }

        function defaultWeight(id, daysBack, weight) {

            return _.assign(defaultItem(id, daysBack), { "Weight": weight, "Type": "WeightEntry" });
        }
  
        describe("Should be able to inject the chart data provier.", function () {
            it('is defined', function() {
                expect(provider).toBeDefined();
            });

            it('should also expose weekSumary.', function() {
                expect(typeof(provider.weekSummary)).toEqual('function');
            });
        });

        describe("Can oraganize chart.", function() {
            it('should be able to group dates to 7 days with 0 data.', function() {
                expect(provider.weekSummary([], '', 0).length).toEqual(7);
            });

            it('should be able to group dates to 0 days with 0 data without defaults.', function () {
                expect(provider.weekSummary([], '').length).toEqual(0);
            });

            it('should be able to group dates to 0 days with 0 data without defaults.', function () {
                expect(provider.weekSummary([], '').length).toEqual(0);
            });

            it('Todays value should be returned', function () {
                var weight = defaultWeight(1, 0, 200);
                var result = provider.weekSummary([weight], 'WeightEntry');
                // expect(weight).toEqual(null);
                expect(result[0]).toBeDefined();
                expect(result[0][1]).toEqual(200);
            });

            it('should not return an entry from before 7 days ago', function() {
                var weight = defaultWeight(1, 8, 200);
                var result = provider.weekSummary([weight], 'WeightEntry');
                // expect(weight).toEqual(null);
                expect(result).toEqual([]);
            });

        });

    });
})(beforeEach, describe, it);