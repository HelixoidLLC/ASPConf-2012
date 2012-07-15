// ##################
// Backbone View
// ##################

var HomeView = Backbone.View.extend({

    initialize: function () {
        _.bindAll(this, 'render');
    },

    render: function () {
        this.$el.html($('#tmpl-homeView').html());
        return this;
    }
});