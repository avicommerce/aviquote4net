'use strict';

mainModule.controller("DashboardController", function ($scope, airplaneRepository, tripRepository, destinationRepository, $location) {
    $scope.recentTrips = tripRepository.getAll();
    $scope.notCompletedTrips = tripRepository.getAll();
    $scope.airplanes = airplaneRepository.getAll();
    $scope.destinations = destinationRepository.getAll();
});
