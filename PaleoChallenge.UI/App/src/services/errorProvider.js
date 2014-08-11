(function () {
    var app = angular.module('paleo');
    app.factory('errorProvider', [
        'eventService',
        function (eventService) {
            var eventHandler = eventService();
            var raise = function(data) {
                eventHandler.observer(data);
            }
            return {
                raise: raise,
                validateHttp: function(e) {
                    if (e.data.IsSuccess) {
                        return e.data.Model;
                    }

                    angular.forEach(e.data.Messages, raise);
                    throw('Http request failed.');
                },
                onError: function() {
                    return eventHandler.observable;
                }

            };
        }
    ]);
})();