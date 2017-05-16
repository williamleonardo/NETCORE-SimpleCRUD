(function () {
    angular.module('company.department', ['company.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state("department", {
            url: "/department",
            parent: "base",
            templateUrl: "/app/components/department/departmentListView.html",
            controller: "departmentListController"
        })
        .state("add_department", {
            url: "/add_department",
            parent: "base",
            templateUrl: "/app/components/department/departmentAddView.html",
            controller: "departmentAddController"
        })
        .state("edit_department", {
            url: "/edit_department/:id",
            parent: "base",
            templateUrl: "/app/components/department/departmentEditView.html",
            controller: "departmentEditController"
        });

        $urlRouterProvider.otherwise('/admin');
    }
})();