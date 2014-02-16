'use strict';

mainModule.controller("AirplanesController", function ($scope, airplaneRepository, $location) {
    $scope.airplanes = airplaneRepository.getAll();
    $scope.airplane = airplaneRepository.getOne(name);

    $scope.save = function (airplane) {
        $scope.errors = [];
        airplaneRepository.save(airplane).$promise.then(
            function () { $location.url('main/airplanes'); },
            function (response) { $scope.errors = response.data; });
    };

    $scope.onAirplaneClicked = function (id) {
        $location.url('main/airplane/' + id);
    };
});
