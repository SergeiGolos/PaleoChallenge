(function () {
    var app = angular.module('paleo');
    app.factory('restService', [
        'webapiProvider',
        function (webapiProvider) {            
            return function (serviceName) {
                function toUrl(id) {
                    return ["api", serviceName, id || ''].join('/');
                }
                return {
                    get : function(id) {                        
                        return webapiProvider.get(toUrl(id));
                    },
                    set : function(item) {                        
                        return webapiProvider.set(toUrl(item.Id), item);
                    },
                    remove : function(id) {
                        return webapiProvider.remove(toUrl(id));
                    }
                }
            };
        }
    ]);
})();