'use strict';

mainModule.controller("TripsController", function ($scope, tripRepository, airplaneRepository, tripService, $location, $routeParams) {
    // Trip management
    $scope.isFuelCostMode = true;
    $scope.isHandlingCostMode = false;
    $scope.isNavigationFeesCostMode = false;
    $scope.isAirportFeesCostMode = false;

    $scope.fuelSuppliers = [
        "Jetex",
        "Hadeed",
        "Someone else",
        "Someone else 1" 
    ];
    $scope.fuelSuppliersPrices = [
        {name: "Jetex", price: 3.65 },
        {name: "Hadeed", price: 3.68 },
        {name: "Someone else", price: 3.72 },
        {name: "Someone else 1", price: 3.78 }
    ];
    $scope.airplanes = airplaneRepository.getAll();
    $scope.trips = tripRepository.getAll();
    
    $scope.saveSummary = function (trip) {
        $scope.errors = [];

        // Complete the attributes to make a TripSummaryVm to match the server's expectation
        trip.airplane = trip.airplane.name; // Convert from complex type to a string
        trip.createDate = new Date();
        trip.from = "";
        trip.estimatedTakeOff = new Date();
        trip.to = "";
        trip.estimatedLanding = new Date();

        trip.estimatedFuelCost = 0;
        trip.estimatedHandlingCost = 0;
        trip.estimatedNavigationFeesCost = 0;
        trip.estimatedAirportFeesCost = 0;

        trip.stops = 0;
        trip.legs = 0;

        tripRepository.save(trip).$promise.then(
            function () {
                $scope.trip = trip;
                $location.url('main/trips');
            },
            function (response) { $scope.errors = response.data; });
    };

    $scope.onTripClicked = function (id) {
        $location.url('main/trip/' + id);
    };

    $scope.toggleTripEditable = function(trip) {
        trip.isEditable = !trip.isEditable;
    };

    // ==== Trip stops Management
    //TODO: I would like to call conditionTrip here instead but it is not working!!
    //TODO: Also...it is important to see whether there is akready a tri stashed away with the same id
    $scope.trip = tripRepository.getOne($routeParams.id);
    
    $scope.addStop = function (symbol) {
        //TODO: Validate the symbol and make sure it is not already added
        var tripStop = {};
        tripStop.identifier = generateStopId();
        tripStop.tripIdentifier = $scope.trip.identifier;
        tripStop.destination = "Dubai"; // TODO: 
        tripStop.stop = symbol;
        tripStop.estimatedTakeOff = new Date();
        tripStop.estimatedLanding = new Date();
        tripStop.isOrigin = ($scope.trip.stops.length > 0) ? false : true;
        tripStop.isDestination = true; //TODO: Will need to adjust the other stored stops 
        tripStop.isTechnical = false;
        tripStop.order = -1;

        tripStop.estimatedFuelCost = 0;
        tripStop.estimatedHandlingCost = 0;
        tripStop.estimatedAirportFeesCost = 0;

        tripStop.fuelGallons = 0;
        tripStop.fuelPricePerGallon = 3.67; // TODO: get the price from the best supplier 
        tripStop.fuelSupplier = $scope.fuelSuppliers[0]; // TODO: get the best-price fuel supplier
        tripStop.isFuelOrdered = false;
        tripStop.fuelOrderedDate = new Date();

        tripStop.handler = "Dnata"; // TODO: get the best-price handler
        tripStop.isHandlingOrdered = false;
        tripStop.handlingOrderedDate = new Date();

        tripStop.airportFees = [];
        $scope.trip.stops.push(tripStop);

        setupStopsFlags();
        $scope.airportSymbol = "";
    };

    $scope.removeTripStop = function(stop) {
        console.log('removeTripStop: ' + stop);
        var tempStops = $scope.trip.stops;
        $scope.trip.stops = [];
        for (var i = 0; i < tempStops.length; i++) {
            if (tempStops[i].identifier != stop.identifier)
                $scope.trip.stops.push(tempStops[i]);
        }

        setupStopsFlags();
    };
    
    $scope.upTripStop = function (stop) {
        console.log('upTripStop: ' + stop);
        // Look for the one that needs to be re-positioned
        var currentIndex = 0;
        for (var i = 0; i < $scope.trip.stops.length; i++) {
            if ($scope.trip.stops[i].identifier === stop.identifier)
                currentIndex = i;
        }

        var tempStop = null;
        if (currentIndex > 0) {
            tempStop = $scope.trip.stops[currentIndex - 1];
            $scope.trip.stops[currentIndex - 1] = stop;
            $scope.trip.stops[currentIndex] = tempStop;
        }

        setupStopsFlags();
    };
    
    $scope.downTripStop = function (stop) {
        console.log('downTripStop: ' + stop);
        //TODO: re-shuffle the stops based on this stop
        // Look for the one that needs to be re-positioned
        var currentIndex = 0;
        for (var i = 0; i < $scope.trip.stops.length; i++) {
            if ($scope.trip.stops[i].identifier === stop.identifier)
                currentIndex = i;
        }

        var tempStop = null;
        if (currentIndex < $scope.trip.stops.length - 1) {
            tempStop = $scope.trip.stops[currentIndex + 1];
            $scope.trip.stops[currentIndex + 1] = stop;
            $scope.trip.stops[currentIndex] = tempStop;
        }

        setupStopsFlags();
    };

    $scope.showDestination = function (destination) {
        //TODO: Save current trip
        // Save the trip in the service so we can retrieve it when we are back here
        tripService.setTrip($scope.trip);
        $location.url('main/destination/' + destination);
    };

    $scope.switchToFuelCost = function() {
        $scope.isFuelCostMode = true;
        $scope.isHandlingCostMode = false;
        $scope.isNavigationFeesCostMode = false;
        $scope.isAirportFeesCostMode = false;
    };

    $scope.switchToHandlingCost = function () {
        $scope.isFuelCostMode = false;
        $scope.isHandlingCostMode = true;
        $scope.isNavigationFeesCostMode = false;
        $scope.isAirportFeesCostMode = false;
    };

    $scope.switchToNavigationFeesCost = function () {
        $scope.isFuelCostMode = false;
        $scope.isHandlingCostMode = false;
        $scope.isNavigationFeesCostMode = true;
        $scope.isAirportFeesCostMode = false;
    };

    $scope.switchToAirportFeesCost = function () {
        $scope.isFuelCostMode = false;
        $scope.isHandlingCostMode = false;
        $scope.isNavigationFeesCostMode = false;
        $scope.isAirportFeesCostMode = true;
    };

    $scope.placeFuelOrder = function (stop) {
        // TODO: 
        stop.isFuelOrdered = true;
    };

    $scope.cancelFuelOrder = function (stop) {
        // TODO: 
        stop.isFuelOrdered = false;
    };

    $scope.fuelSupplierChanged = function(stop) {
        console.log('fuelSupplierChanged: ' + stop.fuelSupplier);
        // TODO: Make this better ...of course
        for (var s=0; s < $scope.fuelSuppliersPrices.length; s++) {
            if (stop.fuelSupplier == $scope.fuelSuppliersPrices[s].name) {
                var price = $scope.fuelSuppliersPrices[s].price;
                stop.fuelPricePerGallon = price;
            }
        }
    };

    $scope.fuelSupplierSelected = function (stop, fuelSupplierPrice) {
        console.log('fuelSupplierSelected: ' + fuelSupplierPrice.name);
        stop.fuelSupplier = fuelSupplierPrice.name;
        stop.fuelPricePerGallon = fuelSupplierPrice.price;
        $('#fuelPricesDlg-' + stop.identifier).modal('hide');
    };

    $scope.browsePrices = function (stop) {
        $('#fuelPricesDlg-' + stop.identifier).modal({keyboard: true, show: true});
        //$('#fuelPricesDlg-' + stop.identifier).modal('show');
    };

    $scope.editableStopsPluralizer = {
        0: "No stops! Please add stops by clicking the 'Add Stop' button.",
        1: "One stop only in this trip! Please add more stops.",
        other: "{} stops in this trip! Please use the arrow keys to shuffle the stops."
    };

    $scope.nonEditableStopsPluralizer = {
        0: "No stops!",
        1: "One stop only in this trip!",
        other: "{} stops in this trip!"
    };

    // ==== PRIVATE FUNCTIONS
    function conditionTrip() {
        console.log('conditionTrip: ' + $routeParams.id);
        $scope.trip = tripRepository.getOne($routeParams.id);
        setupStopsFlags();
    }

    function setupStopsFlags() {
        console.log('setupStopsFlags: ' + $scope.trip.stops);
        for (var i = 0; i < $scope.trip.stops.length; i++) {
            $scope.trip.stops[i].order = i+1;
            if (i == 0) {
                $scope.trip.stops[i].isOrigin = true;
                $scope.trip.stops[i].isDestination = false;
            } else if (i == $scope.trip.stops.length - 1) {
                $scope.trip.stops[i].isOrigin = false;
                $scope.trip.stops[i].isDestination = true;
            } else {
                $scope.trip.stops[i].isOrigin = true;
                $scope.trip.stops[i].isDestination = true;
            }
        }
    }

    function generateStopId() {
        var text = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < 7; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
    }
});
