﻿/// <reference path="/Assests/admin/libs/angular/angular.js" />
(function () {
    angular.module('company.home', ['company.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("home", {
                url: "/admin",
                parent: "base",
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }
})();
