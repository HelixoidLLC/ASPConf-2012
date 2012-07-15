define(["text!templates/tasksView.tmpl.html",
    "text!templates/task.tmpl.html"], function (template, taskTemplate) {

    // ##################
    // Backbone View
    // ##################

    return Backbone.View.extend({
        initialize: function() {
            _.bindAll(this, 'render');
        },

        events: {
            'click #sendTask': "addTask"
        },

        render: function() {
            this.$el.html(template);
            return this;
        },

        refresh: function() {
            $.get("/api/tasks", function(data) {
                console.log(data);
                var templ = $.templates(taskTemplate);
                $('#tasksList').html(templ.render(data));
            });
        },

        addTask: function(event) {
            event.preventDefault();

            var task = $("#task").val();

            $.ajax({
                url: "/api/tasks",
                data: JSON.stringify({ Subject: task }),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                success: this.refresh
            });
        }
    });

});