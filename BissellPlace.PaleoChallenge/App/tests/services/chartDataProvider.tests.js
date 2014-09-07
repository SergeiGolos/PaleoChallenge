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
        beforeEach(module('paleo'));            

        beforeEach(inject(function (chartDataProvider) {
            provider = chartDataProvider;
        }));

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
                expect(provider.weekSummary([], '').length).toEqual(7);
            });

            it('should create default values for points and', function() {
                var result = provider.weekSummary([], '');
                expect(result[0].).toEqual;
            });

        });

    });
})(beforeEach, describe, it);