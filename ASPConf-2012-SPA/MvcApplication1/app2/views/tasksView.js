// ##################
// Backbone View
// ##################

var TasksView = Backbone.View.extend({

    initialize: function () {
        _.bindAll(this, 'render');
    },
    
    events: {
        'click #sendTask': "addTask"
    },

    render: function () {
        this.$el.html($('#tmpl-tasksView').html());
        return this;
    },
    
    refresh: function() {
        $.get("/api/tasks", function (data) {
            console.log(data);
            $('#tasksList').html($("#tmpl-tasks").render(data));
        });
    },
    
    addTask: function (event) {
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