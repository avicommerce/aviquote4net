'use strict';

mainModule.controller("DestinationsController", function ($scope, destinationRepository, $location) {
    $scope.destinations = destinationRepository.getAll();
    $scope.destination = destinationRepository.getOne(name);
    $scope.onDestinationClicked = function (id) {
        $location.url('main/destination/' + id);
    };
});
