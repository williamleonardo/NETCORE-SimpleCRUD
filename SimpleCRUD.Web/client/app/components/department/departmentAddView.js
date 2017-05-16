(function (app) {
    app.controller('departmentAddController', departmentAddController);

    departmentAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function departmentAddController(apiService, $scope, notificationService, $state) {
        $scope.AddDepartment = AddDepartment;

        function AddDepartment() {
            apiService.post('departments/create', $scope.department,
            function (result) {
                notificationService.displaySuccess($scope.department.name + ' is added successful');
                $state.go('department');
            },
            function (error) {
                notificationService.displayError('Failed to add new department');
            });
        }
    }
})(angular.module('company.department'));