$(document).ajaxError(function (event, request, settings) {
    if (typeof (request.responseJSON) === 'object') {
        var data = request.responseJSON;
        if (typeof (data.modelState) === 'object') {
            $('#validaitonSummary').remove('li');
            var validationSummary = $('#validaitonSummary').get(0);
            var viewModel = { title: data.message, validation: new Array() };
            ko.cleanNode(validationSummary);

            for (var prop in data.modelState) {
                $.each(data.modelState[prop], function () {
                    viewModel.validation.push(this.toString());
                });
            }
            $('#validaitonSummary').alert();
            ko.applyBindings(viewModel, validationSummary);
        }
    }
});


var setEventList = function (category) {
    templateManager.load('eventList', function (template) {
        $.getJSON('api/events', { 'category': category }, function (events) {
            var viewModel = new eventListViewModel(events);
            $('#main').replaceWith(template);
            ko.applyBindings(viewModel, $('#main').get(0));
        })
    });
};

var templateManager = HtmlTemplateManager.getInstance();
var router = Router({
    '/': function () {
        setEventList('all');
    },
    '/events/all': function () {
        setEventList('all');
    },
    '/events/opening': function () {
        setEventList('opening');
    },
    'events/closed': function () {
        setEventList('closed');
    },
    '/events/create': function () {
        templateManager.load('createEvent', function (template) {
            $('#main').fadeOut(400, function () {
                $(this).replaceWith(template);
                initDatePicker();
                ko.applyBindings(new eventViewModle(), $('#main').get(0));
            });
        });
    },
    '/events/:id': function (id) {
        templateManager.load('eventDetail', function (template) {
            $.getJSON('/api/events/' + id, function (data) {
                $('#main').fadeOut(400, function () {
                    $(this).replaceWith(template);
                    initDatePicker();
                    var viewModel = new eventViewModle();
                    viewModel.fromJS(data);
                    ko.applyBindings(viewModel, $('#main').get(0));
                });
            });
        })
    },
});
router.init('/');