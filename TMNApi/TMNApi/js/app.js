var pitchApp = angular.module('pitchApp', ['ngRoute', 'googlechart']);

pitchApp.config(function ($routeProvider) {
    $routeProvider
        // route for home page
        .when('/', {
            templateUrl: 'templates/home-template.html'
        })

        // route for the batter page
        .when('/batter/:paramName/:paramId', {
            templateUrl: 'templates/batter-template.html',
            controller: 'batterController'
        })

        // route for the pitcher page
        .when('/pitcher/:paramName/:paramId', {
            templateUrl: 'templates/pitcher-template.html',
            controller: 'pitchController'
        });
});