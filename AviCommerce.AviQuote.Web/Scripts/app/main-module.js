var mainModule = angular.module("mainModule", ['ngRoute', 'ngResource', 'ui.bootstrap.datetimepicker'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/main/dashboard',
            {
                templateUrl: '/templates/dashboard.html',
                controller: 'DashboardController'
            });

        $routeProvider.when('/main/destinations',
            {
                templateUrl: '/templates/destinations.html',
                controller: 'DestinationsController'
            });
        $routeProvider.when('/main/destination/:id',
            {
                templateUrl: '/templates/destination.html',
                controller: 'DestinationsController'
            });

        $routeProvider.when('/main/trips',
            {
                templateUrl: '/templates/trips.html',
                controller: 'TripsController'
            });
        $routeProvider.when('/main/trip/:id',
            {
                templateUrl: '/templates/trip.html',
                controller: 'TripsController'
            });
        $routeProvider.when('/main/create-trip',
            {
                templateUrl: '/templates/create-trip.html',
                controller: 'TripsController'
            });

        $routeProvider.when('/main/airplanes',
            {
                templateUrl: '/templates/airplanes.html',
                controller: 'AirplanesController'
            });
        $routeProvider.when('/main/airplane/:id',
            {
                templateUrl: '/templates/airplane.html',
                controller: 'AirplanesController'
            });
        $routeProvider.when('/main/create-airplane',
            {
                templateUrl: '/templates/create-airplane.html',
                controller: 'AirplanesController'
            });

        // Default Route****
        $routeProvider.otherwise({ redirectTo: '/main/dashboard' });

        $locationProvider.html5Mode(true);
    });