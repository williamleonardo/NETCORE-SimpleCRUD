(function () {
    angular.module('company',
        ['smart-table',
        'ngMaterial',
        'ngMessages',
        'angularMoment',
        'ngMaterialDatePicker',
        'xeditable',
        'angularUUID2',
        'company.home',
        'company.department',
        'company.staff',
        'company.overview'])
        .config(config)
        .config(configAuthentication)
        .config(configCompiler);
    config.$inject = ['$stateProvider', '$urlRouterProvider', '$compileProvider'];

    function configCompiler($compileProvider) {
        $compileProvider.preAssignBindingsEnabled(true);
    }

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            });
        $urlRouterProvider.otherwise('/admin');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status === "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status === "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();
