/// <reference path="../Scripts/jquery-1.7.2.js" />
/// <reference path="../Scripts/knockout-2.1.0.debug.js" />

$(function () {

    var ViewModel = function() {

        var self = this;

        self.item = "Car";

        self.echoMessages = ko.observableArray([
            { message: "---", sender: "+++" }
        ]);

        self.buyItem = function() {

            $.post("/api/shopping", { Name: this.item });

        };

        self.itemProcessed = function(message, instance) {
            console.log(message);

            toastr.success('by: ' + instance, message);

            self.echoMessages.push({ message: message, sender: instance });
        };

        return self;
    };

    var viewModel = new ViewModel();

    ko.applyBindings(viewModel);

    var msgHub = $.connection.messagingHub;
    //msgHub.start();
    msgHub.itemProcessed = viewModel.itemProcessed;
    $.connection.hub.start();
});