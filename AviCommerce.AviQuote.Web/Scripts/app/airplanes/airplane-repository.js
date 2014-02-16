mainModule.factory('airplaneRepository', function ($resource) {
    return {
        getAll: function() {
            return $resource(constants.WEBAPISERVER + 'api/Airplanes').query();
        },
        getOne: function(name) {
            return $resource(constants.WEBAPISERVER + 'api/Airplanes').get({ id: name });
        },
        save: function(airplane) {
            return $resource(constants.WEBAPISERVER + 'api/Airplanes').save(airplane);
        }
    };
});