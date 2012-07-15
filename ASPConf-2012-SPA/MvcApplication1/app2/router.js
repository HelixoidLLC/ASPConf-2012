$(function () {

    // ##################
    // Swapping router
    // ##################

    var AppRouter = Support.SwappingRouter.extend({

        routes: {
            "tasks": "showTasks",
            "": "defaultRoute"
        },

        initialize: function () {
            console.log("router init");
            this.el = $('#viewPort');
        },

        showTasks: function () {
            console.log("tasks");
            
            var view = new TasksView();
            this.swap(view);
            view.refresh();
        },

        defaultRoute: function () {
            console.log("default");
            
            var view = new HomeView();
            this.swap(view);
        },
    });

    var appRouter = new AppRouter();

    Backbone.history.start();
});