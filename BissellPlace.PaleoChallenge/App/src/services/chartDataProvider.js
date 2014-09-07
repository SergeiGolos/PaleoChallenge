(function() {
    var app = angular.module('paleo');

    app.factory('chartDataProvider', [
        function () {
            return {
                weekSummary: function (data, type) {
                    var list = _.chain(data)
                        .filter(function (item) { return item.Type == type; })
                        .forEach(function (item) {
                            item.TimeStamp = moment(item.Record.TimeStamp, moment.ISO_8601);
                            item.CheckDate = item.Record.TimeStamp.format('l');
                        })
                        .value();

                    var result = _.chain(_.range(7))
                        .map(function (item) { return moment().subtract(item, 'days'); })
                        .map(function (item) {
                            var check = item.format('l');
                            return _.find(list, function (i) {
                                return i.CheckDate == check;
                            }) || { Type: type, TimeStamp: item, CheckDate: check, Data: 0 };
                        })
                    .map(function (item) {
                        return [item.TimeStamp.utc(), item.Data];
                    }).value();

                    return result;
                }
            };
        }
    ]);
})();