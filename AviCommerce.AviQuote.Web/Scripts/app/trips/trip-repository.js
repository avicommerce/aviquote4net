mainModule.factory('tripRepository', function ($resource) {
    return {
        getAll: function() {
            return $resource(constants.WEBAPISERVER + 'api/Trips').query();
        },
        getOne: function(id) {
            return $resource(constants.WEBAPISERVER + 'api/Trips').get({ id: id });
        },
        save: function(trip) {
            return $resource(constants.WEBAPISERVER + 'api/Trips').save(trip);
        }
    };
});