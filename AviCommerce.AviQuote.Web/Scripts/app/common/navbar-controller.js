'use strict';

mainModule.controller('NavbarController', function ($scope, $location) {
    $scope.getClass = function (path) {
        if ($location.path() == '/main' + path) {
            return true;
        } else {
            return false;
        }
    };
});
