(function () {
    'use strict';

    angular.module('company.overview', ['company.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('overview', {
            url: "/overview",
            parent: "base",
            templateUrl: "/app/components/dashboard/overview.html"
        });

        $urlRouterProvider.otherwise('/admin');
    }
})();