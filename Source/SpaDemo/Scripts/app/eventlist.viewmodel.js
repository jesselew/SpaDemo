var eventListViewModel = function (events) {
    var self = this;
    self.events = events;
    self.close = function (event) {
        $.ajax({
            url: '/api/events/' + event.id + '/close',
            type: 'PUT',
            success: function () {
                router.init('/');
            },
            error: function (e) { console.log(e) }
        });
    };
}
