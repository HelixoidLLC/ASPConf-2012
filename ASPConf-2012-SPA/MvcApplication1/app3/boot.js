$(function () {

    require.config({
        baseUrl: "/app3",
        paths: {
            'text': '../js/text'
        }
    });

    require(["router"], function(AppRouter) {
        var appRouter = new AppRouter();

        Backbone.history.start();
    });
});