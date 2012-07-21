define(["views/homeView"], function (HomeView) {

    // ##################
    // Swapping router
    // ##################

    return Support.SwappingRouter.extend({

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

            var that = this;

            require(["views/tasksView"], function (TasksView) {
                var view = new TasksView();
                that.swap(view);
                view.refresh();
            });
        },

        defaultRoute: function () {
            console.log("default");
            
            var view = new HomeView();
            this.swap(view);
        },
    });

    
});