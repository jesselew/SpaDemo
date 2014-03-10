var HtmlTemplateManager = (function () {
    var instance,
        baseUrl = '/template/',
        templates = {
            'eventList': { url: 'eventList' },
            'createEvent': { url: 'createEvent' },
            'eventDetail': { url: 'eventDetail' },
        };

    function createInstance() {
        var object = new Object();
        object.templates = new Array();
        object.load = function (name, callback) {
            if (object.templates[name] != undefined) {
                callback(object.templates[name]);
            };
            if (templates[name] == undefined) {
                throw new ExceptionInformation('Error template name.');
            };
            require(['text!' + baseUrl + templates[name].url], function (content) {
                object.templates[name] = content;
                callback(object.templates[name]);
            });
        };
        return object;
    }

    return {
        getInstance: function () {
            if (!instance) {
                instance = createInstance();
            }

            return instance;
        }
    };
})();