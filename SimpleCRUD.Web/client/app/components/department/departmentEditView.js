(function (app) {
    app.controller('departmentEditController', departmentEditController);

    departmentEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function departmentEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.UpdateDepartment = UpdateDepartment;

        function loadDepartmentDetail() {
            apiService.get('departments/getbyid/' + $stateParams.id, null, function (result) {
                $scope.department = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateDepartment() {
            apiService.put('departments/update', $scope.department,
            function (result) {
                notificationService.displaySuccess(result.data.name + ' is updated');
                $state.go('department');
            },
            function (error) {
                notificationService.displayError('Failed to update');

            });
        }

        loadDepartmentDetail();
    }
})(angular.module('company.department'));