﻿angular.module('shipments',
    [
        'auth0',
        'ngRoute',
        'shipments.home',
        'shipments.login'
    ])
    .config(function ($routeProvider, authProvider) {
        $routeProvider
            .when('/',
            {
                controller: 'HomeCtl',
                templateUrl: 'app/components/home/home.html',
                requiresLogin : true
            })
            .when('/login',
            {
                controller: 'LoginCtl',
                templateUrl: 'app/components/login/login.html'
            });

        authProvider.init({
            domain: AUTH0_DOMAIN,
            clientID: AUTH0_CLIENT_ID,
            loginUrl: '/login'
        });
    })
    .run(function (auth) {
        auth.hookEvents();
    });