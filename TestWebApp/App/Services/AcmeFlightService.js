(function (angular, $) {
    'use strict';

    services.factory('AcmeFlightAvailabilityService', ['$q', '$http', function ($q, $http) {

        var self = {};

        self.CheckAvailability = function (startDate, endDate, pax) {
            var deferred = $q.defer();
            var data = {
                StartDate: startDate,
                EndDate: endDate,
                Pax: pax
            };
            $http({
                method: 'POST',
                url: 'api/AcmeFlight/CheckAvailability',
                data: $.param(data),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
            .success(function (data) {                
                deferred.resolve({
                    results: data
                });
            })
            .error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        };

        return self;

    }]);

})(window.angular, window.jQuery);