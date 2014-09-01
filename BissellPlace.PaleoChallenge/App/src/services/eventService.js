(function () {
    var app = angular.module('paleo');
    app.factory('eventService', [
        'rx',
        function (rx) {
            return function() {
                var o;
                var fn = function () {
                    if (o) {
                        o.onNext(arguments);
                    }
                }
                return {
                    observable: rx.Observable.create(function (observ) {
                        o = observ;
                        return function () {
                            // Remove our listener function from the scope.
                            fn = undefined;
                        };
                    }),
                    observer: fn
                }
            }
        }
    ]);
})();