(function () {
    angular.module('company.staff', ['company.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('staff', {
            url: "/staff",
            parent: "base",
            templateUrl: "/app/components/staff/staffListView.html",
            controller: "staffListController"
        })
        .state('add_staff', {
            url: "/addStaff",
            parent: "base",
            templateUrl: "/app/components/staff/staffAddView.html",
            controller: "addStaffController"
        })
        .state('edit_staff', {
            url: "/editstaff/:id",
            parent: "base",
            templateUrl: "/app/components/staff/staffEditView.html",
            controller: "editStaffController"
        });

        $urlRouterProvider.otherwise('/admin');
    }
})();