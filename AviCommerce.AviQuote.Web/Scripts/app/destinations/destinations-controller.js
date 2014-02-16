'use strict';

mainModule.controller("DestinationsController", function($scope, destinationRepository, $location) {
    $scope.destinations = destinationRepository.getAll();
    $scope.destination = destinationRepository.getOne(name);
    $scope.onDestinationClicked = function(id) {
        $location.url('main/destination/' + id);
    };
    $scope.map = {
        center: {
            latitude: 25.16,
            longitude: 55.18
        },
        zoom: 2
    };
    $scope.destinationMap = {
        center: {
            latitude: 25.16,
            longitude: 55.18
        },
        zoom: 8
    };
});
