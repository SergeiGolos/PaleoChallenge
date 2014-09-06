/// <reference path="~/Scripts/angular.js"/>
/// <reference path="~/Scripts/angular-mocks.js"/>
/// <reference path="~/Scripts/d3.js" />
/// <reference path="~/Scripts/nv.d3.js" />
/// <reference path="~/Scripts/rx.js" />
/// <reference path="~/Scripts/rx.lite.js" />
/// <reference path="~/Scripts/rx.angular.js" />
/// <reference path="~/Scripts/angularjs-nvd3-directives.js" />
/// <reference path="~/App/src/app.js"/>
/// <reference path="~/App/src/controllers/home.js"/>
/// <reference path="~/App/src/services/errorProvider.js"/>
/// <reference path="~/App/src/services/eventService.js"/>
/// <reference path="~/App/src/services/restService.js"/>
/// <reference path="~/App/src/services/webapiProvider.js"/>

describe("Unit Testing Controller Examples", function() {

    var $scope;
    beforeEach(module('paleo'));
    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        $controller('home', { $scope: $scope });
    }));

    it('should have a scope with save defined', function () {
        expect($scope.save).toBeDefined();
    });
});