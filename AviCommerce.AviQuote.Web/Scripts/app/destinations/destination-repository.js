mainModule.factory('destinationRepository', function ($resource) {
    return {
        getAll: function() {
            return $resource(constants.WEBAPISERVER + 'api/Destinations').query();
        },
        getOne: function(name) {
            return $resource(constants.WEBAPISERVER + 'api/Destinations').get({ id: name });
        }
    };
});