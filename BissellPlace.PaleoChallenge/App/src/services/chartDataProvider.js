(function() {
    var app = angular.module('paleo');

    app.factory('chartDataProvider', [
        function () {
            return {
                weekSummary: function (data, type, defaults) {
                    var list = _.chain(data)
                        .filter(function (item) { return item.Type == type; })
                        .forEach(function (item) {
                            item.CheckDate = moment(item.Record.TimeStamp).format('l');
                        })
                        .value();
                    
                    var result = _.chain(_.range(7))
                        .map(function (item) { return moment().subtract(item, 'days');})
                        .map(function (item) {                            
                            var check = item.format('l');                            
                            var match = _.find(list, function(i) {
                                return i.CheckDate == check;
                            });
                            if (!match && defaults !== undefined) {
                                match = { Type: type, Record : { TimeStamp: item.toDate() }, CheckDate: check, Data: defaults };
                            }                            
                            return match;
                        })
                        .filter(function(item) {
                            return item != null;
                        })
                        .map(function (item) {
                            return [moment(item.Record.TimeStamp).format("l"), item.Data || 
                                type == 'WeightEntry' ? item.Weight : item.Points + item.Bonus];
                        })
                        .value();

                    return result;
                }
            };
        }
    ]);
})();