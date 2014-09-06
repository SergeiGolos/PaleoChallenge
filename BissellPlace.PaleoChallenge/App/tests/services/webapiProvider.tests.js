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

(function (beforeEach, describe, it) {
    describe("Web Api Provider Unit Test", function() {
        var provider;
        var message = [];
        var request = [];
        var obsrv = {};
        var result = {};
        var q;

        beforeEach(module('paleo'));
        beforeEach(function() {
            var eventService = {
                validateHttp: function(e) {
                    message.push(e);
                    return e;
                }
            };

            var httpService = {
                get: function(url) {
                    request.push({ url: url, data: null, type: 'GET' });
                    return qResult(result);
                },
                put: function(url, item) {
                    request.push({ url: url, data: item, type: 'PUT' });
                    return qResult(result);
                },
                post: function(url, item) {
                    request.push({ url: url, data: item, type: 'POST' });
                    return qResult(result);
                },
                'delete': function(url) {
                    request.push({ url: url, data: null, type: 'REMOVE' });
                    return qResult(result);
                }
            }

            module(function($provide) {
                $provide.value('errorProvider', eventService);
                $provide.value('$http', httpService);
            });

            var qResult = function(data) {
                return {
                    then: function(fn) {
                        fn(data);
                    }
                }
            };

        });

        beforeEach(inject(function (webapiProvider) {
            provider = webapiProvider;            
        }));

        beforeEach(function () {
            message = [];
            request = [];
        });

        describe("Creating the Webapi Provider with the expected api.", function () {

            it('should be defined', function() {
                expect(provider).toBeDefined();
            });
            it('has get', function() {
                expect(typeof (provider.get)).toEqual('function');
            });

            it('has set', function() {
                expect(typeof (provider.set)).toEqual('function');
            });

            it('has remove', function() {                
                expect(typeof (provider.remove)).toEqual("function");
            });
        });

        describe("results are validated.", function() {

            it('validate get.', function () {
                provider.get("");
                expect(message.length).toEqual(1);                
            });

            it('validate set.', function() {
                provider.set("", { id: undefined });
                expect(message.length).toEqual(1);                
            });

            it('validated remove.', function () {
                provider.remove("");
                expect(message.length).toEqual(1);            
            });

        });

        describe("correct http calls are made.", function() {            
            it("Get makes an http Get request.", function () {
                provider.get("test");
                expect(request[0].type).toEqual('GET');
            });

            it("Set with Id makes an http PUT request.", function () {
                provider.set("test", { Id: 1 });
                expect(request[0].type).toEqual('PUT');
            });

            it("set without id makes an http POST request.", function () {
                provider.set("test", { Id: undefined });
                expect(request[0].type).toEqual('POST');
            });

            it("Remove makes an http delete request.", function () {
                provider.remove("test");
                expect(request[0].type).toEqual('REMOVE');
            });
        });
    });
})(beforeEach, describe, it);