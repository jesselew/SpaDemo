var eventViewModle = function () {
    var self = this;
    self.id = 0;
    self.title = ko.observable();
    self.description = ko.observable();
    self.start = ko.observable();
    self.end = ko.observable();
    self.owner = ko.observable();
    self.editEnabled = ko.observable(false);
    self.canEdit = ko.observable(true);

    self.submit = function () {
        $.ajax({
            url: '/api/events',
            type: 'POST',
            data: ko.toJSON(self),
            contentType: 'application/json;charset=utf-8',
            success: function () { location.href = '#/' },
            error: function (e) {
                console.log(e)
            }
        });
        return false;
    };

    self.update = function () {
        $.ajax({
            url: '/api/events',
            type: 'PUT',
            data: ko.toJSON(self),
            contentType: 'application/json;charset=utf-8',
            success: function () { location.href = '#/' },
            error: function (e) { console.log(e) }
        });
        return false;
    };

    self.enable = function () {
        self.editEnabled(true);
    };

    self.fromJS = function (data) {
        self.id = data.id;
        self.title(data.title);
        self.description(data.description);
        self.start(data.start);
        self.end(data.end);
        self.owner(data.owner);
        self.status = data.status;
        self.canEdit(self.status !== 'Closed');
    }
};