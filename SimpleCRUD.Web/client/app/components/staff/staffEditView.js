(function (app) {
    app.controller('editStaffController', editStaffController);

    editStaffController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function editStaffController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.UpdateStaff = UpdateStaff;

        function loadStaffDetail() {
            apiService.get('staffs/getbyid/' + $stateParams.id, null, function (result) {
                $scope.staff = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function loadDepartmentList() {
            apiService.get('departments', null, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('No Records Found');
                }

                $scope.departments = result.data;
            }, function (error) {
                console.log(error);
            });
        }

        function UpdateStaff() {
            apiService.put('staffs/update', $scope.staff,
            function (result) {
                notificationService.displaySuccess(result.data.firstName + ' is updated');
                $state.go('staff');
            },
            function (error) {
                notificationService.displayError('Failed to update');

            });
        }

        loadStaffDetail();
        loadDepartmentList();
    }

})(angular.module('company.staff'));