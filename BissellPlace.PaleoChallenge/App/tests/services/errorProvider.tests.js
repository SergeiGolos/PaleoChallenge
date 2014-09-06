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
    describe("Error Provider Unit Test", function() {
        var provider;
        var errors = [];
        var obsrv = {};
        beforeEach(module('paleo'));
        beforeEach(function() {
            var eventService = function() {
                return {
                    observer: function(e) {
                        errors.push(e);
                    },
                    observable: obsrv
                }
            };

            module(function($provide) {
                $provide.value('eventService', eventService);
            });
        });

        beforeEach(inject(function(errorProvider) {
            provider = errorProvider;
        }));

        describe("Creating the Error Provider.", function() {

            it('should be defined with the expected api', function() {
                expect(provider).toBeDefined();
            });
            it('raise: exposes an observer', function() {
                expect(typeof (provider.raise)).toEqual('function');
            });

            it('validateHttp: exposes a function', function() {
                expect(typeof (provider.validateHttp)).toEqual('function');
            });

            it('onError: exposes an observable', function() {
                expect(provider.onError).toBeDefined();
                expect(typeof (provider.onError)).toEqual("function");
            });
        });

        describe("ValidateHttp parses errors.", function() {
            beforeEach(function () {
                errors = [];
            });

            function validate(model, success, messages) {
                return provider.validateHttp({
                    data: {
                        Model: model,
                        IsSuccess: success,
                        Messages: messages
                    }
                });
            }

            it('returns the model on a successful http request.', function() {
                var model = {};
                var result = validate(model, true);

                expect(result).toEqual(model);
            });

            it('throws eror if the message fails.', function () {
                expect(function () { validate({}, false, [{}]) }).toThrow(new Error('Http request failed.'));
            });

            it('pusshes a message to the error queue if the message fails.', function () {
                expect(function () { validate({}, false, [{}]) }).toThrow(new Error('Http request failed.'));
                expect(errors.length).toEqual(1);
            });

        });

        describe("Correct event handling.", function() {
            beforeEach(function() {
                errors = [];
            });

            it("Can raise an event", function () {
                provider.raise("test");
                expect(errors[0]).toEqual("test");
            });

            it("returns the event observable", function() {
                expect(provider.onError()).toEqual(obsrv);
            });
        });
    });
})(beforeEach, describe, it);