define(["text!templates/homeView.tmpl.html"], function(template) {

    // ##################
    // Backbone View
    // ##################

    return Backbone.View.extend({
        initialize: function() {
            _.bindAll(this, 'render');
        },

        render: function() {
            this.$el.html(template);
            return this;
        }
    });

});