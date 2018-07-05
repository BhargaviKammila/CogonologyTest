(function (angular, modernizr) {
    'use strict';

    controllers.controller('HomeCtrl', ['$scope', '$rootScope', 'AcmeFlightAvailabilityService', function ($scope, $rootScope, AcmeFlightAvailabilityService) {
        var homevm = this;
        $scope.title = 'Home';        
        homevm.user = {
            startDate: null,
            endDate: null,
            pax: null
        };
        homevm.response = {
            flightName: null
        }
        function reset() {
            homevm.response = {
                flightName: null,
                error: null
            }
        }

        homevm.Convert = function () {
            reset();
            AcmeFlightAvailabilityService.CheckAvailability(homevm.user.startDate, homevm.user.endDate, homevm.user.pax).then(function (data) {
                if (data && data.hasOwnProperty('results')) {
                    if (data.results.hasOwnProperty('Error') && data.results.Error != null) {
                        homevm.response.error = data.results.Error;
                    } else {
                        homevm.response.error = null;
                        homevm.response.flightName = data.results.Output;
                    }
                }
            });
        }

    }]);

})(window.angular, Modernizr);