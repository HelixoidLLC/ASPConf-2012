$(function () {

    require.config({
        baseUrl: "/app4",
        paths: {
            'text': '../js/text',
            'dynTemplate': '/../Home'
        }
    });

    require(["router"], function(AppRouter) {
        var appRouter = new AppRouter();

        Backbone.history.start();
    });
});