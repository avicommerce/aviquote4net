// This is maonly used to allow sharing of the trip detail among multiple controllers/views
mainModule.service('tripService', function () {
    var trip = null;

    return {
        setTrip: function(tr) {
            this.trip = tr;
        },
        getTrip: function() {
            return this.trip;
        }
    };
});